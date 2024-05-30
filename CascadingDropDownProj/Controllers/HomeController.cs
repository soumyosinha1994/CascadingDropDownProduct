using CascadingDropDownProj.Data;
using CascadingDropDownProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CascadingDropDownProj.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [OutputCache(Duration = 3600)]
        public IActionResult Index()
        {
            ViewModelVM viewModelVM = new()
            {
                CategoryList = _context.Categories.Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString()
                }),
                Category = new(),
                SubCategory = new(),
                Product = new()
            };

            return View(viewModelVM);
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            var Category = _context.Categories.ToList();
            return Json(new SelectList(Category, "Id", "CategoryName"));
        }
        [HttpGet]
        public IActionResult GetSubCategory(int Id)
        {
            var SubCategory = _context.SubCategories.Where(x => x.CategoryId == Id).ToList();
            return Json(new SelectList(SubCategory, "Id", "SubCategoryName"));
        }
        [HttpGet]
        public IActionResult GetProduct(int Id)
        {
            var Product = _context.Products.Where(x => x.SubCategoryId == Id).ToList();
            return Json(new SelectList(Product, "Id", "ProductName"));
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
