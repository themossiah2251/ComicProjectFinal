using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using ComicProjectFinal.Data; // Adjust namespace based on your actual structure
using Microsoft.EntityFrameworkCore; // For querying the database
using System.Linq;
using System.Security.Claims; // For LINQ queries

namespace ComicProjectFinal.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckOutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Your index logic here (if needed)
            return View();
        }

        public IActionResult OrderConfirmation()
        {
            var sessionId = TempData["Session"]?.ToString();
            if (string.IsNullOrEmpty(sessionId))
            {
                return View("Error"); // Consider creating an Error view
            }

            var service = new Stripe.Checkout.SessionService();
            var session = service.Get(sessionId);
            if (session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                return View("Success");
            }
            return View("Login");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> CheckOut()
        {
            // Assuming you have a way to get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve cart items for the current user
            var cartItems = await _context.CartDetails
                .Where(cd => cd.Carts.UserId == userId)
                .Include(cd => cd.Products)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return View("Error", new ErrorViewModel { RequestId = "Your cart is empty" });
            }

            var lineItems = cartItems.Select(ci => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(ci.Products.Price * 100), // Convert price to cents
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.Products.ProductName,
                        // You can add more product details here (e.g., description, images)
                    },
                },
                Quantity = ci.Quantity,
            }).ToList();

            var domain = "http://localhost:7279/"; // Make sure to replace this with your actual domain
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = domain + "CheckOut/OrderConfirmation?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "CheckOut/Cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            // Save the session ID to the TempData to use it in the OrderConfirmation action
            TempData["Session"] = session.Id;

            // Redirect to the Stripe Checkout page
            return Redirect(session.Url);
        }
    }
}