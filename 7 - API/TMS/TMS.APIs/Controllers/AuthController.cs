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
           var res = await _service.Register(registerDto);
            return Ok(res);
        }


        [HttpPost(template: "Login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginDto loginDto)
        {
            await _service.Login(loginDto);
            return Ok();
        }


    }
}
