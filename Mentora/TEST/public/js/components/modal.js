// Modal Component System
export class Modal {
  static activeModal = null;
  static stack = [];

  static show(options) {
    const {
      title,
      content,
      size = 'md', // sm, md, lg, xl
      showClose = true,
      backdropClose = true,
      keyboardClose = true,
      customClass = ''
    } = options;

    // If there's already a modal open, add it to stack
    if (this.activeModal) {
      this.stack.push(this.activeModal);
    }

    const modal = this.createModal(title, content, size, showClose, customClass);
    document.body.appendChild(modal);

    // Add to active state
    this.activeModal = modal;

    // Add event listeners
    this.setupModalEventListeners(modal, backdropClose, keyboardClose);

    // Trigger open animation
    requestAnimationFrame(() => {
      modal.classList.add('opacity-100');
      modal.classList.remove('opacity-0');
      const modalContent = modal.querySelector('.modal-content');
      modalContent?.classList.add('scale-100');
      modalContent?.classList.remove('scale-95');
    });

    // Focus management
    this.trapFocus(modal);

    return modal;
  }

  static createModal(title, content, size, showClose, customClass) {
    const modal = document.createElement('div');
    modal.className = `modal fixed inset-0 z-50 overflow-y-auto opacity-0 transition-opacity duration-300 ${customClass}`;

    const sizeClasses = {
      sm: 'max-w-sm',
      md: 'max-w-md',
      lg: 'max-w-lg',
      xl: 'max-w-xl',
      '2xl': 'max-w-2xl',
      '3xl': 'max-w-3xl',
      '4xl': 'max-w-4xl',
      '5xl': 'max-w-5xl',
      full: 'max-w-full mx-4'
    };

    const modalSize = sizeClasses[size] || sizeClasses.md;

    modal.innerHTML = `
      <div class="flex items-center justify-center min-h-screen px-4 pt-4 pb-20 text-center sm:block sm:p-0">
        <!-- Background overlay -->
        <div class="fixed inset-0 transition-opacity bg-gray-500 bg-opacity-75 modal-backdrop"></div>

        <!-- Modal panel -->
        <div class="inline-block w-full my-8 overflow-hidden text-left align-middle transition-all transform modal-content ${modalSize} bg-white rounded-lg shadow-xl">
          <!-- Modal header -->
          <div class="px-6 py-4 border-b border-gray-200">
            <div class="flex items-center justify-between">
              <h3 class="text-lg font-medium text-gray-900">${title}</h3>
              ${showClose ? `
                <button type="button" class="modal-close text-gray-400 hover:text-gray-600 focus:outline-none focus:text-gray-600 transition-colors">
                  <svg class="h-6 w-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>
                  </svg>
                </button>
              ` : ''}
            </div>
          </div>

          <!-- Modal body -->
          <div class="px-6 py-4">
            ${typeof content === 'string' ? content : ''}
          </div>

          <!-- Modal footer (if content has footer) -->
          <div class="modal-footer"></div>
        </div>
      </div>
    `;

    // If content is an element, append it to the body
    if (typeof content !== 'string' && content instanceof HTMLElement) {
      const modalBody = modal.querySelector('.px-6.py-4');
      modalBody.innerHTML = '';
      modalBody.appendChild(content);
    }

    return modal;
  }

  static setupModalEventListeners(modal, backdropClose, keyboardClose) {
    // Close button handler
    const closeBtn = modal.querySelector('.modal-close');
    closeBtn?.addEventListener('click', () => {
      this.close(modal);
    });

    // Backdrop click handler
    if (backdropClose) {
      const backdrop = modal.querySelector('.modal-backdrop');
      backdrop?.addEventListener('click', () => {
        this.close(modal);
      });
    }

    // Keyboard handler
    if (keyboardClose) {
      const handleKeyDown = (e) => {
        if (e.key === 'Escape' && this.activeModal === modal) {
          this.close(modal);
        }
      };
      modal.handleKeyDown = handleKeyDown;
      document.addEventListener('keydown', handleKeyDown);
    }
  }

  static close(modal = null) {
    const modalToClose = modal || this.activeModal;
    if (!modalToClose) return;

    // Remove keyboard event listener
    if (modalToClose.handleKeyDown) {
      document.removeEventListener('keydown', modalToClose.handleKeyDown);
    }

    // Trigger close animation
    modalToClose.classList.add('opacity-0');
    modalToClose.classList.remove('opacity-100');
    const modalContent = modalToClose.querySelector('.modal-content');
    modalContent?.classList.add('scale-95');
    modalContent?.classList.remove('scale-100');

    // Remove from DOM after animation
    setTimeout(() => {
      if (modalToClose.parentNode) {
        modalToClose.parentNode.removeChild(modalToClose);
      }
    }, 300);

    // Update active modal
    if (this.activeModal === modalToClose) {
      this.activeModal = this.stack.length > 0 ? this.stack.pop() : null;
    } else {
      // Remove from stack if it was there
      this.stack = this.stack.filter(m => m !== modalToClose);
    }

    // Restore focus to previous active modal or body
    if (this.activeModal) {
      this.trapFocus(this.activeModal);
    } else {
      document.body.focus();
    }
  }

  static closeAll() {
    while (this.activeModal) {
      this.close(this.activeModal);
    }
    this.stack = [];
  }

  // Convenience methods for common modal types
  static alert(message, title = 'Alert') {
    return this.show({
      title,
      content: `
        <div class="flex items-center">
          <svg class="h-6 w-6 text-blue-400 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
          </svg>
          <p class="text-gray-700">${message}</p>
        </div>
      `,
      showClose: true
    });
  }

  static confirm(message, title = 'Confirm Action') {
    return new Promise((resolve) => {
      const modal = this.show({
        title,
        content: `
          <div class="flex items-center mb-4">
            <svg class="h-6 w-6 text-yellow-400 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"></path>
            </svg>
            <p class="text-gray-700">${message}</p>
          </div>
        `,
        showClose: false
      });

      const footer = modal.querySelector('.modal-footer');
      footer.innerHTML = `
        <div class="px-6 py-4 bg-gray-50 border-t border-gray-200 flex justify-end space-x-3">
          <button type="button" class="modal-cancel btn btn-secondary">Cancel</button>
          <button type="button" class="modal-confirm btn btn-primary">Confirm</button>
        </div>
      `;

      // Add event listeners
      footer.querySelector('.modal-cancel').addEventListener('click', () => {
        this.close(modal);
        resolve(false);
      });

      footer.querySelector('.modal-confirm').addEventListener('click', () => {
        this.close(modal);
        resolve(true);
      });

      // Close with close button should resolve to false
      const closeBtn = modal.querySelector('.modal-close');
      closeBtn?.addEventListener('click', () => {
        resolve(false);
      });
    });
  }

  static loading(message = 'Loading...', title = 'Please Wait') {
    const modal = this.show({
      title,
      content: `
        <div class="flex flex-col items-center justify-center py-8">
          <div class="spinner h-8 w-8 mb-4"></div>
          <p class="text-gray-600">${message}</p>
        </div>
      `,
      showClose: false,
      backdropClose: false,
      keyboardClose: false
    });

    return {
      close: () => this.close(modal),
      updateMessage: (newMessage) => {
        const messageEl = modal.querySelector('p.text-gray-600');
        if (messageEl) {
          messageEl.textContent = newMessage;
        }
      }
    };
  }

  // Focus management for accessibility
  static trapFocus(modal) {
    const focusableElements = modal.querySelectorAll(
      'button, [href], input, select, textarea, [tabindex]:not([tabindex="-1"])'
    );

    if (focusableElements.length === 0) return;

    const firstFocusable = focusableElements[0];
    const lastFocusable = focusableElements[focusableElements.length - 1];

    // Focus first element
    firstFocusable.focus();

    const handleTabKey = (e) => {
      if (e.key === 'Tab') {
        if (e.shiftKey) {
          if (document.activeElement === firstFocusable) {
            lastFocusable.focus();
            e.preventDefault();
          }
        } else {
          if (document.activeElement === lastFocusable) {
            firstFocusable.focus();
            e.preventDefault();
          }
        }
      }
    };

    modal.trapFocusHandler = handleTabKey;
    modal.addEventListener('keydown', handleTabKey);
  }

  // Clean up focus trapping
  static removeFocusTrap(modal) {
    if (modal.trapFocusHandler) {
      modal.removeEventListener('keydown', modal.trapFocusHandler);
    }
  }
}