using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TMS.UI.Models;

namespace TMS.UI.Controllers
{
    public class TasksController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TasksController> _logger;

        public TasksController(IHttpClientFactory httpClientFactory, ILogger<TasksController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        private HttpClient GetAuthenticatedClient()
        {
            var client = _httpClientFactory.CreateClient("TMSAPI");
            var token = HttpContext.Session.GetString("JWTToken");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        private bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("JWTToken"));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            try
            {
                var client = GetAuthenticatedClient();
                var response = await client.GetAsync("Tasks");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tasks = JsonSerializer.Deserialize<List<TaskViewModel>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<TaskViewModel>();

                    ViewBag.Username = HttpContext.Session.GetString("Username");
                    return View(tasks);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    HttpContext.Session.Clear();
                    TempData["ErrorMessage"] = "Your session has expired. Please login again.";
                    return RedirectToAction("Login", "Auth");
                }

                return View(new List<TaskViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching tasks");
                TempData["ErrorMessage"] = "Error loading tasks. Please try again.";
                return View(new List<TaskViewModel>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskViewModel model)
        {
            if (!IsAuthenticated())
            {
                return Json(new { success = false, message = "Not authenticated" });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid task data" });
            }

            try
            {
                var client = GetAuthenticatedClient();
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Tasks", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var task = JsonSerializer.Deserialize<TaskViewModel>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return Json(new { success = true, message = "Task created successfully", data = task });
                }

                return Json(new { success = false, message = "Failed to create task" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating task");
                return Json(new { success = false, message = "Error creating task" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTaskViewModel model)
        {
            if (!IsAuthenticated())
            {
                return Json(new { success = false, message = "Not authenticated" });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid task data" });
            }

            try
            {
                var client = GetAuthenticatedClient();
                var content = new StringContent(JsonSerializer.Serialize(new { Title = model.Title }), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"Tasks/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var task = JsonSerializer.Deserialize<TaskViewModel>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return Json(new { success = true, message = "Task updated successfully", data = task });
                }

                return Json(new { success = false, message = "Failed to update task" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating task");
                return Json(new { success = false, message = "Error updating task" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAuthenticated())
            {
                return Json(new { success = false, message = "Not authenticated" });
            }

            try
            {
                var client = GetAuthenticatedClient();
                var response = await client.DeleteAsync($"Tasks/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Task deleted successfully" });
                }

                return Json(new { success = false, message = "Failed to delete task" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting task");
                return Json(new { success = false, message = "Error deleting task" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTask(int id)
        {
            if (!IsAuthenticated())
            {
                return Json(new { success = false, message = "Not authenticated" });
            }

            try
            {
                var client = GetAuthenticatedClient();
                var response = await client.GetAsync($"Tasks/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var task = JsonSerializer.Deserialize<TaskViewModel>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return Json(new { success = true, data = task });
                }

                return Json(new { success = false, message = "Task not found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching task");
                return Json(new { success = false, message = "Error fetching task" });
            }
        }
    }
}

