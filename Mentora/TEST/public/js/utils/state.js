// Simple State Management
export const State = {
  user: null,
  isAuthenticated: false,

  setUser(userData) {
    this.user = userData;
    this.isAuthenticated = !!userData;
    this.notifyStateChange();
  },

  onStateChange(callback) {
    window.addEventListener('stateChange', callback);
  },

  offStateChange(callback) {
    window.removeEventListener('stateChange', callback);
  },

  notifyStateChange() {
    window.dispatchEvent(new CustomEvent('stateChange', {
      detail: { user: this.user, isAuthenticated: this.isAuthenticated }
    }));
  },

  // Initialize state from localStorage
  initialize() {
    const user = Auth.getUser();
    const isAuthenticated = Auth.isAuthenticated();

    this.user = user;
    this.isAuthenticated = isAuthenticated;

    this.notifyStateChange();
  }
};