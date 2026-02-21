using ATM.Application.DTOs;
using ATM.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{
    /// <summary>
    /// Controlador encargado de la gestión de acceso y seguridad del cajero.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

      
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Valida las credenciales del usuario (DNI y PIN) y emite un token JWT.
        /// </summary>
        /// <param name="request">Objeto con las credenciales de acceso.</param>
        /// <returns>Un token JWT si el login es exitoso o 401 si falla.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request);

            if (string.IsNullOrEmpty(token))
            {
                // Siguiendo buenas prácticas, no damos detalles de por qué falló
                return Unauthorized(new { message = "Credenciales inválidas. Por favor, revise su DNI y PIN." });
            }


            return Ok(new { token });
        }
    }
}

