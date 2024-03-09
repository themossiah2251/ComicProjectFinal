using ComicProjectFinal.Models;
using ComicProjectFinal.Data;

using Microsoft.EntityFrameworkCore;

namespace ComicProjectFinal.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Category.ToListAsync();
        }

        // Method to get products with optional search term and categoryId filters
        public async Task<IEnumerable<Products>> GetProducts(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            var productQuery = _db.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(sTerm))
            {
                productQuery = productQuery.Where(p => p.ProductName.ToLower().StartsWith(sTerm));
            }

            if (categoryId > 0)
            {
                productQuery = productQuery.Where(p => p.CategoryId == categoryId);
            }

            var products = await productQuery.Select(p => new Products
            {
                ProductsId = p.ProductsId,
                Images = p.Images,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                Price = p.Price,
                CategoryName = p.Categories.CategoryName 
            }).ToListAsync();

            return products;
        }
    }
}

