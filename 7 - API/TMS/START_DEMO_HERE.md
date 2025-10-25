# 🚀 START HERE - API Demo

## Quick Setup (5 Minutes)

### For Students: Follow these steps

---

## Step 1: Start the API

Open a terminal and run:

```bash
cd TMS.APIs
dotnet run
```

✅ You should see: `Now listening on: https://localhost:7001`

**Keep this terminal open!**

---

## Step 2: Start the UI

Open a **NEW** terminal and run:

```bash
cd TMS.UI
dotnet run
```

✅ You should see: `Now listening on: https://localhost:5001`

**Keep this terminal open too!**

---

## Step 3: Open the Demo

Open your browser and go to:

```
https://localhost:5001/Demo
```

---

## 🎯 What to Do

### Part 1: Test WITHOUT Login (Green Buttons)

1. Click "📥 Get All Tasks (Public)"

   - ✅ Works! No login needed

2. Type "My First Task" and click "📝 Create Task (Public)"
   - ✅ Works! Anyone can create tasks

### Part 2: Test WITH Login (Red Buttons)

3. Click "🔐 Get All Tasks (Protected)"

   - ❌ Fails! Says "No token found"

4. Click "Login Now" button

   - Login with your credentials
   - You get a JWT token!

5. Go back to `/Demo` page

6. Click "🔐 Get All Tasks (Protected)" again

   - ✅ Works! Token is valid

7. Enter task ID "1" and click "🗑️ Delete Task (Protected)"
   - ✅ Works! Authenticated request

---

## 📚 Learn More

- **Quick Guide**: Read `DEMO_QUICK_START.md`
- **Full Details**: Read `LECTURE_DEMO_GUIDE.md`
- **Visual Diagrams**: Read `API_FLOW_DIAGRAMS.md`

---

## ❓ Problems?

### API won't start

- Make sure you're in the `TMS.APIs` folder
- Check port 7001 is not in use

### UI won't start

- Make sure you're in the `TMS.UI` folder
- Check port 5001 is not in use

### Can't login

- Make sure API is running
- Use correct username/password

---

## 🎉 That's It!

You now understand:

- ✅ Public API endpoints (no token)
- ✅ Protected API endpoints (with token)
- ✅ How JWT tokens work

**Happy Learning!** 🚀
