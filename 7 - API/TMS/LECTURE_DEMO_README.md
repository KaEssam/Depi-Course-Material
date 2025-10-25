# 🎓 Complete Lecture Demo Package - API Authentication

> **For Educators**: Everything you need to teach API authentication with JWT tokens

---

## 📦 What's Included

This demo package contains a complete, working example of API authentication for educational purposes. It demonstrates:

✅ **Public endpoints** (no authentication required)
✅ **Protected endpoints** (JWT token required)
✅ **Token generation** (login flow)
✅ **Token validation** (authorization flow)
✅ **Full-stack integration** (API + UI)

---

## 📚 Documentation Files

| File                       | Purpose                                        | Audience    |
| -------------------------- | ---------------------------------------------- | ----------- |
| **DEMO_QUICK_START.md**    | 5-minute setup guide                           | Students    |
| **LECTURE_DEMO_GUIDE.md**  | Complete teaching guide with code explanations | Instructors |
| **API_FLOW_DIAGRAMS.md**   | Visual diagrams for presentations              | Instructors |
| **LECTURE_DEMO_README.md** | This file - overview                           | Everyone    |

---

## 🚀 Quick Start for Instructors

### Before Class (5 minutes)

1. **Test the demo**

   ```bash
   # Terminal 1 - Start API
   cd TMS.APIs
   dotnet run

   # Terminal 2 - Start UI
   cd TMS.UI
   dotnet run
   ```

2. **Open in browser**: `https://localhost:5001/Demo`

3. **Test both flows**:

   - ✅ Public endpoints work without login
   - ✅ Protected endpoints require login

4. **Prepare visuals**: Open `API_FLOW_DIAGRAMS.md` for diagrams

---

## 📖 Suggested Lecture Flow (45 minutes)

### Part 1: Introduction (5 min)

```
"Today we'll learn how modern web applications protect data using JWT tokens."

Topics:
- What is authentication?
- What is authorization?
- Why do we need tokens?
```

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 6 (Security Comparison)

---

### Part 2: Demo - Public Endpoints (10 min)

**Live Demo**:

1. Open browser to `/Demo`
2. Click "Get All Tasks (Public)"
3. Show success - no login needed
4. Create a task without login

**Explain**:

- Public endpoints are accessible to everyone
- Good for: blog posts, product lists, public data
- Bad for: user data, sensitive operations

**Show Code**:

```csharp
// TMS.APIs/Controllers/DemoController.cs
// NO [Authorize] attribute = public
[HttpGet("public/tasks")]
public async Task<ActionResult> GetPublicTasks()
{
    var tasks = await _taskService.GetAllTasks();
    return Ok(tasks);
}
```

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 1 (Public Flow)

---

### Part 3: Demo - Protected Endpoints Failed (5 min)

**Live Demo**:

1. Try "Get All Tasks (Protected)" without login
2. Show error: "No token found"

**Explain**:

- Protected endpoints require authentication
- Without token = 401 Unauthorized
- This is good! It's protecting the data

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 2 (Protected Flow - Failed part)

---

### Part 4: Login & Get Token (10 min)

**Live Demo**:

1. Click "Login Now"
2. Enter credentials
3. Explain what happens:
   - Username & password sent to API
   - API validates credentials
   - API generates JWT token
   - Token saved in session

**Show Code**:

```csharp
// TMS.APIs/Controllers/AuthController.cs
public async Task<ActionResult<AuthResponse>> Login(LoginDto loginDto)
{
    // Validate user
    var user = await _userService.Authenticate(loginDto);

    // Generate JWT token
    var token = GenerateJwtToken(user);

    return Ok(new { token, username = user.Username });
}
```

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 3 (Login Flow)

**Explain Token**:

- Show `API_FLOW_DIAGRAMS.md` - Diagram 4 (Token Anatomy)
- Visit jwt.io and decode a token
- Show what's inside: username, roles, expiration

---

### Part 5: Demo - Protected Endpoints Success (10 min)

**Live Demo**:

1. Return to `/Demo`
2. Click "Get All Tasks (Protected)"
3. Show success - with username!
4. Delete a task

**Explain**:

- Token is automatically sent with request
- API validates token
- API knows who made the request
- Request proceeds

**Show Code**:

```csharp
// TMS.UI/Controllers/DemoController.cs
public async Task<IActionResult> GetProtectedData()
{
    // Get token from session
    var token = HttpContext.Session.GetString("JWTToken");

    // Add token to request header
    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);

    // Call API
    var response = await client.GetAsync("Demo/protected/tasks");
}
```

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 2 (Complete Protected Flow)

**Demo Browser DevTools**:

1. Press F12
2. Go to Network tab
3. Click protected endpoint
4. Show Authorization header with token

**Show**: `API_FLOW_DIAGRAMS.md` - Diagram 5 (HTTP Request Comparison)

---

### Part 6: Q&A and Experimentation (5 min)

Let students:

- Test endpoints themselves
- Look at code
- Ask questions
- Try breaking things (logout and retry)

---

## 🎯 Learning Objectives

By the end of this lecture, students should be able to:

### Understand:

- ✅ Difference between authentication and authorization
- ✅ What JWT tokens are and how they work
- ✅ Why tokens are better than sending username/password repeatedly
- ✅ What the `[Authorize]` attribute does
- ✅ How tokens are sent in HTTP headers

### Do:

- ✅ Create public API endpoints
- ✅ Create protected API endpoints with `[Authorize]`
- ✅ Call APIs from frontend with and without tokens
- ✅ Debug authentication issues using browser DevTools
- ✅ Read and understand JWT token contents

---

## 🔑 Key Teaching Points

### 1. Public vs Protected

```
PUBLIC endpoints:
✅ No [Authorize] attribute
✅ No token required
✅ Anyone can access
⚠️ Only for non-sensitive data

PROTECTED endpoints:
✅ Has [Authorize] attribute
✅ Token required
✅ Only authenticated users
✅ API knows WHO made request
```

### 2. Why JWT Tokens?

**Problem**: Sending username/password with every request

- ❌ Insecure (password sent many times)
- ❌ Slow (database check every time)
- ❌ Can't expire or revoke easily

**Solution**: JWT tokens

- ✅ Password sent only once (at login)
- ✅ Fast (no database check needed)
- ✅ Automatic expiration
- ✅ Can be revoked
- ✅ Contains user information

### 3. Token Flow

```
1. Login → Get Token
2. Store Token (session/cookie)
3. Send Token with requests
4. API validates Token
5. Token expires → Login again
```

### 4. Security Best Practices

Emphasize:

- ✅ Always use HTTPS (prevent token theft)
- ✅ Short expiration times (1-24 hours)
- ✅ Store tokens securely (HTTP-only cookies or session)
- ✅ Validate tokens on server side
- ❌ Never store passwords in tokens
- ❌ Never send tokens in URL parameters

---

## 🛠️ Demo Features

### API Endpoints (TMS.APIs/Controllers/DemoController.cs)

**Public Endpoints**:
| Method | URL | Description |
|--------|-----|-------------|
| GET | `/api/Demo/public/tasks` | Get all tasks (no auth) |
| POST | `/api/Demo/public/tasks` | Create task (no auth) |

**Protected Endpoints**:
| Method | URL | Description | Requires |
|--------|-----|-------------|----------|
| GET | `/api/Demo/protected/tasks` | Get all tasks | Token |
| DELETE | `/api/Demo/protected/tasks/{id}` | Delete task | Token |
| GET | `/api/Demo/protected/test-token` | Test token validity | Token |

### UI Features (TMS.UI/Controllers/DemoController.cs)

**Demo Page** (`/Demo/Index`):

- Visual separation of public vs protected
- Color-coded buttons (green = public, red = protected)
- Real-time results display
- Detailed explanations
- Token testing tool

---

## 💻 Technical Details

### Technology Stack

- **Backend API**: ASP.NET Core 8.0
- **Frontend UI**: ASP.NET Core MVC
- **Authentication**: JWT Bearer tokens
- **Database**: SQL Server (Entity Framework Core)

### Key Components

**API Configuration** (`TMS.APIs/Program.cs`):

```csharp
// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "TMS Api",
            ValidAudience = "TMS Frontend",
            IssuerSigningKey = new SymmetricSecurityKey(...)
        };
    });

// CORS for UI access
builder.Services.AddCors(options => {
    options.AddPolicy("AllowUI", policy => {
        policy.WithOrigins("http://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

**UI Configuration** (`TMS.UI/Program.cs`):

```csharp
// HTTP Client for API calls
builder.Services.AddHttpClient("TMSAPI", client => {
    client.BaseAddress = new Uri("https://localhost:7001/api/");
});

// Session for token storage
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
```

---

## 🎨 Teaching Tips

### For Visual Learners

- Use `API_FLOW_DIAGRAMS.md` diagrams
- Draw on whiteboard
- Show browser DevTools Network tab
- Decode tokens on jwt.io

### For Hands-On Learners

- Let them modify the code
- Have them create new endpoints
- Challenge them to add role-based auth
- Debug intentional errors together

### For Reading Learners

- Direct them to `LECTURE_DEMO_GUIDE.md`
- Share code comments
- Provide additional resources

### Common Student Questions

**Q: "Can't someone just copy my token?"**
A: Yes! That's why we use HTTPS (encrypted) and short expiration times. If someone steals your token, it's like stealing your key - they can use it until it expires.

**Q: "Where is the token stored?"**
A: In this demo, in session storage. In production, often in HTTP-only cookies (more secure) or session storage.

**Q: "What if I change the token?"**
A: Try it! The signature will be invalid and API will reject it. That's the beauty of JWT.

**Q: "Can I see what's in the token?"**
A: Yes! It's base64 encoded (not encrypted). Go to jwt.io and paste your token. But you can't modify it without breaking the signature.

**Q: "What happens when token expires?"**
A: API returns 401 Unauthorized. User must login again to get new token.

---

## 🐛 Troubleshooting

### Issue: "CORS error in browser"

**Fix**: Check API has CORS configured and is running

```csharp
// In TMS.APIs/Program.cs
app.UseCors("AllowUI"); // Before UseAuthentication
```

### Issue: "401 Unauthorized on protected endpoints"

**Check**:

1. User is logged in? (`Session["JWTToken"]` exists)
2. Token added to header? (`Authorization: Bearer ...`)
3. Token not expired?
4. API has authentication configured?

### Issue: "Can't access /Demo page"

**Check**:

1. UI is running? (`dotnet run` in TMS.UI)
2. Navigation link exists? (Check `_Layout.cshtml`)
3. Controller exists? (Check `TMS.UI/Controllers/DemoController.cs`)

---

## 📝 Assignment Ideas

### Easy (30 min)

1. Add a GET by ID public endpoint
2. Create a PUT (update) protected endpoint
3. Change token expiration time

### Medium (1-2 hours)

4. Add role-based authorization (`[Authorize(Roles = "Admin")]`)
5. Create registration flow for students
6. Add logging to track API calls

### Hard (2-4 hours)

7. Implement refresh tokens
8. Add rate limiting to prevent abuse
9. Create API documentation with Swagger annotations
10. Add password reset functionality

### Advanced (Project)

11. Build a complete mini-application with authentication
12. Implement OAuth 2.0 with Google/Facebook login
13. Add two-factor authentication (2FA)

---

## 📖 Additional Resources

### For Students

- [JWT.io](https://jwt.io/) - Decode and learn about tokens
- [MDN - HTTP Headers](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers)
- [REST API Tutorial](https://restfulapi.net/)

### For Instructors

- [Microsoft - ASP.NET Core Security](https://docs.microsoft.com/en-us/aspnet/core/security/)
- [OAuth 2.0 Simplified](https://aaronparecki.com/oauth-2-simplified/)
- [OWASP API Security Top 10](https://owasp.org/www-project-api-security/)

### Tools

- **Postman** - Test APIs manually
- **jwt.io** - Decode JWT tokens
- **Browser DevTools** - Inspect network requests
- **Swagger/OpenAPI** - API documentation

---

## 🔄 Extending the Demo

### Add More Features

1. **Role-Based Authorization**

```csharp
[Authorize(Roles = "Admin")]
[HttpDelete("admin/tasks/{id}")]
public async Task<ActionResult> AdminDeleteTask(int id)
{
    // Only admins can access
}
```

2. **Custom Claims**

```csharp
var claims = new[] {
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.Email, user.Email),
    new Claim("UserId", user.Id.ToString()),
    new Claim("Department", user.Department) // Custom claim
};
```

3. **Token Refresh**

```csharp
[HttpPost("refresh")]
public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
{
    // Validate refresh token
    // Generate new access token
    return Ok(new { token = newToken });
}
```

---

## ✅ Checklist for Instructors

Before class:

- [ ] Test demo on your machine
- [ ] API running on port 7001
- [ ] UI running on port 5001
- [ ] At least one test user exists
- [ ] Documentation files reviewed
- [ ] Diagrams ready to show
- [ ] Whiteboard/screen sharing ready

During class:

- [ ] Start with theory (5 min)
- [ ] Demo public endpoints (10 min)
- [ ] Explain JWT tokens (10 min)
- [ ] Demo protected endpoints (10 min)
- [ ] Show code (5 min)
- [ ] Q&A and experimentation (5 min)

After class:

- [ ] Share documentation with students
- [ ] Share demo code repository
- [ ] Assign homework/practice
- [ ] Available for questions

---

## 📞 Support

For questions or improvements to this demo:

1. Check `LECTURE_DEMO_GUIDE.md` for detailed explanations
2. Review code comments in controllers
3. Test endpoints in browser or Postman

---

## 🎉 Summary

This demo package provides:

✅ **Complete working example** of JWT authentication
✅ **Visual diagrams** for presentations
✅ **Detailed code comments** for learning
✅ **Step-by-step guides** for students and instructors
✅ **Real-world best practices** for API security

### Key Takeaways for Students:

1. **Public endpoints** = No authentication (anyone can access)
2. **Protected endpoints** = Require JWT token (only authenticated users)
3. **JWT tokens** = Secure way to authenticate API requests
4. **Token flow** = Login → Get token → Send with requests → Token validates
5. **Security** = Always HTTPS, short expiration, server-side validation

---

**Happy Teaching! 🎓**

_This demo was created for educational purposes to help students understand API authentication in a practical, hands-on way._
