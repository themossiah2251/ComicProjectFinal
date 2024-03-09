using ComicProjectFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComicProjectFinal.Repositories
{
    public class CartRepository : ICartRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> AddItem(int productId, int qty)
        {
            string userId = GetUserId();
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new Cart
                    {
                        UserId = userId
                    };
                    _db.Cart.Add(cart);
                }
                _db.SaveChanges();
                // cart detail section
                var cartItem = _db.CartDetails
                                  .FirstOrDefault(a => a.CartId == cart.Id && a.ProductsId == productId);
                if (cartItem is not null)
                {
                    cartItem.Quantity += qty;
                }
                else
                {
                    var product = _db.Products.Find(productId);
                    cartItem = new CartDetails
                    {
                        ProductsId = productId,
                        CartId = cart.Id,
                        Quantity = qty,
                        UnitPrice = product.Price
                    };
                    _db.CartDetails.Add(cartItem);
                }
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }


        public async Task<int> RemoveItem(int productId)
        {
            //using var transaction = _db.Database.BeginTransaction();
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");
                // cart detail section
                var cartItem = _db.CartDetails
                                  .FirstOrDefault(a => a.CartId == cart.Id && a.ProductsId == productId);
                if (cartItem is null)
                    throw new Exception("Not items in cart");
                else if (cartItem.Quantity == 1)
                    _db.CartDetails.Remove(cartItem);
                else
                    cartItem.Quantity = cartItem.Quantity - 1;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }

        public async Task<Cart> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");
            var Cart = await _db.Cart
                                  .Include(a => a.CartDetails)
                                  .ThenInclude(a => a.Products)
                                  .ThenInclude(a => a.Categories)
                                  .Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return Cart;

        }
        public async Task<Cart> GetCart(string userId)
        {
            var cart = await _db.Cart.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        public async Task<int> GetCartItemCount(string userId = "")
        {
            if (string.IsNullOrEmpty(userId)) // updated line
            {
                userId = GetUserId();
            }
            var data = await (from cart in _db.Cart
                              join cartDetails in _db.CartDetails
                              on cart.Id equals cartDetails.CartId
                              where cart.UserId == userId // updated line
                              select new { cartDetails.CartId }
                        ).ToListAsync();
            return data.Count;
        }

        public async Task<bool> DoCheckout()
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");

                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");

                var cartDetail = _db.CartDetails.Where(a => a.CartId == cart.Id).ToList();
                if (!cartDetail.Any())
                    throw new Exception("Cart is empty");

                // Here is where you would add the new order creation logic
                var order = new Orders
                {
                    UserId = userId,
                    CreateDate = DateTime.UtcNow,
                    OrderStatusId = (int)OrderStatuses.Pending // Assuming you have an enum corresponding to your OrderStatus table
                };
                _db.Orders.Add(order);
                await _db.SaveChangesAsync(); // Save the order so it gets an ID

                // Logic for adding OrderDetails based on the CartDetails...
                foreach (var item in cartDetail)
                {
                    var orderDetail = new OrderDetails
                    {
                        ProductsId =(int)item.ProductsId,
                        OrderId = order.OrdersId, // Now we have an OrdersId from the order we just saved
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _db.OrderDetails.Add(orderDetail);
                }

                await _db.SaveChangesAsync(); // Save OrderDetails to the database

                // Logic for clearing the cart...
                _db.CartDetails.RemoveRange(cartDetail);
                await _db.SaveChangesAsync();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Properly handle the exception
                // Log the exception
                transaction.Rollback();
                return false;
            }
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }


    }
}
