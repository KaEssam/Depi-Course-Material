# 🚀 Task Management System - UI Documentation

## Overview

A modern, full-featured Task Management System UI built with ASP.NET Core MVC, integrated with the TMS REST API.

## ✨ Features Implemented

### 🔐 Authentication System

- **Login Page** (`/Auth/Login`)

  - Modern gradient design
  - Form validation
  - Session-based authentication with JWT tokens
  - "Remember Me" functionality
  - Responsive layout

- **Register Page** (`/Auth/Register`)
  - User registration with validation
  - Password confirmation
  - Username uniqueness check
  - Auto-redirect to login after successful registration

### 📋 Task Management Dashboard

- **Full CRUD Operations**

  - ✅ **Create**: Quick add task with inline validation
  - ✅ **Read**: Display all tasks in beautiful card layout
  - ✅ **Update**: Inline editing with save/cancel options
  - ✅ **Delete**: Delete with confirmation dialog

- **Modern UI Features**
  - Card-based task display with animations
  - Real-time search/filter functionality
  - Task counter in header
  - Empty state when no tasks exist
  - Loading states and spinners
  - Toast notifications for all actions
  - Responsive grid layout

### 🎨 Design Features

- **Modern Color Scheme**

  - Primary gradient: Purple to Blue (#667eea to #764ba2)
  - Clean white cards with soft shadows
  - Smooth animations and transitions
  - Custom scrollbar styling

- **Responsive Design**

  - Mobile-first approach
  - Breakpoints for tablets and desktops
  - Collapsible navigation on mobile
  - Adaptive card grid

- **UI Components**
  - Gradient navbar with user info
  - Bootstrap Icons integration
  - Custom buttons with hover effects
  - Toast notification system
  - Loading overlays

## 📁 Project Structure

```
TMS.UI/
├── Controllers/
│   ├── AuthController.cs          # Handles login/register/logout
│   ├── TasksController.cs         # Task CRUD operations via API
│   └── HomeController.cs          # Redirects to appropriate page
├── Models/
│   ├── AuthViewModel.cs           # Login & Register view models
│   ├── TaskViewModel.cs           # Task-related view models
│   └── ApiResponse.cs             # API response wrapper
├── Views/
│   ├── Auth/
│   │   ├── Login.cshtml           # Login page
│   │   └── Register.cshtml        # Registration page
│   ├── Tasks/
│   │   └── Index.cshtml           # Task dashboard
│   └── Shared/
│       └── _Layout.cshtml         # Main layout with navbar
├── wwwroot/
│   ├── css/
│   │   └── site.css               # Custom styles & animations
│   └── js/
│       └── site.js                # Utility functions
├── Program.cs                      # App configuration
└── appsettings.json               # API URL configuration
```

## 🔧 Configuration

### API Settings

Update `appsettings.json` to point to your API:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7096/api/"
  }
}
```

### Session Configuration

- Session timeout: 2 hours
- HttpOnly cookies for security
- JWT token stored in session

## 🎯 Key Components

### Authentication Flow

1. User visits the site → Redirected to Login
2. User logs in → JWT token stored in session
3. Token included in all API requests via Bearer authentication
4. Session expires → User redirected to login

### Task Operations

All task operations are performed via AJAX calls to the API:

- **GET /api/Tasks** - Fetch all tasks
- **POST /api/Tasks** - Create new task
- **PUT /api/Tasks/{id}** - Update task
- **DELETE /api/Tasks/{id}** - Delete task

### JavaScript Utilities

Global `TMS` object provides:

- `showToast(message, type)` - Display notifications
- `showLoadingOverlay()` / `hideLoadingOverlay()`
- `storage` - LocalStorage wrapper
- `apiCall(url, options)` - Fetch wrapper with error handling
- `debounce()` - For search optimization
- More utility functions...

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- TMS.APIs project running (for backend)
- Modern web browser

### Running the Application

1. **Ensure the API is running**

   ```bash
   cd TMS.APIs
   dotnet run
   ```

   Note the API URL (e.g., https://localhost:7096)

2. **Update appsettings.json in TMS.UI**
   Set the correct API URL

3. **Run the UI project**

   ```bash
   cd TMS.UI
   dotnet run
   ```

4. **Access the application**
   Open browser to: https://localhost:5001 (or displayed URL)

### First Time Setup

1. **Register a new account**

   - Navigate to Register page
   - Create username (min 3 chars) and password (min 6 chars)
   - Click "Create Account"

2. **Login**

   - Use your credentials to login
   - You'll be redirected to the Task Dashboard

3. **Start managing tasks**
   - Add your first task using the quick add form
   - Edit tasks by clicking the Edit button
   - Delete tasks with confirmation
   - Use search to filter tasks

## 🎨 Customization

### Changing Colors

Edit CSS variables in `_Layout.cshtml` or `site.css`:

```css
:root {
  --primary-color: #667eea;
  --secondary-color: #764ba2;
}
```

### Adding New Features

1. Add controller action in `TasksController.cs` or `AuthController.cs`
2. Create corresponding view in `Views/` folder
3. Update navigation in `_Layout.cshtml` if needed
4. Add JavaScript functions in view or `site.js`

## 📱 Responsive Breakpoints

- Mobile: < 768px (Single column layout)
- Tablet: 768px - 1024px (2 column grid)
- Desktop: > 1024px (3+ column grid)

## 🔒 Security Features

- Session-based authentication
- HttpOnly cookies
- JWT token validation
- CSRF protection (built-in MVC)
- Input validation on client and server
- Secure password handling

## 🎯 Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## 📝 API Integration

All API calls use `HttpClient` with:

- Base URL from configuration
- JWT Bearer token authentication
- JSON content type
- Error handling with user feedback

## 🐛 Troubleshooting

### "API not responding"

- Ensure TMS.APIs is running
- Check API URL in appsettings.json
- Verify CORS is configured in API

### "Session expired"

- Session timeout is 2 hours
- Login again to refresh session

### "Tasks not loading"

- Check browser console for errors
- Verify API authentication is working
- Check network tab for API responses

## 🎉 Features Highlights

✅ Modern, gradient-based UI design
✅ Full authentication system
✅ Complete CRUD operations
✅ Real-time search & filter
✅ Toast notifications
✅ Loading states
✅ Inline editing
✅ Responsive layout
✅ Smooth animations
✅ Error handling
✅ Form validation
✅ Session management
✅ Clean architecture

## 📚 Technologies Used

- ASP.NET Core 8.0 MVC
- Bootstrap 5
- Bootstrap Icons
- jQuery (for AJAX)
- Fetch API
- CSS3 Animations
- Modern JavaScript (ES6+)

## 👨‍💻 Development Notes

- All API calls are async for better performance
- Session-based auth for simplicity
- Inline styles in views for easier customization
- Utility functions in site.js for reusability
- ViewModels for clean data transfer
- Proper error handling throughout

---

**Built with ❤️ for modern task management**
