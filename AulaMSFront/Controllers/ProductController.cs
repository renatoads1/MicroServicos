using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AulaMSFront.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Erro ao criar Product";
                return View();
            }
            else {
                var response = await _productService.CreateProductsAsync(model);
                return RedirectToAction(nameof(Index));
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var products = await _productService.GetByIdProductsAsync(id);
            if (products == null) { 
                return NotFound();
            }
            return View(products);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Erro ao Editar Product";
                return View();
            }
            else
            {
                var response = await _productService.UpdateProductsAsync(model);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var products = await _productService.DeleteProductsAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
