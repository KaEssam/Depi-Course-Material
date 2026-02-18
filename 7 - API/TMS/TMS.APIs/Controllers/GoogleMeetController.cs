using Microsoft.AspNetCore.Mvc;
using YourProject.Services;
using Microsoft.Extensions.Configuration;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleMeetController : ControllerBase
    {
    private readonly GoogleMeetService _googleMeetService;

    public GoogleMeetController(GoogleMeetService googleMeetService)
    {
        _googleMeetService = googleMeetService;
    }

        [HttpGet("create")]
        public async Task<IActionResult> CreateGoogleMeet()
        {
            try
            {
                var meetLink = await _googleMeetService.CreateGoogleMeet();
                return Ok(new { meetLink });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
