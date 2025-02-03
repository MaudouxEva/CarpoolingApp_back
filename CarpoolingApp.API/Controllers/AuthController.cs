using CarpoolingApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using CarpoolingApp.API.DTOs;

namespace CarpoolingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // On injecte IAuthService
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        // MODIFICATION ICI: Endpoint de REGISTER
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            try
            {
                // On appelle AuthService.Register => renvoie un token
                string token = _authService.Register(dto);
                // On peut renvoyer le token direct ou un objet plus complet
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                string token = _authService.Login(dto.Email, dto.Password);
                return Ok(new { Token = token });
            }
            catch (InvalidCredentialException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}