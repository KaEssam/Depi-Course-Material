using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TMS.UI.Controllers
{
    public class DemoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DemoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            ViewBag.IsAuthenticated = !string.IsNullOrEmpty(token);
            ViewBag.Username = HttpContext.Session.GetString("Username");

            return View();
        }

        // PUBLIC ENDPOINTS - No token required
        [HttpGet]
        public async Task<IActionResult> GetPublicData()
        {
            SetAuthState();

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                var response = await client.GetAsync("Demo/public/tasks");
                var content = await response.Content.ReadAsStringAsync();

                ViewBag.Result = $"Status: {response.StatusCode}\n\n{content}";
                TempData["Message"] = "✅ GET Public - No token required";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublicData(string title)
        {
            SetAuthState();

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(new { title }),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("Demo/public/tasks", jsonContent);
                var content = await response.Content.ReadAsStringAsync();

                ViewBag.Result = $"Status: {response.StatusCode}\n\n{content}";
                TempData["Message"] = "✅ POST Public - Task created without token";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View("Index");
        }

        // PROTECTED ENDPOINTS - Token required
        [HttpGet]
        public async Task<IActionResult> GetProtectedData()
        {
            SetAuthState();

            var token = HttpContext.Session.GetString("JWTToken");

            if (string.IsNullOrEmpty(token))
            {
                TempData["Error"] = "❌ No token - Please login first";
                return View("Index");
            }

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("Demo/protected/tasks");
                var content = await response.Content.ReadAsStringAsync();

                ViewBag.Result = $"Status: {response.StatusCode}\n\n{content}";
                TempData["Message"] = "✅ GET Protected - Token was sent and validated";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProtectedData(int id)
        {
            SetAuthState();

            var token = HttpContext.Session.GetString("JWTToken");

            if (string.IsNullOrEmpty(token))
            {
                TempData["Error"] = "❌ No token - Please login first";
                return View("Index");
            }

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.DeleteAsync($"Demo/protected/tasks/{id}");
                var content = await response.Content.ReadAsStringAsync();

                ViewBag.Result = $"Status: {response.StatusCode}\n\n{content}";
                TempData["Message"] = $"✅ DELETE Protected - Task {id} deleted with token";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return View("Index");
        }

        private void SetAuthState()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            ViewBag.IsAuthenticated = !string.IsNullOrEmpty(token);
            ViewBag.Username = HttpContext.Session.GetString("Username");
        }
    }
}

