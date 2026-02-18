# 🚀 Quick Start Guide - TMS UI

## Step-by-Step Setup

### 1️⃣ Start the API

```bash
cd TMS.APIs
dotnet run
```

✅ Note the URL (e.g., `https://localhost:7096`)

### 2️⃣ Configure API URL (if different from default)

Open `TMS.UI/appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7096/api/" // ← Update this if needed
  }
}
```

### 3️⃣ Start the UI

```bash
cd TMS.UI
dotnet run
```

### 4️⃣ Open Browser

Navigate to: `https://localhost:5001` (or the URL shown in console)

### 5️⃣ Register & Login

1. Click "Create one" to register
2. Enter username and password
3. Login with your credentials

### 6️⃣ Start Using!

- Add tasks using the quick add form
- Click Edit to modify tasks
- Click Delete to remove tasks
- Use search box to filter tasks

## 🎨 Features You Can Use

### Quick Add Task

Type in the input box at the top and click "Add Task" or press Enter

### Edit Task

1. Click the "Edit" button on any task
2. Modify the title
3. Click "Save" or press Enter
4. Click "Cancel" to discard changes

### Delete Task

1. Click the "Delete" button
2. Confirm the deletion
3. Task is removed

### Search Tasks

Type in the search box to filter tasks in real-time

### Logout

Click the "Logout" button in the top navigation

## 🎯 Default Ports

- **API**: https://localhost:7096
- **UI**: https://localhost:5001

## ⚠️ Troubleshooting

**Problem**: Can't login

- **Solution**: Make sure TMS.APIs is running and the database is accessible

**Problem**: Tasks not showing

- **Solution**: Check browser console (F12) for errors and verify API URL

**Problem**: Session expired message

- **Solution**: This is normal after 2 hours. Just login again.

## 📱 Test on Mobile

The UI is fully responsive! Open the URL on your phone to test mobile view.

## 🎨 Color Scheme

The app uses a beautiful purple-to-blue gradient theme. All interactive elements have smooth hover effects and animations.

---

**Enjoy your new Task Management System! 🎉**
