# 🎓 API Authentication Lecture Demo Guide

## Overview

This guide explains how to demonstrate API integration with and without authentication tokens for educational purposes. It's designed to help students understand the difference between public and protected API endpoints.

---

## 📚 Table of Contents

1. [Prerequisites](#prerequisites)
2. [Architecture Overview](#architecture-overview)
3. [Part 1: Public Endpoints (No Token)](#part-1-public-endpoints-no-token)
4. [Part 2: Protected Endpoints (With Token)](#part-2-protected-endpoints-with-token)
5. [Running the Demo](#running-the-demo)
6. [Key Concepts Explained](#key-concepts-explained)

---

## Prerequisites

Before starting the demo, ensure:

- ✅ TMS.APIs project is running (API backend)
- ✅ TMS.UI project is running (Web frontend)
- ✅ Database is set up and migrations are applied
- ✅ At least one user account exists (for authentication demo)

---

## Architecture Overview

```
┌─────────────┐                    ┌─────────────┐
│             │   HTTP Requests    │             │
│   Browser   │ ──────────────────>│   UI (MVC)  │
│  (Student)  │<────────────────── │             │
│             │   HTML Response    │             │
└─────────────┘                    └──────┬──────┘
                                          │
                                          │ HTTP Requests
                                          │ (with/without token)
                                          │
                                   ┌──────▼──────┐
                                   │             │
                                   │  API (.NET) │
                                   │             │
                                   └──────┬──────┘
                                          │
                                   ┌──────▼──────┐
                                   │  Database   │
                                   │ (SQL Server)│
                                   └─────────────┘
```

---

## Part 1: Public Endpoints (No Token)

### Why Public Endpoints?

**Purpose**: To demonstrate that some API endpoints are accessible to anyone without authentication.

**Real-world examples**:

- Reading blog posts
- Viewing product listings
- Getting public information

### Step 1: GET Data Without Token

#### What Happens:

1. **Browser** → Clicks "Get All Tasks (Public)" button
2. **UI Controller** → Creates HTTP request WITHOUT adding token
3. **API** → Receives request on `/api/Demo/public/tasks`
4. **API** → No `[Authorize]` attribute, so it proceeds
5. **API** → Returns data to UI
6. **UI** → Displays data to user

#### Code Flow:

**Frontend (JavaScript)**:

```javascript
async function getPublicData() {
  // Simple fetch - no token needed
  const response = await fetch('/Demo/GetPublicData');
  const result = await response.json();
}
```

**UI Controller (C#)**:

```csharp
public async Task<IActionResult> GetPublicData()
{
    // Create client WITHOUT token
    var client = _httpClientFactory.CreateClient("TMSAPI");

    // Call API - no authentication header
    var response = await client.GetAsync("Demo/public/tasks");

    return Json(result);
}
```

**API Controller (C#)**:

```csharp
// NO [Authorize] attribute = PUBLIC endpoint
[HttpGet("public/tasks")]
public async Task<ActionResult> GetPublicTasks()
{
    var tasks = await _taskService.GetAllTasks();
    return Ok(tasks);
}
```

#### Key Teaching Points:

- ✅ **No Authorization header** needed
- ✅ **No [Authorize] attribute** on endpoint
- ✅ Anyone can access this data
- ⚠️ **Security concern**: Only use for truly public data

---

### Step 2: POST Data Without Token

#### What Happens:

1. **Browser** → User enters task title and clicks "Create Task (Public)"
2. **UI Controller** → Creates HTTP POST request with data, NO token
3. **API** → Receives request with data
4. **API** → No authentication check
5. **API** → Creates task in database
6. **API** → Returns created task
7. **UI** → Shows success message

#### Code Flow:

**Frontend (JavaScript)**:

```javascript
async function createPublicTask() {
  const title = document.getElementById('publicTaskTitle').value;

  // POST request with data but no token
  const response = await fetch('/Demo/CreatePublicData', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ title: title }),
  });
}
```

**UI Controller (C#)**:

```csharp
public async Task<IActionResult> CreatePublicData([FromBody] CreateTaskViewModel model)
{
    var client = _httpClientFactory.CreateClient("TMSAPI");

    // Serialize data to JSON
    var jsonContent = new StringContent(
        JsonSerializer.Serialize(model),
        Encoding.UTF8,
        "application/json"
    );

    // POST to API - no token
    var response = await client.PostAsync("Demo/public/tasks", jsonContent);

    return Json(result);
}
```

**API Controller (C#)**:

```csharp
[HttpPost("public/tasks")]
public async Task<ActionResult> CreatePublicTask(CreateTaskDto createTaskDto)
{
    // Validate data
    if (!ModelState.IsValid) return BadRequest(ModelState);

    // Create task without checking who created it
    var task = await _taskService.CreateTask(createTaskDto);

    return Ok(task);
}
```

#### Key Teaching Points:

- ✅ **POST requests** can also be public
- ✅ We send **data in JSON format**
- ✅ No authentication = can't track who created it
- ⚠️ **Security risk**: Anyone can create data

---

## Part 2: Protected Endpoints (With Token)

### Why Protected Endpoints?

**Purpose**: To demonstrate that sensitive operations require authentication.

**Real-world examples**:

- Deleting data
- Updating personal information
- Accessing private data

### Understanding JWT Tokens

**What is a JWT Token?**

- JWT = JSON Web Token
- A secure way to transmit information between parties
- Contains user information (claims) in encrypted format
- Has an expiration time

**Token Structure**:

```
Header.Payload.Signature
eyJhbGc...IUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

**Where does the token come from?**

1. User logs in with username/password
2. API validates credentials
3. API generates JWT token
4. Token is sent back to UI
5. UI stores token (in session/cookie)
6. UI sends token with every protected request

---

### Step 3: GET Data With Token

#### What Happens:

1. **Browser** → Clicks "Get All Tasks (Protected)"
2. **UI Controller** → Gets token from session
3. **UI Controller** → Adds token to Authorization header
4. **API** → Receives request with token
5. **API** → `[Authorize]` attribute validates token
6. **API** → Token is valid → proceeds
7. **API** → Returns data
8. **UI** → Displays data

#### Code Flow:

**Frontend (JavaScript)**:

```javascript
async function getProtectedData() {
  // Same as public endpoint from browser perspective
  // The magic happens in the backend
  const response = await fetch('/Demo/GetProtectedData');
  const result = await response.json();
}
```

**UI Controller (C#)**:

```csharp
public async Task<IActionResult> GetProtectedData()
{
    // STEP 1: Get token from session
    var token = HttpContext.Session.GetString("JWTToken");

    if (string.IsNullOrEmpty(token))
    {
        return Json(new {
            success = false,
            message = "No token found! Please login first."
        });
    }

    // STEP 2: Create HTTP client
    var client = _httpClientFactory.CreateClient("TMSAPI");

    // STEP 3: Add token to Authorization header
    // This is THE KEY DIFFERENCE from public endpoints!
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);

    // STEP 4: Call protected endpoint
    var response = await client.GetAsync("Demo/protected/tasks");

    // STEP 5: Handle response
    if (response.IsSuccessStatusCode)
    {
        return Json(new { success = true, data = content });
    }

    if (response.StatusCode == HttpStatusCode.Unauthorized)
    {
        return Json(new {
            success = false,
            message = "Token invalid or expired"
        });
    }
}
```

**API Controller (C#)**:

```csharp
// [Authorize] = This endpoint REQUIRES authentication
[Authorize]
[HttpGet("protected/tasks")]
public async Task<ActionResult> GetProtectedTasks()
{
    // If code reaches here, token is valid!

    // Get user information from token
    var username = User.Identity?.Name ?? "Unknown User";

    var tasks = await _taskService.GetAllTasks();

    return Ok(new {
        message = $"Success! Authenticated as: {username}",
        data = tasks
    });
}
```

#### Authorization Flow in Detail:

```
1. Request arrives with header:
   Authorization: Bearer eyJhbGc...IUzI1NiIsInR5cCI6IkpXVCJ9...

2. ASP.NET Core middleware intercepts:
   - Finds [Authorize] attribute
   - Extracts token from header
   - Validates token:
     ✓ Signature is correct?
     ✓ Token not expired?
     ✓ Issuer is correct?
     ✓ Audience is correct?

3. If valid:
   - User.Identity populated with claims
   - Request proceeds to controller

4. If invalid:
   - Returns 401 Unauthorized
   - Controller code never runs
```

#### Key Teaching Points:

- ✅ **Authorization header** format: `Bearer {token}`
- ✅ **[Authorize] attribute** enforces authentication
- ✅ Token contains **user information (claims)**
- ✅ API can identify **who made the request**
- ✅ **Automatic validation** by framework

---

### Step 4: DELETE Data With Token

#### What Happens:

1. **Browser** → User enters task ID and clicks "Delete Task"
2. **UI Controller** → Gets token from session
3. **UI Controller** → Adds token to DELETE request
4. **API** → Validates token
5. **API** → Deletes task
6. **API** → Returns success
7. **UI** → Shows confirmation

#### Code Flow:

**Frontend (JavaScript)**:

```javascript
async function deleteProtectedTask() {
  const taskId = document.getElementById('deleteTaskId').value;

  // DELETE request - token handled by backend
  const response = await fetch(`/Demo/DeleteProtectedData?id=${taskId}`, {
    method: 'DELETE',
  });
}
```

**UI Controller (C#)**:

```csharp
public async Task<IActionResult> DeleteProtectedData(int id)
{
    // Get token from session
    var token = HttpContext.Session.GetString("JWTToken");

    if (string.IsNullOrEmpty(token))
    {
        return Json(new {
            success = false,
            message = "Not authenticated"
        });
    }

    // Create client with token
    var client = _httpClientFactory.CreateClient("TMSAPI");
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);

    // Send DELETE request
    var response = await client.DeleteAsync($"Demo/protected/tasks/{id}");

    return Json(result);
}
```

**API Controller (C#)**:

```csharp
[Authorize] // Must be authenticated
[HttpDelete("protected/tasks/{id}")]
public async Task<ActionResult> DeleteProtectedTask(int id)
{
    // Get username from token claims
    var username = User.Identity?.Name ?? "Unknown User";

    // Delete task
    var result = await _taskService.DeleteTask(id);

    if (!result) return NotFound();

    return Ok(new {
        message = $"Task deleted by: {username}"
    });
}
```

#### Key Teaching Points:

- ✅ **Sensitive operations** require authentication
- ✅ **Track who performs actions** via token claims
- ✅ **Audit trail** possible with user information
- ✅ **Different HTTP verbs** (GET, POST, DELETE) all work with tokens

---

## Running the Demo

### Step-by-Step Lecture Flow:

#### 1. Introduction (5 minutes)

```
"Today we'll learn how APIs protect data. We'll see:
- Public endpoints (no login needed)
- Protected endpoints (login required)
- How JWT tokens work"
```

#### 2. Demo Part 1: Public Endpoints (10 minutes)

**Step 1**: Open browser to `/Demo`

```
"First, let's try accessing data WITHOUT logging in..."
```

**Action**: Click "Get All Tasks (Public)"

```
"See? We got the data! The API didn't ask who we are.
This works for public information like blog posts."
```

**Action**: Enter a task title and click "Create Task (Public)"

```
"We can even create data without logging in.
But notice: the API doesn't know WHO created this task.
This is a security problem for sensitive data!"
```

#### 3. Show the Code (5 minutes)

**Open**: `DemoController.cs` in API

```csharp
// Point out: NO [Authorize] attribute
[HttpGet("public/tasks")]
public async Task<ActionResult> GetPublicTasks()
{
    // Anyone can call this!
}
```

**Open**: `DemoController.cs` in UI

```csharp
// Point out: No token in request
var client = _httpClientFactory.CreateClient("TMSAPI");
var response = await client.GetAsync("Demo/public/tasks");
// ☝️ No Authorization header!
```

#### 4. Demo Part 2: Protected Endpoints (10 minutes)

**Step 1**: Try without login

```
"Now let's try the protected endpoint WITHOUT logging in..."
```

**Action**: Click "Get All Tasks (Protected)"

```
"Error! The API rejected us because we don't have a token.
This is good - it's protecting the data."
```

**Step 2**: Login

```
"Let's login to get a token..."
```

**Action**: Go to `/Auth/Login` and login

```
"When we login:
1. We send username/password
2. API validates them
3. API generates a JWT token
4. Token is saved in our session"
```

**Step 3**: Return to demo and try again

```
"Now we're logged in. Let's try the protected endpoint..."
```

**Action**: Click "Get All Tasks (Protected)"

```
"Success! Notice it says 'authenticated as [username]'.
The API knows WHO we are from the token."
```

**Action**: Click "Test Token"

```
"This shows what's inside the token - our username,
roles, and other information. This is encrypted so
it can't be tampered with."
```

#### 5. Show the Code (10 minutes)

**Open**: `DemoController.cs` in UI

```csharp
// Point out: Token is added to request
var token = HttpContext.Session.GetString("JWTToken");
client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", token);
//                                ☝️ Token goes here!
```

**Open**: `DemoController.cs` in API

```csharp
// Point out: [Authorize] attribute
[Authorize] // ☝️ This checks the token!
[HttpGet("protected/tasks")]
public async Task<ActionResult> GetProtectedTasks()
{
    // Only runs if token is valid
    var username = User.Identity?.Name;
    // ☝️ Username comes from token
}
```

**Open**: `Program.cs` in API

```csharp
// Point out: JWT authentication setup
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true, // ☝️ Token expires!
            ValidateIssuerSigningKey = true,
            // ... secret key used to validate signature
        };
    });
```

#### 6. Security Discussion (5 minutes)

**Explain Token Security**:

```
"Tokens are secure because:
1. ✅ Encrypted - can't be read by hackers
2. ✅ Signed - can't be modified
3. ✅ Expiring - only valid for limited time
4. ✅ Stateless - API doesn't store them

But remember:
⚠️ If someone steals your token, they can impersonate you
⚠️ Always use HTTPS to prevent token theft
⚠️ Tokens should expire quickly (1-24 hours)
```

#### 7. Q&A and Experimentation (5 minutes)

Let students:

- Try different endpoints
- Logout and see protected endpoints fail
- Look at network tab in browser DevTools
- See the Authorization header in requests

---

## Key Concepts Explained

### 1. Authentication vs Authorization

**Authentication** = "Who are you?"

- Process: Login with username/password
- Result: You get a token
- Example: Showing ID at entrance

**Authorization** = "What are you allowed to do?"

- Process: Token is checked for permissions/roles
- Result: Access granted or denied
- Example: VIP pass gives access to special areas

### 2. HTTP Request Headers

**What are headers?**

- Metadata sent with every HTTP request
- Like an envelope containing the letter (body)

**Authorization Header**:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
               ↑      ↑
               Type   Token
```

**Other common headers**:

- `Content-Type`: Format of data (e.g., `application/json`)
- `Accept`: Format you want back
- `Cookie`: Session information

### 3. JWT Token Structure

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9  ← Header (algorithm)
.
eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ  ← Payload (data)
.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c  ← Signature (validation)
```

**Payload contains**:

```json
{
  "sub": "12345", // Subject (user ID)
  "name": "John Doe", // Username
  "role": "Admin", // User role
  "exp": 1672531200, // Expiration timestamp
  "iss": "TMS Api", // Issuer
  "aud": "TMS Frontend" // Audience
}
```

### 4. CORS (Cross-Origin Resource Sharing)

**Why needed?**

- Browser security prevents websites from calling other websites
- Your UI (localhost:5001) and API (localhost:7001) are different origins

**Solution**:

```csharp
// In API Program.cs
builder.Services.AddCors(options => {
    options.AddPolicy("AllowUI", policy => {
        policy.WithOrigins("http://localhost:5001")
              .AllowAnyHeader()      // Allow all headers
              .AllowAnyMethod()      // Allow GET, POST, DELETE, etc.
              .AllowCredentials();   // Allow cookies/tokens
    });
});
```

### 5. HttpClient Best Practices

**Why use IHttpClientFactory?**

```csharp
// ❌ BAD: Creates new connection each time
using (var client = new HttpClient()) { }

// ✅ GOOD: Reuses connections
var client = _httpClientFactory.CreateClient("TMSAPI");
```

**Configuration**:

```csharp
// In UI Program.cs
builder.Services.AddHttpClient("TMSAPI", client => {
    client.BaseAddress = new Uri("https://localhost:7001/api/");
    client.Timeout = TimeSpan.FromSeconds(30);
});
```

---

## Troubleshooting Common Issues

### Issue 1: "401 Unauthorized" on Protected Endpoints

**Cause**: Token is missing, invalid, or expired

**Solutions**:

```
1. Check if user is logged in
   → HttpContext.Session.GetString("JWTToken")

2. Check if token is added to request
   → client.DefaultRequestHeaders.Authorization

3. Check token expiration
   → Token might have expired, login again

4. Check API authentication setup
   → Program.cs has AddAuthentication and UseAuthentication
```

### Issue 2: CORS Error

**Error**: "Access to fetch at 'API_URL' from origin 'UI_URL' has been blocked by CORS policy"

**Solution**:

```csharp
// In API Program.cs

// Add this BEFORE var app = builder.Build();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowUI", policy => {
        policy.WithOrigins("http://localhost:5001")  // UI URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add this AFTER var app = builder.Build();
// MUST be BEFORE UseAuthentication
app.UseCors("AllowUI");
app.UseAuthentication();
app.UseAuthorization();
```

### Issue 3: Can't see token in session

**Cause**: Session not configured

**Solution**:

```csharp
// In UI Program.cs
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// After var app = builder.Build();
app.UseSession(); // Before UseAuthentication
```

### Issue 4: API returns data but UI shows "undefined"

**Cause**: JSON property name mismatch

**Solution**:

```csharp
// In UI Controller
var result = JsonSerializer.Deserialize<TaskViewModel>(content,
    new JsonSerializerOptions {
        PropertyNameCaseInsensitive = true  // Ignore case
    });
```

---

## Assignment Ideas for Students

### Easy:

1. Add a "GET by ID" public endpoint
2. Add a "UPDATE" protected endpoint
3. Change the expiration time of tokens

### Medium:

4. Add role-based authorization (Admin only endpoint)
5. Create a "Register" flow and test the demo with new user
6. Add logging to track API calls

### Hard:

7. Implement refresh tokens (extend session without login)
8. Add rate limiting to prevent abuse
9. Implement API key authentication for service-to-service calls

---

## Additional Resources

### Documentation:

- [JWT.io](https://jwt.io/) - Decode and understand JWT tokens
- [ASP.NET Core Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)
- [HTTP Status Codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)

### Tools for Testing:

- **Postman**: Test API endpoints manually
- **Browser DevTools**: Network tab to see requests/responses
- **JWT Decoder**: See token contents (jwt.io)

---

## Summary

### What Students Learned:

1. **Public Endpoints**

   - Accessible without authentication
   - Use for non-sensitive data
   - Anyone can call them

2. **Protected Endpoints**

   - Require JWT token
   - Use `[Authorize]` attribute
   - API knows who is making request

3. **JWT Tokens**

   - Generated on login
   - Sent in Authorization header
   - Contains user information
   - Has expiration time

4. **Security Best Practices**
   - Only protect what needs protection
   - Always use HTTPS
   - Tokens should expire
   - Validate on server side

---

## Next Steps

After this demo, students should be able to:

- ✅ Create public API endpoints
- ✅ Create protected API endpoints
- ✅ Call APIs from UI with and without tokens
- ✅ Understand authentication flow
- ✅ Debug common issues

**Next topics to cover**:

- Role-based authorization
- Refresh tokens
- OAuth 2.0
- API versioning
- Rate limiting

---

## Questions for Discussion

1. **Why not make everything public?**

   - Security: Protect sensitive data
   - Privacy: Users' private information
   - Accountability: Know who did what

2. **Why not check username/password every time?**

   - Performance: Expensive to verify
   - Scalability: Database load
   - Security: Don't send password repeatedly

3. **What if someone steals my token?**

   - They can impersonate you until expiration
   - Use short expiration times
   - Always use HTTPS
   - Implement token revocation

4. **Can tokens be stored in LocalStorage?**
   - Yes, but less secure (XSS attacks)
   - Better: HTTP-only cookies or session
   - Trade-off: Security vs. convenience

---

_This guide was created for educational purposes to help students understand API authentication concepts._
