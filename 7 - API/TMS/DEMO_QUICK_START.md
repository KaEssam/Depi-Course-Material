# 🚀 Quick Start - API Demo

## For Students: Run the Demo in 5 Minutes

### Step 1: Start the API

1. Open terminal in project folder
2. Navigate to API project:
   ```bash
   cd TMS.APIs
   dotnet run
   ```
3. Keep this terminal open - API is now running on `https://localhost:7001`

### Step 2: Start the UI (New Terminal)

1. Open a **new** terminal
2. Navigate to UI project:
   ```bash
   cd TMS.UI
   dotnet run
   ```
3. Keep this terminal open - UI is now running on `https://localhost:5001`

### Step 3: Open Browser

1. Go to: `https://localhost:5001/Demo`
2. You'll see the demo page!

---

## 📖 Demo Overview

The demo has **TWO PARTS**:

### 🌍 Part 1: Public Endpoints (Left Side - Green)

- **No login required**
- Test GET and POST without authentication
- See how public APIs work

### 🔒 Part 2: Protected Endpoints (Right Side - Red)

- **Login required**
- First click "Login" to get a token
- Test GET and DELETE with authentication
- See how protected APIs work

---

## 📝 Step-by-Step Instructions

### Testing PUBLIC Endpoints (No Login)

1. **Get Data Without Token**

   - Click green button: "📥 Get All Tasks (Public)"
   - ✅ Success! You got data without logging in
   - **Why it works**: The API endpoint is public

2. **Post Data Without Token**
   - Type a task name in the text box
   - Click green button: "📝 Create Task (Public)"
   - ✅ Success! You created a task without logging in
   - **Why it works**: This endpoint doesn't require authentication

### Testing PROTECTED Endpoints (With Login)

3. **Try Protected Endpoint Without Login**

   - Click red button: "🔐 Get All Tasks (Protected)"
   - ❌ Error! "No token found"
   - **Why it fails**: Protected endpoints require authentication

4. **Login to Get Token**

   - Click the "Login Now" button
   - Enter credentials:
     - Username: (your username)
     - Password: (your password)
   - ✅ You're now logged in!

5. **Get Data With Token**

   - Return to `/Demo` page
   - Click red button: "🔐 Get All Tasks (Protected)"
   - ✅ Success! You got data with authentication
   - **Notice**: API knows your username

6. **Delete Data With Token**

   - Enter a task ID (e.g., 1)
   - Click red button: "🗑️ Delete Task (Protected)"
   - ✅ Success! Task deleted
   - **Why it works**: You sent a valid JWT token

7. **Test Your Token**
   - Click blue button: "🔍 Test Token"
   - See what's inside your JWT token
   - Shows your username, roles, expiration

---

## 🎯 Key Concepts

### What is a JWT Token?

- A secure "ID card" for APIs
- Contains your username and permissions
- Has an expiration time
- Looks like: `eyJhbGc...` (long string)

### Where is the Token Stored?

- In your browser session
- Automatically sent with protected requests
- Cleared when you logout

### Public vs Protected Endpoints

| Public 🌍           | Protected 🔒             |
| ------------------- | ------------------------ |
| No login needed     | Login required           |
| Anyone can access   | Only authenticated users |
| No token sent       | Token sent in header     |
| Example: Blog posts | Example: Delete data     |

---

## 🔍 What to Look For

### In the Browser (DevTools)

1. Press `F12` to open Developer Tools
2. Go to "Network" tab
3. Click any demo button
4. Look at the request:
   - **Public**: No Authorization header
   - **Protected**: Authorization: Bearer [token]

### In the Results

- Green messages = Success ✅
- Red messages = Error ❌
- Look at the "explanation" field to understand why

---

## 💡 Teaching Points

### Why Use Tokens Instead of Username/Password?

**Bad Approach** ❌:

```
Every request: Send username & password
- Insecure (password sent multiple times)
- Slow (check database every time)
- No way to expire or revoke access
```

**Good Approach** ✅:

```
Login once: Get token
Every request: Send token
- Secure (password sent only once)
- Fast (no database lookup needed)
- Can expire and be revoked
```

### What Happens Behind the Scenes?

#### Public Endpoint Call:

```
Browser → UI → API (no check) → Database → Response
```

#### Protected Endpoint Call:

```
Browser → UI (add token) → API (validate token) → Database → Response
                                     ↓
                              If invalid: STOP! 401 Error
```

---

## 🧪 Experiment Ideas

Try these to learn more:

1. **Test Logout**

   - Click a protected button (works)
   - Logout
   - Try protected button again (fails)
   - **Learn**: Token is cleared on logout

2. **Look at JSON**

   - Open DevTools > Network tab
   - Click any button
   - Look at Response
   - **Learn**: APIs return JSON data

3. **Edit Token** (Advanced)

   - Open DevTools > Application > Session Storage
   - Find "JWTToken"
   - Change one character
   - Try protected endpoint
   - **Learn**: Modified tokens are rejected

4. **Check Expiration**
   - Test token (shows expiration time)
   - Wait until expiration
   - Try protected endpoint
   - **Learn**: Expired tokens don't work

---

## 🐛 Troubleshooting

### "No token found"

- **Problem**: You're not logged in
- **Solution**: Click "Login Now" button

### "Token invalid or expired"

- **Problem**: Token expired or corrupted
- **Solution**: Logout and login again

### "CORS error"

- **Problem**: API not allowing UI to access it
- **Solution**: Check API is running and CORS is configured

### "Failed to fetch"

- **Problem**: API is not running
- **Solution**: Start the API with `dotnet run` in TMS.APIs folder

### Can't see Demo page

- **Problem**: UI not running
- **Solution**: Start the UI with `dotnet run` in TMS.UI folder

---

## 📚 Next Steps

After understanding this demo:

1. **Look at the Code**

   - Open `TMS.APIs/Controllers/DemoController.cs`
   - See the `[Authorize]` attribute
   - Understand public vs protected

2. **Read the Full Guide**

   - Open `LECTURE_DEMO_GUIDE.md`
   - Deep dive into each concept
   - See detailed code explanations

3. **Build Your Own**
   - Create a new public endpoint
   - Create a new protected endpoint
   - Test them in the demo

---

## 📞 Questions?

Ask yourself:

- ✅ Do I understand public vs protected?
- ✅ Do I know where the token is stored?
- ✅ Can I explain JWT tokens?
- ✅ Do I understand the Authorization header?

If YES to all: **You're ready to build secure APIs!** 🎉

---

## 🎓 Summary

**What You Learned**:

1. ✅ How to call APIs without authentication
2. ✅ How to call APIs with authentication
3. ✅ What JWT tokens are and how they work
4. ✅ The difference between public and protected endpoints
5. ✅ How to send tokens in HTTP requests

**Key Takeaway**:

> Public endpoints = Anyone can access
> Protected endpoints = Must login first (send token)

---

_Ready to teach this to others? Share this guide and the demo!_
