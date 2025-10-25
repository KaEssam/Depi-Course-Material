using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.App.Dtos;
using TMS.App.Interface.Services;

namespace TMS.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController( IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterDto registerDto)
        {
            try
            {
                var res = await _service.Register(registerDto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Registration failed. Username may already exist." });
            }
        }


    [HttpPost(template: "Login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginDto loginDto)
    {
        try
        {
            var res = await _service.Login(loginDto);
            return Ok(res);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred during login" });
        }
    }


    }
}
