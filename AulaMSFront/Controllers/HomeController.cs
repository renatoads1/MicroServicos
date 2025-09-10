using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AulaMSFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _authService = authService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
