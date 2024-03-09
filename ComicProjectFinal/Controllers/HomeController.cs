using ComicProjectFinal.Models;
using ComicProjectFinal.Models;
using ComicProjectFinal.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComicProjectFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
            private readonly IHomeRepository _homeRepository;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly SignInManager<IdentityUser> _signInManager;

            public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {
                _homeRepository = homeRepository;
                _logger = logger;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<IActionResult> Index(string sterm = "", int categoryId = 0)
            {
                if (_signInManager.IsSignedIn(User) && await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Admin"))
                {
                    return RedirectToAction("Index", "Products"); // Assuming "Products" controller exists for admin
                }

                IEnumerable<Products> products = await _homeRepository.GetProducts(sterm, categoryId);
                IEnumerable<Category> categories = await _homeRepository.Categories();
                ProductDisplayModel productModel = new ProductDisplayModel
                {
                    Products = products,
                    Categories = categories,
                    STerm = sterm,
                    CategoryId = categoryId
                };
                return View(productModel);
            }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}