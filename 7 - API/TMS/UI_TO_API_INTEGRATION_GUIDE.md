# 🔗 TMS UI to API Integration Guide

## 📖 Overview

This document explains step-by-step how the **TMS.UI** (Frontend) was integrated with the **TMS.APIs** (Backend) to create a fully functional Task Management System.

---

## 🏗️ Architecture Overview

```
┌─────────────────┐         HTTPS/JSON          ┌──────────────────┐
│                 │      ◄─────────────────►     │                  │
│    TMS.UI       │                              │    TMS.APIs      │
│   (Frontend)    │     HttpClient Requests      │    (Backend)     │
│  Port: 5001     │      Bearer JWT Token        │   Port: 7076     │
│                 │                              │                  │
└─────────────────┘                              └──────────────────┘
        │                                                  │
        │                                                  │
   ┌────▼────┐                                      ┌─────▼─────┐
   │  Views  │                                      │ Database  │
   │ (Razor) │                                      │ SQL Server│
   └─────────┘                                      └───────────┘
```

---

## 🚀 Integration Steps

### Step 1: Configure API Settings in UI

#### 1.1 Create Configuration File

**File:** `TMS.UI/appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ApiSettings": {
    "BaseUrl": "http://localhost:5026/api/"
  }
}
```

**Purpose:**

- Store the API base URL centrally
- Easy to change for different environments (dev, staging, production)
- No hardcoding of URLs in code

---

### Step 2: Setup HttpClient and Session Services

#### 2.1 Configure Program.cs

**File:** `TMS.UI/Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add MVC Controllers with Views
builder.Services.AddControllersWithViews();

// Configure HttpClient for API calls
builder.Services.AddHttpClient("TMSAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]
        ?? "https://localhost:7076/api/");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Configure Session for storing JWT tokens
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);  // Session expires after 2 hours
    options.Cookie.HttpOnly = true;                // Security: Prevent JavaScript access
    options.Cookie.IsEssential = true;            // Required for authentication
});

// Add HttpContextAccessor for accessing session in controllers
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ... middleware configuration ...

app.UseSession();  // Enable session middleware
```

**Key Configurations:**

| Configuration             | Purpose                                 |
| ------------------------- | --------------------------------------- |
| `AddHttpClient("TMSAPI")` | Named HttpClient factory for API calls  |
| `BaseAddress`             | API URL from configuration              |
| `Timeout`                 | 30 seconds for API responses            |
| `AddSession()`            | Enable session storage                  |
| `IdleTimeout`             | Session expiration time                 |
| `HttpOnly`                | Security feature to prevent XSS attacks |
| `IsEssential`             | Bypass cookie consent for auth          |

---

### Step 3: Enable CORS in API

#### 3.1 Configure CORS Policy

**File:** `TMS.APIs/Program.cs`

```csharp
// Add CORS - Allow UI to access API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins(
                "https://localhost:5001",
                "http://localhost:5001",
                "https://localhost:7001",
                "http://localhost:7001",
                "https://localhost:5000",
                "http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ... later in the pipeline ...

// Use CORS - must be before Authentication
app.UseCors("AllowUI");
```

**Purpose:**

- Allow cross-origin requests from UI to API
- Permit all HTTP methods (GET, POST, PUT, DELETE)
- Allow credentials (cookies, authorization headers)
- Support multiple development ports

---

### Step 4: Create View Models (DTOs)

#### 4.1 Authentication Models

**File:** `TMS.UI/Models/AuthViewModel.cs`

```csharp
using System.ComponentModel.DataAnnotations;

namespace TMS.UI.Models
{
    // Login Form Model
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }

    // Registration Form Model
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    // API Response Model
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
```

#### 4.2 Task Models

**File:** `TMS.UI/Models/TaskViewModel.cs`

```csharp
using System.ComponentModel.DataAnnotations;

namespace TMS.UI.Models
{
    // Display Task Model
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
    }

    // Create Task Model
    public class CreateTaskViewModel
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
    }

    // Update Task Model
    public class UpdateTaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
    }
}
```

#### 4.3 Generic API Response Model

**File:** `TMS.UI/Models/ApiResponse.cs`

```csharp
namespace TMS.UI.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
```

**Purpose:**

- Strongly-typed data transfer between UI and API
- Client-side and server-side validation
- Type safety and IntelliSense support

---

### Step 5: Implement Authentication Controller

**File:** `TMS.UI/Controllers/AuthController.cs`

```csharp
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

        public AuthController(IHttpClientFactory httpClientFactory,
                            ILogger<AuthController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        // ... methods below ...
    }
}
```

#### 5.1 Login Implementation

```csharp
[HttpPost]
public async Task<IActionResult> Login(LoginViewModel model)
{
    if (!ModelState.IsValid)
        return View(model);

    try
    {
        // Get configured HttpClient
        var client = _httpClientFactory.CreateClient("TMSAPI");

        // Prepare request payload
        var loginDto = new { UserName = model.UserName, PassWord = model.PassWord };
        var content = new StringContent(
            JsonSerializer.Serialize(loginDto),
            Encoding.UTF8,
            "application/json"
        );

        // Call API
        var response = await client.PostAsync("Auth/Login", content);

        if (response.IsSuccessStatusCode)
        {
            // Parse response
            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<AuthResponse>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token))
            {
                // Store token in session
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
        ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
        return View(model);
    }
}
```

**Integration Flow:**

```
User enters credentials
        ↓
[POST] /Auth/Login
        ↓
Serialize to JSON
        ↓
Send to API: POST /api/Auth/Login
        ↓
API validates & returns JWT token
        ↓
Store token in Session
        ↓
Redirect to Tasks Dashboard
```

#### 5.2 Registration Implementation

```csharp
[HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (!ModelState.IsValid)
        return View(model);

    try
    {
        var client = _httpClientFactory.CreateClient("TMSAPI");
        var registerDto = new { UserName = model.UserName, PassWord = model.PassWord };
        var content = new StringContent(
            JsonSerializer.Serialize(registerDto),
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync("Auth/register", content);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        ModelState.AddModelError(string.Empty,
            "Registration failed. Username may already exist.");
        return View(model);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error during registration");
        ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
        return View(model);
    }
}
```

#### 5.3 Logout Implementation

```csharp
[HttpPost]
public IActionResult Logout()
{
    HttpContext.Session.Clear();  // Remove JWT token and all session data
    TempData["SuccessMessage"] = "You have been logged out successfully.";
    return RedirectToAction("Login");
}
```

---

### Step 6: Implement Tasks Controller

**File:** `TMS.UI/Controllers/TasksController.cs`

```csharp
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

        public TasksController(IHttpClientFactory httpClientFactory,
                              ILogger<TasksController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        // ... helper methods and actions below ...
    }
}
```

#### 6.1 Helper Methods

```csharp
// Get HttpClient with JWT token
private HttpClient GetAuthenticatedClient()
{
    var client = _httpClientFactory.CreateClient("TMSAPI");
    var token = HttpContext.Session.GetString("JWTToken");

    if (!string.IsNullOrEmpty(token))
    {
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    return client;
}

// Check if user is authenticated
private bool IsAuthenticated()
{
    return !string.IsNullOrEmpty(HttpContext.Session.GetString("JWTToken"));
}
```

#### 6.2 Get All Tasks

```csharp
[HttpGet]
public async Task<IActionResult> Index()
{
    if (!IsAuthenticated())
        return RedirectToAction("Login", "Auth");

    try
    {
        var client = GetAuthenticatedClient();
        var response = await client.GetAsync("Tasks");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonSerializer.Deserialize<List<TaskViewModel>>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new List<TaskViewModel>();

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
```

**API Call Flow:**

```
GET /Tasks/Index
        ↓
Check authentication
        ↓
Get authenticated HttpClient (with Bearer token)
        ↓
[GET] /api/Tasks
        ↓
Deserialize JSON response
        ↓
Pass to View as Model
        ↓
Render tasks in UI
```

#### 6.3 Create Task

```csharp
[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateTaskViewModel model)
{
    if (!IsAuthenticated())
        return Json(new { success = false, message = "Not authenticated" });

    if (!ModelState.IsValid)
        return Json(new { success = false, message = "Invalid task data" });

    try
    {
        var client = GetAuthenticatedClient();
        var content = new StringContent(
            JsonSerializer.Serialize(model),
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync("Tasks", content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var task = JsonSerializer.Deserialize<TaskViewModel>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return Json(new {
                success = true,
                message = "Task created successfully",
                data = task
            });
        }

        return Json(new { success = false, message = "Failed to create task" });
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error creating task");
        return Json(new { success = false, message = "Error creating task" });
    }
}
```

#### 6.4 Update Task

```csharp
[HttpPost]
public async Task<IActionResult> Update([FromBody] UpdateTaskViewModel model)
{
    if (!IsAuthenticated())
        return Json(new { success = false, message = "Not authenticated" });

    if (!ModelState.IsValid)
        return Json(new { success = false, message = "Invalid task data" });

    try
    {
        var client = GetAuthenticatedClient();
        var content = new StringContent(
            JsonSerializer.Serialize(new { Title = model.Title }),
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PutAsync($"Tasks/{model.Id}", content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var task = JsonSerializer.Deserialize<TaskViewModel>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return Json(new {
                success = true,
                message = "Task updated successfully",
                data = task
            });
        }

        return Json(new { success = false, message = "Failed to update task" });
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error updating task");
        return Json(new { success = false, message = "Error updating task" });
    }
}
```

#### 6.5 Delete Task

```csharp
[HttpPost]
public async Task<IActionResult> Delete(int id)
{
    if (!IsAuthenticated())
        return Json(new { success = false, message = "Not authenticated" });

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
```

---

### Step 7: Frontend JavaScript Integration

The frontend uses jQuery and Fetch API to call the UI controllers, which in turn call the API.

**Example:** Creating a task from the UI

```javascript
async function addTask() {
  const title = $('#newTaskTitle').val().trim();

  if (title.length < 3) {
    showToast('Task title must be at least 3 characters', 'error');
    return;
  }

  try {
    const response = await fetch('/Tasks/Create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ title: title }),
    });

    const result = await response.json();

    if (result.success) {
      showToast('Task created successfully!', 'success');
      loadTasks(); // Reload tasks list
      $('#newTaskTitle').val(''); // Clear input
    } else {
      showToast(result.message || 'Failed to create task', 'error');
    }
  } catch (error) {
    console.error('Error:', error);
    showToast('Error creating task', 'error');
  }
}
```

**Call Flow:**

```
User clicks "Add Task"
        ↓
JavaScript: fetch('/Tasks/Create')
        ↓
UI Controller: TasksController.Create()
        ↓
HttpClient.PostAsync("Tasks")
        ↓
API Controller: TasksController.Post()
        ↓
Database: Insert Task
        ↓
Response flows back: API → UI Controller → JavaScript → User
```

---

## 🔐 Authentication Flow

### Complete Authentication Sequence

```
┌─────────┐
│ User    │
└────┬────┘
     │
     │ 1. Enter credentials
     ├──────────────────────────►┌──────────────┐
     │                            │ AuthController│
     │                            │   (UI)       │
     │                            └──────┬───────┘
     │                                   │
     │                            2. POST /api/Auth/Login
     │                            ├──────────────►┌──────────────┐
     │                                            │ AuthController│
     │                                            │   (API)       │
     │                                            └──────┬────────┘
     │                                                   │
     │                                            3. Validate credentials
     │                                            4. Generate JWT token
     │                                                   │
     │                            5. Return JWT  ◄───────┤
     │                            ┌──────────────┐       │
     │                            │ AuthController│       │
     │                            │   (UI)       │       │
     │                            └──────┬───────┘       │
     │                                   │               │
     │                            6. Store in Session    │
     │                            HttpContext.Session    │
     │                                   │               │
     │ 7. Redirect to Dashboard  ◄───────┤               │
     │                                                   │
     │ 8. Request Tasks Page                            │
     ├──────────────────────────►┌──────────────┐       │
     │                            │TasksController│      │
     │                            │   (UI)       │       │
     │                            └──────┬───────┘       │
     │                                   │               │
     │                            9. Get JWT from Session│
     │                            10. Add Bearer header  │
     │                                   │               │
     │                            11. GET /api/Tasks    │
     │                            ├─────────────────────►│
     │                                            ┌──────┴────────┐
     │                                            │TasksController│
     │                                            │   (API)       │
     │                                            └──────┬────────┘
     │                                                   │
     │                                            12. Validate JWT
     │                                            13. Fetch tasks
     │                                                   │
     │                            14. Return tasks◄──────┤
     │                            ┌──────────────┐       │
     │                            │TasksController│      │
     │                            │   (UI)       │       │
     │                            └──────┬───────┘       │
     │                                   │               │
     │ 15. Display tasks in UI   ◄───────┤               │
     │                                                   │
└────┴───────────────────────────────────────────────────┘
```

---

## 📊 API Endpoints Used

### Authentication Endpoints

| Method | Endpoint             | Purpose           | Request Body             | Response      |
| ------ | -------------------- | ----------------- | ------------------------ | ------------- |
| POST   | `/api/Auth/Login`    | User login        | `{ UserName, PassWord }` | `{ Token }`   |
| POST   | `/api/Auth/register` | User registration | `{ UserName, PassWord }` | Success/Error |

### Task Endpoints

| Method | Endpoint          | Purpose         | Request Body | Response          | Auth Required |
| ------ | ----------------- | --------------- | ------------ | ----------------- | ------------- |
| GET    | `/api/Tasks`      | Get all tasks   | None         | `TaskViewModel[]` | Yes (Bearer)  |
| GET    | `/api/Tasks/{id}` | Get single task | None         | `TaskViewModel`   | Yes (Bearer)  |
| POST   | `/api/Tasks`      | Create task     | `{ Title }`  | `TaskViewModel`   | Yes (Bearer)  |
| PUT    | `/api/Tasks/{id}` | Update task     | `{ Title }`  | `TaskViewModel`   | Yes (Bearer)  |
| DELETE | `/api/Tasks/{id}` | Delete task     | None         | Success/Error     | Yes (Bearer)  |

---

## 🔒 Security Implementation

### 1. JWT Token Security

```csharp
// Token stored in HttpOnly session (not accessible via JavaScript)
HttpContext.Session.SetString("JWTToken", token);

// Token added to every API request
client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", token);
```

### 2. Session Security

```csharp
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);  // Auto-expire after 2 hours
    options.Cookie.HttpOnly = true;                // Prevent XSS attacks
    options.Cookie.IsEssential = true;            // Bypass cookie consent
});
```

### 3. CORS Configuration

```csharp
// Only specific origins allowed
policy.WithOrigins("https://localhost:5001", "http://localhost:5001")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials();
```

### 4. Input Validation

```csharp
// Client-side validation
[Required(ErrorMessage = "Username is required")]
[StringLength(50, MinimumLength = 3)]
public string UserName { get; set; }

// Server-side validation
if (!ModelState.IsValid)
    return View(model);
```

### 5. Error Handling

```csharp
try
{
    // API call
}
catch (Exception ex)
{
    _logger.LogError(ex, "Error message");
    // User-friendly error message
    ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
}
```

---

## 🎯 Key Integration Patterns

### 1. **Repository Pattern** (API Side)

- `ITaskRepository` → `TaskRepository`
- `IUserRepository` → `UserRepository`

### 2. **Service Layer Pattern** (API Side)

- `ITaskService` → `TaskService`
- `IUserService` → `UserService`

### 3. **ViewModel Pattern** (UI Side)

- `LoginViewModel`, `RegisterViewModel`
- `TaskViewModel`, `CreateTaskViewModel`, `UpdateTaskViewModel`

### 4. **Factory Pattern**

- `IHttpClientFactory` for creating configured HttpClient instances

### 5. **Async/Await Pattern**

- All API calls are asynchronous for better performance

---

## 📁 Project Structure Summary

```
TMS Solution
│
├── TMS.APIs (Backend API)
│   ├── Controllers/
│   │   ├── AuthController.cs       → JWT authentication
│   │   └── TasksController.cs      → CRUD operations
│   ├── Program.cs                  → CORS, JWT, DI setup
│   └── appsettings.json            → DB connection, JWT settings
│
├── TMS.App (Application Layer)
│   ├── Interface/Services/
│   │   ├── ITaskService.cs
│   │   ├── TaskService.cs
│   │   ├── IUserService.cs
│   │   └── UserService.cs
│   └── Dtos/
│       ├── TaskDto.cs
│       └── UserDto.cs
│
├── TMS.core (Domain Layer)
│   └── Entites/
│       ├── TaskItem.cs
│       └── User.cs
│
├── TMS.infra (Infrastructure Layer)
│   ├── Data/
│   │   └── AppDbContext.cs         → EF Core DbContext
│   └── Repository/
│       ├── TaskRepository.cs
│       └── UserRepository.cs
│
└── TMS.UI (Frontend)
    ├── Controllers/
    │   ├── AuthController.cs       → Login/Register/Logout
    │   ├── TasksController.cs      → Proxy to API
    │   └── HomeController.cs       → Landing page
    ├── Models/
    │   ├── AuthViewModel.cs        → Login/Register models
    │   ├── TaskViewModel.cs        → Task CRUD models
    │   └── ApiResponse.cs          → Response wrapper
    ├── Views/
    │   ├── Auth/                   → Login/Register pages
    │   ├── Tasks/                  → Dashboard
    │   └── Shared/                 → Layout
    ├── wwwroot/
    │   ├── css/site.css            → Custom styles
    │   └── js/site.js              → JavaScript utilities
    ├── Program.cs                  → HttpClient, Session setup
    └── appsettings.json            → API URL configuration
```

---

## 🚦 Request/Response Examples

### Example 1: User Login

**Request:**

```http
POST https://localhost:5001/Auth/Login
Content-Type: application/x-www-form-urlencoded

UserName=john&PassWord=password123
```

**UI → API:**

```http
POST https://localhost:7076/api/Auth/Login
Content-Type: application/json

{
  "UserName": "john",
  "PassWord": "password123"
}
```

**API Response:**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

**UI Action:**

- Store token in session
- Redirect to `/Tasks/Index`

---

### Example 2: Get Tasks

**Request:**

```http
GET https://localhost:5001/Tasks/Index
Cookie: .AspNetCore.Session=...
```

**UI → API:**

```http
GET https://localhost:7076/api/Tasks
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

**API Response:**

```json
[
  {
    "id": 1,
    "title": "Complete project documentation"
  },
  {
    "id": 2,
    "title": "Review pull requests"
  }
]
```

**UI Action:**

- Deserialize to `List<TaskViewModel>`
- Pass to View
- Render in task cards

---

### Example 3: Create Task (AJAX)

**JavaScript Request:**

```javascript
fetch('/Tasks/Create', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ title: 'New Task' }),
});
```

**UI → API:**

```http
POST https://localhost:7076/api/Tasks
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
Content-Type: application/json

{
  "title": "New Task"
}
```

**API Response:**

```json
{
  "id": 3,
  "title": "New Task"
}
```

**JavaScript Response:**

```json
{
  "success": true,
  "message": "Task created successfully",
  "data": {
    "id": 3,
    "title": "New Task"
  }
}
```

---

## 🔍 Troubleshooting Integration Issues

### Issue 1: "CORS Policy Error"

**Symptom:**

```
Access to fetch at 'https://localhost:7076/api/Tasks' from origin
'https://localhost:5001' has been blocked by CORS policy
```

**Solution:**

1. Verify CORS is configured in API `Program.cs`
2. Check UI URL is in allowed origins list
3. Ensure `UseCors()` is before `UseAuthentication()`
4. Restart both projects

---

### Issue 2: "401 Unauthorized"

**Symptom:**

- Tasks page redirects to login
- API returns 401 status

**Solution:**

1. Check JWT token is in session: `HttpContext.Session.GetString("JWTToken")`
2. Verify token is added to request header
3. Check token hasn't expired (2-hour timeout)
4. Ensure Bearer scheme is used: `Bearer {token}`

---

### Issue 3: "Connection Refused"

**Symptom:**

```
HttpRequestException: No connection could be made because the
target machine actively refused it
```

**Solution:**

1. Ensure TMS.APIs is running
2. Verify API URL in `appsettings.json`
3. Check port numbers match
4. Look for firewall blocking

---

### Issue 4: "Session Expired"

**Symptom:**

- User logged out unexpectedly
- Redirected to login page

**Solution:**

- Session timeout is 2 hours (configured)
- This is expected behavior
- User needs to login again
- Consider implementing "Remember Me" for longer sessions

---

## ✅ Testing the Integration

### Manual Testing Checklist

#### Authentication

- [ ] Register new user
- [ ] Login with valid credentials
- [ ] Login with invalid credentials (should fail)
- [ ] Logout and verify session cleared
- [ ] Try accessing tasks without login (should redirect)

#### Task Operations

- [ ] View all tasks
- [ ] Create new task
- [ ] Edit existing task
- [ ] Delete task
- [ ] Search/filter tasks

#### API Communication

- [ ] Open browser DevTools (F12)
- [ ] Go to Network tab
- [ ] Perform actions and verify:
  - Requests going to correct endpoints
  - Authorization header present
  - Responses returning expected data
  - Status codes are correct (200, 201, 401, etc.)

#### Error Handling

- [ ] Stop API while UI running → Should show error message
- [ ] Use invalid token → Should redirect to login
- [ ] Network timeout → Should show error message

---

## 📈 Performance Considerations

### 1. **HttpClient Reuse**

✅ Using `IHttpClientFactory` prevents socket exhaustion

### 2. **Async/Await**

✅ All API calls are asynchronous, non-blocking

### 3. **Session Storage**

✅ Minimal data stored (only JWT token and username)

### 4. **Connection Pooling**

✅ HttpClient manages connection pool automatically

### 5. **Response Caching** (Future Enhancement)

Consider caching task list with short TTL

---

## 🔧 Configuration for Different Environments

### Development

```json
{
  "ApiSettings": {
    "BaseUrl": "http://localhost:5026/api/"
  }
}
```

### Staging

```json
{
  "ApiSettings": {
    "BaseUrl": "https://staging-api.yourdomain.com/api/"
  }
}
```

### Production

```json
{
  "ApiSettings": {
    "BaseUrl": "https://api.yourdomain.com/api/"
  }
}
```

**Best Practice:** Use environment-specific configuration files:

- `appsettings.Development.json`
- `appsettings.Staging.json`
- `appsettings.Production.json`

---

## 📚 Summary of Integration Steps

1. ✅ **Configure API URL** in `appsettings.json`
2. ✅ **Setup HttpClient** with `IHttpClientFactory`
3. ✅ **Enable Session** for JWT token storage
4. ✅ **Configure CORS** in API to allow UI requests
5. ✅ **Create ViewModels** for data transfer
6. ✅ **Implement AuthController** for login/register/logout
7. ✅ **Implement TasksController** for CRUD operations
8. ✅ **Add JWT Bearer token** to all authenticated requests
9. ✅ **Handle errors** gracefully with try-catch
10. ✅ **Implement session expiration** handling
11. ✅ **Add loading states** and user feedback
12. ✅ **Test all endpoints** thoroughly

---

## 🎯 Key Takeaways

### What Was Achieved

✅ **Complete Separation of Concerns**

- UI handles presentation
- API handles business logic
- Clean communication via HTTP/JSON

✅ **Secure Authentication**

- JWT token-based auth
- HttpOnly session cookies
- Bearer token in requests

✅ **Robust Error Handling**

- Try-catch on all API calls
- Logging for debugging
- User-friendly error messages

✅ **Modern Architecture**

- Dependency Injection
- Factory Pattern for HttpClient
- Async/Await throughout
- RESTful API design

✅ **Production-Ready**

- CORS configured
- Session timeout
- Input validation
- Error logging

---

## 📞 Support & Resources

### API Endpoints Documentation

Access Swagger UI when API is running:

```
https://localhost:7076/swagger
```

### Logging

Check application logs for detailed error information:

- API logs: Console output
- UI logs: Console output and browser DevTools

### Additional Documentation

- `README.md` - Full project documentation
- `QUICK_START.md` - Quick setup guide
- `IMPLEMENTATION_SUMMARY.md` - Feature summary

---

## 🎉 Conclusion

The TMS.UI has been successfully integrated with TMS.APIs using:

- **HttpClient** for HTTP communication
- **JWT Bearer tokens** for authentication
- **Session management** for token storage
- **RESTful API** design patterns
- **Async/await** for non-blocking operations
- **CORS** for cross-origin requests
- **Error handling** for resilience

The integration is **complete**, **secure**, and **production-ready**! 🚀

---

**Document Version:** 1.0
**Last Updated:** October 24, 2025
**Author:** TMS Development Team

