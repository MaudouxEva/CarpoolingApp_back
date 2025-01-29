using CarpoolingApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace CarpoolingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // MODIFICATION ICI: On injecte IAuthService
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // MODIFICATION ICI: Endpoint de REGISTER
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterDto dto)
        {
            try
            {
                _authService.Register(dto.Email, dto.Password, dto.FirstName, dto.LastName, dto.IsAdmin);
                return Ok("User registered successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // MODIFICATION ICI: Endpoint de LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
            {
                string token = _authService.Login(dto.Email, dto.Password);
                return Ok(new { Token = token });
            }
            catch(InvalidCredentialException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch(AuthenticationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // MODIFICATION ICI: Data Transfer Objects
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
