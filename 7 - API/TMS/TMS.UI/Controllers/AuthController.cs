using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using TMS.UI.Models;

namespace TMS.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IHttpClientFactory httpClientFactory, ILogger<AuthController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in, redirect to dashboard
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWTToken")))
            {
                return RedirectToAction("Index", "Tasks");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                var loginDto = new { UserName = model.UserName, PassWord = model.PassWord };
                var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token))
                    {
                        HttpContext.Session.SetString("JWTToken", authResponse.Token);
                        HttpContext.Session.SetString("Username", model.UserName);

                        TempData["SuccessMessage"] = "Welcome back! Login successful.";
                        return RedirectToAction("Index", "Tasks");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                ModelState.AddModelError(string.Empty, "An error occurred during login. Please try again.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            // If already logged in, redirect to dashboard
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWTToken")))
            {
                return RedirectToAction("Index", "Tasks");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var client = _httpClientFactory.CreateClient("TMSAPI");
                var registerDto = new { UserName = model.UserName, PassWord = model.PassWord };
                var content = new StringContent(JsonSerializer.Serialize(registerDto), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please login.";
                    return RedirectToAction("Login");
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Registration failed. Username may already exist.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                ModelState.AddModelError(string.Empty, "An error occurred during registration. Please try again.");
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}

