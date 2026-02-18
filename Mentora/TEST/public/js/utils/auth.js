// Authentication Utility
export const Auth = {
  // Token Management
  getToken() {
    return localStorage.getItem('jwtToken');
  },

  setToken(token) {
    localStorage.setItem('jwtToken', token);
  },

  getRefreshToken() {
    return localStorage.getItem('refreshToken');
  },

  setRefreshToken(token) {
    localStorage.setItem('refreshToken', token);
  },

  removeTokens() {
    localStorage.removeItem('jwtToken');
    localStorage.removeItem('refreshToken');
  },

  // User Management
  getUser() {
    const userStr = localStorage.getItem('user');
    return userStr ? JSON.parse(userStr) : null;
  },

  setUser(user) {
    localStorage.setItem('user', JSON.stringify(user));
  },

  removeUser() {
    localStorage.removeItem('user');
  },

  // Authentication State
  isAuthenticated() {
    const token = this.getToken();
    if (!token) return false;

    try {
      // Check if token is expired
      const payload = JSON.parse(atob(token.split('.')[1]));
      const currentTime = Date.now() / 1000;
      return payload.exp > currentTime;
    } catch (error) {
      return false;
    }
  },

  // Login/Logout Functions
  async login(email, password) {
    try {
      const response = await API.post(API.endpoints.auth.login, {
        email,
        password
      });

      if (response.token) {
        this.setToken(response.token);
      }

      if (response.refreshToken) {
        this.setRefreshToken(response.refreshToken);
      }

      if (response.user) {
        this.setUser(response.user);
      }

      // Notify state change
      State.setUser(response.user);

      return response;
    } catch (error) {
      throw error;
    }
  },

  async register(userData) {
    try {
      const response = await API.post(API.endpoints.auth.register, userData);

      if (response.token) {
        this.setToken(response.token);
      }

      if (response.refreshToken) {
        this.setRefreshToken(response.refreshToken);
      }

      if (response.user) {
        this.setUser(response.user);
      }

      // Notify state change
      State.setUser(response.user);

      return response;
    } catch (error) {
      throw error;
    }
  },

  async logout() {
    try {
      await API.post(API.endpoints.auth.logout);
    } catch (error) {
      // Even if logout API fails, clear local data
      console.error('Logout API error:', error);
    } finally {
      this.removeTokens();
      this.removeUser();

      // Notify state change
      State.setUser(null);

      // Redirect to login
      window.location.href = '/login.html';
    }
  },

  // Session Management
  async refreshTokenIfNeeded() {
    const token = this.getToken();
    if (!token) return false;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const currentTime = Date.now() / 1000;

      // Refresh if token expires within 5 minutes
      if (payload.exp - currentTime < 300) {
        await API.refreshToken();
        return true;
      }
    } catch (error) {
      console.error('Token refresh error:', error);
      return false;
    }

    return false;
  },

  // Password helpers
  validatePassword(password) {
    const minLength = 8;
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    const hasNumbers = /\d/.test(password);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);

    return {
      isValid: password.length >= minLength && hasUpperCase && hasLowerCase && hasNumbers && hasSpecialChar,
      requirements: {
        minLength: password.length >= minLength,
        hasUpperCase,
        hasLowerCase,
        hasNumbers,
        hasSpecialChar
      }
    };
  }
};