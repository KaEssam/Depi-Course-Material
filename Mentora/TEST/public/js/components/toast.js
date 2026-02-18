// Toast Notification System
export class Toast {
  static container = null;
  static queue = [];
  static isShowing = false;

  static init() {
    if (this.container) return;

    this.container = document.createElement('div');
    this.container.className = 'fixed top-4 right-4 z-50 space-y-2';
    document.body.appendChild(this.container);
  }

  static show(message, type = 'info', duration = 5000) {
    this.init();

    const toast = this.createToastElement(message, type);
    this.queue.push({ toast, duration });

    if (!this.isShowing) {
      this.processQueue();
    }
  }

  static createToastElement(message, type) {
    const toast = document.createElement('div');
    toast.className = `toast transform translate-x-full transition-all duration-300 ease-in-out`;

    // Add type-specific classes
    const typeClasses = {
      success: 'toast-success',
      error: 'toast-error',
      warning: 'toast-warning',
      info: 'toast-info'
    };

    toast.classList.add(typeClasses[type] || 'toast-info');

    // Create icon
    const icon = this.createIcon(type);

    // Create content
    const content = document.createElement('div');
    content.className = 'flex items-center';
    content.innerHTML = `
      <div class="flex-shrink-0 mr-3">
        ${icon}
      </div>
      <div class="flex-1">
        <p class="text-sm font-medium">${message}</p>
      </div>
      <button class="ml-4 flex-shrink-0 text-gray-400 hover:text-gray-600 focus:outline-none" onclick="Toast.dismiss(this.parentElement.parentElement)">
        <svg class="h-5 w-5" fill="currentColor" viewBox="0 0 20 20">
          <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path>
        </svg>
      </button>
    `;

    toast.appendChild(content);
    return toast;
  }

  static createIcon(type) {
    const icons = {
      success: `
        <svg class="h-6 w-6 text-green-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
        </svg>
      `,
      error: `
        <svg class="h-6 w-6 text-red-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
        </svg>
      `,
      warning: `
        <svg class="h-6 w-6 text-yellow-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"></path>
        </svg>
      `,
      info: `
        <svg class="h-6 w-6 text-blue-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
        </svg>
      `
    };

    return icons[type] || icons.info;
  }

  static async processQueue() {
    if (this.queue.length === 0) {
      this.isShowing = false;
      return;
    }

    this.isShowing = true;
    const { toast, duration } = this.queue.shift();

    this.container.appendChild(toast);

    // Trigger slide in animation
    requestAnimationFrame(() => {
      requestAnimationFrame(() => {
        toast.classList.remove('translate-x-full');
        toast.classList.add('translate-x-0');
      });
    });

    // Auto dismiss after duration
    setTimeout(() => {
      this.dismiss(toast);
    }, duration);
  }

  static dismiss(toast) {
    if (!toast) return;

    toast.classList.remove('translate-x-0');
    toast.classList.add('translate-x-full');

    setTimeout(() => {
      if (toast.parentNode) {
        toast.parentNode.removeChild(toast);
      }
      this.processQueue();
    }, 300);
  }

  // Convenience methods
  static success(message, duration = 5000) {
    this.show(message, 'success', duration);
  }

  static error(message, duration = 7000) {
    this.show(message, 'error', duration);
  }

  static warning(message, duration = 6000) {
    this.show(message, 'warning', duration);
  }

  static info(message, duration = 5000) {
    this.show(message, 'info', duration);
  }

  static clear() {
    this.queue = [];
    if (this.container) {
      this.container.innerHTML = '';
    }
    this.isShowing = false;
  }
}