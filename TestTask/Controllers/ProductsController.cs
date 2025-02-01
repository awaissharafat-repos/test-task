using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;
using TestTask.Models.DTOs;
using TestTask.Models.ViewModels;

namespace TestTask.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult AllProducts(string Name)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.AllProducts = _productService.GetAllProducts(Name);
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct(int ProductId)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            if (ProductId > 0)
            {
                productViewModel.SingleProduct = _productService.GetProductById(ProductId);
            }
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            var IsExisit = _productService.ProductExistsByName(productViewModel.SingleProduct.Name, productViewModel.SingleProduct.ProductId);
            if (IsExisit)
            {
                ViewBag.ErrorMessage = "Product Already Exisit";
                return View(productViewModel);
            }
            else
            {
                _productService.AddProduct(productViewModel.SingleProduct);
            }

            if (productViewModel.SingleProduct.ProductId == 0)
            {
                ViewBag.SuccessMessage = "Saved Successfully";
            }
            else if (productViewModel.SingleProduct.ProductId > 0)
            {
                ViewBag.SuccessMessage = "Updated Successfully";
            }
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id)
        {
            _productService.DeleteProduct(Id);
            ProductViewModel productViewModel = new ProductViewModel();
            TempData["SuccessMessage"] = "Product Deleted Successfully.";
            return RedirectToAction("AllProducts", "Products", productViewModel);
        }

    }
}
