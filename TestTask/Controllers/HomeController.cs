using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.Interfaces;
using TestTask.Models.DTOs;
using TestTask.Models.ViewModels;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.AllProducts = _productService.GetAllProducts(null);
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Search(string Name)
        {
            IEnumerable<AllProductsDTO> filteredProducts = _productService.GetAllProducts(Name);

            return Json(filteredProducts);
        }
    }
}
