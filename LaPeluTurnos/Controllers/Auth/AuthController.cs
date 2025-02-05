using LaPeluTurnos.Context;
using LaPeluTurnos.Models;
using LaPeluTurnos.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaPeluTurnos.Services.Security;

namespace LaPeluTurnos.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {

            var token =await _authService.Loginservice(request);
            return token != null ? Ok(new {Token = token}) : Unauthorized("Credenciales incorrectas");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            var user = await _authService.RegisterService(request);
            return user != null ? Ok("El usuario quedo registrado") : BadRequest("Error en el registro de usuario");
        }
    }
}