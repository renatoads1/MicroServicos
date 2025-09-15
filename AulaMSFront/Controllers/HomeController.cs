using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AulaMSFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,
            IAuthService authService,
            IProductService productService)
        {
            _authService = authService;
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products =  _productService.GetAllProductsAsync().Result;
            return View(products);
        }
        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> Detail(int id)
        {
            var token = await HttpContext.GetTokenAsync("JWTToken");
            var products = await _productService.GetByIdProductsAsync(id);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var token = await _authService.LoginAsync(login);
            if (string.IsNullOrEmpty(token))
            {
                ViewBag.Message = "Usuário ou senha inválidos";
                return View();
            }

            // Armazenar o token na sessão
            HttpContext.Session.SetString("JWTToken", token);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
