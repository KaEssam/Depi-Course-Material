# 🎨 Visual API Flow Diagrams

## For Teaching: Show These Diagrams During Lecture

---

## Diagram 1: Public Endpoint Flow (No Token)

```
┌─────────────┐
│   Student   │
│  (Browser)  │
└──────┬──────┘
       │
       │ 1. Click "Get Public Data"
       ▼
┌─────────────┐
│  UI (MVC)   │
│  Controller │
└──────┬──────┘
       │
       │ 2. HTTP GET Request
       │    URL: /api/Demo/public/tasks
       │    Headers: { Content-Type: application/json }
       │    ⚠️ NO Authorization header!
       ▼
┌─────────────┐
│  API (.NET) │
│  Controller │
└──────┬──────┘
       │
       │ 3. Check endpoint...
       │    ✅ No [Authorize] attribute
       │    ✅ Anyone can access
       ▼
┌─────────────┐
│   Database  │
│ (SQL Server)│
└──────┬──────┘
       │
       │ 4. Fetch data
       ▼
┌─────────────┐
│   Response  │
│ { tasks: [] }│
└──────┬──────┘
       │
       │ 5. Return JSON
       ▼
┌─────────────┐
│   Browser   │
│ Shows Data  │
└─────────────┘

✅ SUCCESS: Data retrieved without authentication!
```

---

## Diagram 2: Protected Endpoint Flow (With Token)

```
┌─────────────┐
│   Student   │
│  (Browser)  │
└──────┬──────┘
       │
       │ 1. Click "Get Protected Data"
       ▼
┌─────────────┐
│  UI (MVC)   │
│  Controller │
└──────┬──────┘
       │
       │ 2. Get token from session
       │    token = Session["JWTToken"]
       │    🔑 Token: "eyJhbGc..."
       ▼
┌─────────────┐
│  Add Token  │
│  to Request │
└──────┬──────┘
       │
       │ 3. HTTP GET Request
       │    URL: /api/Demo/protected/tasks
       │    Headers: {
       │      Content-Type: application/json,
       │      Authorization: "Bearer eyJhbGc..."  ← TOKEN HERE!
       │    }
       ▼
┌─────────────────────┐
│   API Middleware    │
│ [Authorize] Check   │
└──────┬──────────────┘
       │
       │ 4. Validate Token
       │    ✓ Signature valid?
       │    ✓ Not expired?
       │    ✓ Issuer correct?
       │    ✓ Audience correct?
       │
       ├─── ❌ INVALID ──→ 401 Unauthorized → Browser shows error
       │
       └─── ✅ VALID
              │
              │ 5. Extract user info from token
              │    Username: "john.doe"
              │    Role: "User"
              ▼
       ┌─────────────┐
       │  API (.NET) │
       │  Controller │
       └──────┬──────┘
              │
              │ 6. User.Identity.Name = "john.doe"
              │    Proceed with request
              ▼
       ┌─────────────┐
       │   Database  │
       │ (SQL Server)│
       └──────┬──────┘
              │
              │ 7. Fetch data
              ▼
       ┌─────────────┐
       │   Response  │
       │{ tasks: [],  │
       │ user: "john" }│
       └──────┬──────┘
              │
              │ 8. Return JSON with user info
              ▼
       ┌─────────────┐
       │   Browser   │
       │ Shows Data  │
       └─────────────┘

✅ SUCCESS: Data retrieved with authentication!
API knows WHO made the request!
```

---

## Diagram 3: Login Flow (Getting a Token)

```
┌─────────────┐
│   Student   │
│  (Browser)  │
└──────┬──────┘
       │
       │ 1. Enter username & password
       │    Username: "john.doe"
       │    Password: "Password123!"
       ▼
┌─────────────┐
│  UI (MVC)   │
│Auth Controller│
└──────┬──────┘
       │
       │ 2. HTTP POST Request
       │    URL: /api/Auth/login
       │    Body: {
       │      "username": "john.doe",
       │      "password": "Password123!"
       │    }
       │    ⚠️ NO token yet (we're getting one!)
       ▼
┌─────────────┐
│  API (.NET) │
│Auth Controller│
└──────┬──────┘
       │
       │ 3. Validate credentials
       ▼
┌─────────────┐
│   Database  │
│  Check user │
└──────┬──────┘
       │
       │ 4. Is password correct?
       │
       ├─── ❌ NO ──→ 401 Unauthorized
       │
       └─── ✅ YES
              │
              │ 5. Generate JWT Token
              ▼
       ┌──────────────────────┐
       │   Token Generator    │
       │                      │
       │  Header: {           │
       │    "alg": "HS256",   │
       │    "typ": "JWT"      │
       │  }                   │
       │                      │
       │  Payload: {          │
       │    "sub": "123",     │ ← User ID
       │    "name": "john.doe"│ ← Username
       │    "role": "User",   │ ← Role
       │    "exp": 1234567890 │ ← Expiration
       │  }                   │
       │                      │
       │  + SECRET KEY        │
       │  = SIGNED TOKEN      │
       └──────┬───────────────┘
              │
              │ 6. Return token
              │    { "token": "eyJhbGc...",
              │      "username": "john.doe" }
              ▼
       ┌─────────────┐
       │  UI (MVC)   │
       │Save to Session│
       └──────┬──────┘
              │
              │ 7. Session["JWTToken"] = "eyJhbGc..."
              │    Session["Username"] = "john.doe"
              ▼
       ┌─────────────┐
       │   Browser   │
       │ Redirects to│
       │    Home     │
       └─────────────┘

✅ SUCCESS: User is now authenticated!
Token is saved and ready to use!
```

---

## Diagram 4: Token Anatomy

```
╔══════════════════════════════════════════════════════════════╗
║                       JWT TOKEN                              ║
╠══════════════════════════════════════════════════════════════╣
║  eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9                        ║  ← HEADER
║  .                                                            ║
║  eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIn0        ║  ← PAYLOAD
║  .                                                            ║
║  SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c                ║  ← SIGNATURE
╚══════════════════════════════════════════════════════════════╝

┌─────────────────────────────────────────────────────────────┐
│ HEADER (Base64 encoded)                                     │
├─────────────────────────────────────────────────────────────┤
│ {                                                           │
│   "alg": "HS256",     ← Encryption algorithm               │
│   "typ": "JWT"        ← Token type                          │
│ }                                                           │
└─────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────┐
│ PAYLOAD (Base64 encoded) - THE IMPORTANT PART!             │
├─────────────────────────────────────────────────────────────┤
│ {                                                           │
│   "sub": "12345",              ← Subject (User ID)          │
│   "name": "john.doe",          ← Username                   │
│   "email": "john@example.com", ← Email                      │
│   "role": "Admin",             ← User role                  │
│   "iat": 1516239022,           ← Issued at (timestamp)      │
│   "exp": 1516242622,           ← Expiration (timestamp)     │
│   "iss": "TMS Api",            ← Issuer (who created it)    │
│   "aud": "TMS Frontend"        ← Audience (who can use it)  │
│ }                                                           │
│                                                             │
│ ⚠️ This is NOT encrypted! Anyone can read it!              │
│ ✅ But it IS signed, so it can't be modified!              │
└─────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────┐
│ SIGNATURE (Encrypted with secret key)                      │
├─────────────────────────────────────────────────────────────┤
│ HMACSHA256(                                                 │
│   base64UrlEncode(header) + "." +                          │
│   base64UrlEncode(payload),                                │
│   "YOUR_SECRET_KEY" ← Only server knows this!              │
│ )                                                           │
│                                                             │
│ ✅ Proves token hasn't been tampered with                  │
│ ✅ Can only be created by someone with secret key          │
└─────────────────────────────────────────────────────────────┘
```

---

## Diagram 5: HTTP Request Comparison

### Public Request (No Token):

```
GET https://localhost:7001/api/Demo/public/tasks HTTP/1.1
Host: localhost:7001
Content-Type: application/json
Accept: application/json

                                     ⚠️ NO Authorization header!
```

### Protected Request (With Token):

```
GET https://localhost:7001/api/Demo/protected/tasks HTTP/1.1
Host: localhost:7001
Content-Type: application/json
Accept: application/json
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
               ↑      ↑
               │      └─ The JWT token
               └─ Auth type (Bearer)

                                     ✅ Authorization header with token!
```

---

## Diagram 6: Security Comparison

### ❌ BAD: Sending Password Every Time

```
Request 1: GET /tasks with username & password
Request 2: POST /task with username & password
Request 3: DELETE /task with username & password
...
Request 100: GET /tasks with username & password

Problems:
❌ Password sent 100 times (more chances to intercept)
❌ Database checked 100 times (slow!)
❌ If password changes, all apps break
❌ Can't expire or revoke access easily
```

### ✅ GOOD: Using JWT Token

```
Request 0: LOGIN with username & password
          ↓
     Get Token (expires in 1 hour)
          ↓
Request 1: GET /tasks with token
Request 2: POST /task with token
Request 3: DELETE /task with token
...
Request 100: GET /tasks with token

Benefits:
✅ Password sent only ONCE (secure!)
✅ No database check needed (fast!)
✅ Password can change, token still works
✅ Token expires automatically
✅ Token can be revoked if stolen
```

---

## Diagram 7: CORS Explained

### Without CORS (Blocked):

```
Browser at http://localhost:5001
    │
    │ 1. JavaScript tries to call API
    │    fetch('http://localhost:7001/api/tasks')
    ▼
Browser Security: "Wait! This is a different domain!"
    │
    │ 2. Check CORS policy...
    │    Origin: http://localhost:5001
    │    Target: http://localhost:7001
    │    ⚠️ Different port = Different origin!
    ▼
API doesn't have CORS configured
    │
    ▼
❌ BLOCKED! Browser shows:
"Access to fetch at 'http://localhost:7001/api/tasks'
from origin 'http://localhost:5001' has been blocked by CORS policy"
```

### With CORS (Allowed):

```
Browser at http://localhost:5001
    │
    │ 1. JavaScript tries to call API
    │    fetch('http://localhost:7001/api/tasks')
    ▼
Browser Security: "Wait! This is a different domain!"
    │
    │ 2. Send preflight request (OPTIONS)
    ▼
API with CORS configured:
    AddCors(options => {
        options.AddPolicy("AllowUI", policy => {
            policy.WithOrigins("http://localhost:5001")  ✅
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
    │
    │ 3. API responds: "Yes, localhost:5001 is allowed!"
    ▼
Browser: "OK, I'll allow it!"
    │
    │ 4. Send actual request
    ▼
✅ SUCCESS! Data returned to browser
```

---

## Diagram 8: Complete Application Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                         BROWSER                             │
│  ┌────────────┐  ┌────────────┐  ┌────────────┐           │
│  │   HTML     │  │    CSS     │  │ JavaScript │           │
│  │  (Views)   │  │  (Styles)  │  │  (Logic)   │           │
│  └────────────┘  └────────────┘  └────────────┘           │
└─────────────┬───────────────────────────────────────────────┘
              │ HTTP Requests (HTML pages)
              ▼
┌─────────────────────────────────────────────────────────────┐
│                      TMS.UI (MVC)                           │
│                    Port: 5001/7001                          │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Controllers (C#)                                      │  │
│  │  - DemoController    → Demo page                     │  │
│  │  - AuthController    → Login/Register                │  │
│  │  - TasksController   → Task management               │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ Views (Razor .cshtml)                                │  │
│  │  - Index.cshtml      → Demo page HTML                │  │
│  │  - Login.cshtml      → Login form                    │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ Models (C#)                                          │  │
│  │  - TaskViewModel     → Task data structure           │  │
│  │  - AuthViewModel     → Login/Register data           │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────┬───────────────────────────────────────────────┘
              │ HTTP Requests (JSON)
              │ with/without JWT Token
              ▼
┌─────────────────────────────────────────────────────────────┐
│                    TMS.APIs (.NET)                          │
│                   Port: 7001/5173                           │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Middleware Pipeline                                   │  │
│  │  1. CORS          → Check if origin is allowed       │  │
│  │  2. Authentication → Validate JWT token              │  │
│  │  3. Authorization  → Check user permissions          │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ Controllers (API)                                     │  │
│  │  - DemoController     → Public & Protected endpoints │  │
│  │  - AuthController     → Login & Register             │  │
│  │  - TasksController    → CRUD operations              │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ Services (Business Logic)                            │  │
│  │  - TaskService → Task operations                     │  │
│  │  - UserService → User & auth operations              │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ Repositories (Data Access)                           │  │
│  │  - TaskRepository → Database queries for tasks       │  │
│  │  - UserRepository → Database queries for users       │  │
│  └──────────┬───────────────────────────────────────────┘  │
│             │                                               │
│  ┌──────────▼───────────────────────────────────────────┐  │
│  │ DbContext (Entity Framework)                         │  │
│  │  - AppDbContext → Database connection & mapping     │  │
│  └──────────┬───────────────────────────────────────────┘  │
└─────────────┼───────────────────────────────────────────────┘
              │ SQL Queries
              ▼
┌─────────────────────────────────────────────────────────────┐
│                   DATABASE (SQL Server)                     │
│  ┌──────────────────────────────────────────────────────┐  │
│  │ Tables:                                              │  │
│  │  - Users       → User accounts                       │  │
│  │  - TaskItems   → Task data                           │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

---

## Use These Diagrams to Explain:

1. **Start with Diagram 1**: Show simple public flow
2. **Show Diagram 3**: Explain how to get a token
3. **Show Diagram 4**: Explain token contents
4. **Show Diagram 2**: Show protected flow with token
5. **Show Diagram 5**: Compare HTTP requests
6. **Show Diagram 8**: Show complete architecture

---

_Print these diagrams or show them on screen during your lecture!_

