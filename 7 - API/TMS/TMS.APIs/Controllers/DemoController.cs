using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.App.Dtos;
using TMS.App.Interface.Services;

namespace TMS.APIs.Controllers
{
    /// <summary>
    /// Demo Controller for Educational Purposes
    /// Shows the difference between public endpoints (no token) and protected endpoints (with token)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public DemoController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // ==========================================
        // PART 1: PUBLIC ENDPOINTS (NO TOKEN REQUIRED)
        // ==========================================

        /// <summary>
        /// Step 1: Get all tasks - NO AUTHENTICATION REQUIRED
        /// This endpoint is public and anyone can access it
        /// </summary>
        [HttpGet("public/tasks")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetPublicTasks()
        {
            // This endpoint does NOT require authentication
            // Anyone can call this and get the list of tasks
            var tasks = await _taskService.GetAllTasks();
            return Ok(new
            {
                message = "✅ Success! You got data WITHOUT a token",
                data = tasks,
                info = "This is a PUBLIC endpoint - no authentication required"
            });
        }

        /// <summary>
        /// Step 2: Create a task - NO AUTHENTICATION REQUIRED
        /// This endpoint is public and anyone can create a task
        /// </summary>
        [HttpPost("public/tasks")]
        public async Task<ActionResult<TaskDto>> CreatePublicTask(CreateTaskDto createTaskDto)
        {
            // This endpoint does NOT require authentication
            // Anyone can call this and create a new task
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _taskService.CreateTask(createTaskDto);
            return Ok(new
            {
                message = "✅ Success! You created a task WITHOUT a token",
                data = task,
                info = "This is a PUBLIC endpoint - no authentication required"
            });
        }

        // ==========================================
        // PART 2: PROTECTED ENDPOINTS (TOKEN REQUIRED)
        // ==========================================

        /// <summary>
        /// Step 3: Get all tasks - AUTHENTICATION REQUIRED
        /// This endpoint requires a valid JWT token
        /// </summary>
        [Authorize] // This attribute means: "You MUST have a valid token to access this"
        [HttpGet("protected/tasks")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetProtectedTasks()
        {
            // This endpoint REQUIRES authentication
            // You must send a valid JWT token in the Authorization header
            var tasks = await _taskService.GetAllTasks();

            // Get the username from the token claims
            var username = User.Identity?.Name ?? "Unknown User";

            return Ok(new
            {
                message = $"✅ Success! You got data WITH a token as user: {username}",
                data = tasks,
                info = "This is a PROTECTED endpoint - authentication required"
            });
        }

        /// <summary>
        /// Step 4: Delete a task - AUTHENTICATION REQUIRED
        /// This endpoint requires a valid JWT token
        /// Only authenticated users can delete tasks
        /// </summary>
        [Authorize] // This attribute means: "You MUST have a valid token to access this"
        [HttpDelete("protected/tasks/{id}")]
        public async Task<ActionResult> DeleteProtectedTask(int id)
        {
            // This endpoint REQUIRES authentication
            // You must send a valid JWT token in the Authorization header
            var result = await _taskService.DeleteTask(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "❌ Task not found",
                    info = "This is a PROTECTED endpoint - authentication required"
                });
            }

            var username = User.Identity?.Name ?? "Unknown User";

            return Ok(new
            {
                message = $"✅ Success! Task deleted by user: {username}",
                info = "This is a PROTECTED endpoint - authentication required"
            });
        }

        /// <summary>
        /// Helper endpoint to test if your token is valid
        /// </summary>
        [Authorize]
        [HttpGet("protected/test-token")]
        public ActionResult TestToken()
        {
            var username = User.Identity?.Name ?? "Unknown User";
            var claims = User.Claims.Select(c => new { c.Type, c.Value });

            return Ok(new
            {
                message = "✅ Your token is valid!",
                username = username,
                claims = claims
            });
        }
    }
}


