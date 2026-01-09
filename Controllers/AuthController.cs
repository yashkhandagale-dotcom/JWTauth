using Microsoft.AspNetCore.Mvc;
using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Services.Interfaces;

namespace UserCRUDandJWT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _authService.RegisterAsync(dto);
                return Ok(new { Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginDto dto,
            [FromServices] IJwtTokenService jwtTokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.ValidateUserAsync(dto);

            if (user == null)
                return Unauthorized(new { Error = "Invalid credentials" });

            var token = jwtTokenService.GenerateToken(user);

            return Ok(new { Token = token });

        }
    }
}
