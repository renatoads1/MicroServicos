using Microsoft.AspNetCore.Mvc;
using ProductApi.DTO;
using ProductApi.Service;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            // Exemplo simples: validação mockada
            if (login.Username == "renatoads1" && login.Password == "r3n4t0321")
            {
                var token = _authService.GenerateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized("Credenciais inválidas.");
        }
    }
}
