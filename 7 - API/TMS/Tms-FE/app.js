// API Configuration
const API_BASE_URL = 'http://localhost:5026';

// Token Management
const tokenManager = {
    getToken: function() {
        return localStorage.getItem('authToken');
    },

    setToken: function(token) {
        localStorage.setItem('authToken', token);
    },

    removeToken: function() {
        localStorage.removeItem('authToken');
    },

    isAuthenticated: function() {
        return this.getToken() !== null;
    }
};

// API Helper Functions
async function apiRequest(endpoint, options = {}) {
    const url = `${API_BASE_URL}${endpoint}`;

    // Set default headers
    const defaultHeaders = {
        'Content-Type': 'application/json',
    };

    // Add authorization header if token exists
    const token = tokenManager.getToken();
    if (token) {
        defaultHeaders.Authorization = `Bearer ${token}`;
    }

    // Merge with provided headers
    const headers = {
        ...defaultHeaders,
        ...options.headers
    };

    // Merge with provided options
    const config = {
        ...options,
        headers
    };

    try {
        const response = await fetch(url, config);

        // Handle HTTP errors
        if (!response.ok) {
            const errorData = await response.json().catch(() => ({}));
            throw new Error(errorData.message || `HTTP error! Status: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error('API request failed:', error);
        throw error;
    }
}

// Authentication Functions
async function loginUser(username, password) {
    try {
        const response = await apiRequest('/api/Auth/Login', {
            method: 'POST',
            body: JSON.stringify({
                userName: username,
                passWord: password
            })
        });

        // Store token if login is successful
        if (response.token) {
            tokenManager.setToken(response.token);
        }

        return {
            success: true,
            data: response
        };
    } catch (error) {
        return {
            success: false,
            message: error.message || 'Login failed. Please check your credentials.'
        };
    }
}

async function registerUser(username, password) {
    try {
        const response = await apiRequest('/api/Auth/register', {
            method: 'POST',
            body: JSON.stringify({
                userName: username,
                passWord: password
            })
        });

        return {
            success: true,
            data: response
        };
    } catch (error) {
        return {
            success: false,
            message: error.message || 'Registration failed. Please try again.'
        };
    }
}

// Logout function
function logoutUser() {
    tokenManager.removeToken();
    window.location.href = 'login.html';
}

// Check authentication status and redirect if needed
function checkAuthStatus() {
    if (!tokenManager.isAuthenticated()) {
        window.location.href = 'login.html';
        return false;
    }
    return true;
}

// Get current user info (if needed)
async function getCurrentUser() {
    try {
        const response = await apiRequest('/api/Auth/user', {
            method: 'GET'
        });

        return {
            success: true,
            data: response
        };
    } catch (error) {
        return {
            success: false,
            message: error.message || 'Failed to get user information.'
        };
    }
}

// Utility function to handle API errors
function handleApiError(error, customMessage = '') {
    console.error('API Error:', error);

    if (customMessage) {
        return customMessage;
    }

    if (error.message) {
        return error.message;
    }

    return 'An unexpected error occurred. Please try again.';
}

// Export functions for use in other scripts
if (typeof module !== 'undefined' && module.exports) {
    module.exports = {
        loginUser,
        registerUser,
        logoutUser,
        checkAuthStatus,
        getCurrentUser,
        tokenManager,
        handleApiError
    };
}

