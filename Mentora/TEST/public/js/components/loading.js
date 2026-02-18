// Loading Components
export class Loading {
  // Show full page loading overlay
  static showPageLoader(message = 'Loading...') {
    let loader = document.getElementById('pageLoader');

    if (!loader) {
      loader = document.createElement('div');
      loader.id = 'pageLoader';
      loader.className = 'fixed inset-0 bg-white bg-opacity-90 z-50 flex items-center justify-center';
      loader.innerHTML = `
        <div class="text-center">
          <div class="spinner h-12 w-12 mx-auto mb-4"></div>
          <p class="text-gray-600 text-lg">${message}</p>
        </div>
      `;
      document.body.appendChild(loader);
    } else {
      loader.classList.remove('hidden');
      const messageEl = loader.querySelector('p');
      if (messageEl) {
        messageEl.textContent = message;
      }
    }

    return loader;
  }

  static hidePageLoader() {
    const loader = document.getElementById('pageLoader');
    if (loader) {
      loader.classList.add('hidden');
    }
  }

  // Create skeleton loading states
  static createSkeletonCard(lines = 3) {
    return `
      <div class="card">
        <div class="animate-pulse">
          <div class="h-4 bg-gray-200 rounded w-1/4 mb-4"></div>
          ${Array.from({ length: lines }, () =>
            '<div class="h-4 bg-gray-200 rounded mb-2"></div>'
          ).join('')}
          <div class="h-4 bg-gray-200 rounded w-3/4"></div>
        </div>
      </div>
    `;
  }

  static createSkeletonList(items = 3) {
    return Array.from({ length: items }, (_, i) => `
      <div class="border-b border-gray-200 py-4">
        <div class="animate-pulse">
          <div class="flex items-center">
            <div class="h-10 w-10 bg-gray-200 rounded-full mr-4"></div>
            <div class="flex-1">
              <div class="h-4 bg-gray-200 rounded w-1/3 mb-2"></div>
              <div class="h-3 bg-gray-200 rounded w-1/2"></div>
            </div>
          </div>
        </div>
      </div>
    `).join('');
  }

  static createSkeletonTable(rows = 5, cols = 4) {
    let skeleton = `
      <div class="overflow-x-auto">
        <table class="min-w-full divide-y divide-gray-200">
          <thead class="bg-gray-50">
            <tr>
              ${Array.from({ length: cols }, () =>
                '<th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"><div class="h-4 bg-gray-200 rounded w-20"></div></th>'
              ).join('')}
            </tr>
          </thead>
          <tbody class="bg-white divide-y divide-gray-200">
    `;

    for (let i = 0; i < rows; i++) {
      skeleton += '<tr>';
      for (let j = 0; j < cols; j++) {
        skeleton += '<td class="px-6 py-4 whitespace-nowrap"><div class="h-4 bg-gray-200 rounded w-24"></div></td>';
      }
      skeleton += '</tr>';
    }

    skeleton += `
          </tbody>
        </table>
      </div>
    `;

    return skeleton;
  }

  // Button loading state
  static setButtonLoading(button, loading = true) {
    if (!button) return;

    if (loading) {
      // Store original content
      button.dataset.originalText = button.innerHTML;

      // Set loading state
      button.disabled = true;
      button.classList.add('opacity-75', 'cursor-not-allowed');

      // Add spinner and text
      const spinnerSize = button.classList.contains('btn-sm') ? 'h-4 w-4' : 'h-5 w-5';
      button.innerHTML = `
        <span class="inline-flex items-center">
          <svg class="animate-spin ${spinnerSize} mr-2" fill="none" viewBox="0 0 24 24">
            <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
            <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
          </svg>
          Loading...
        </span>
      `;
    } else {
      // Restore original state
      button.disabled = false;
      button.classList.remove('opacity-75', 'cursor-not-allowed');

      if (button.dataset.originalText) {
        button.innerHTML = button.dataset.originalText;
        delete button.dataset.originalText;
      }
    }
  }

  // Form loading state
  static setFormLoading(form, loading = true) {
    if (!form) return;

    const buttons = form.querySelectorAll('button[type="submit"]');
    const inputs = form.querySelectorAll('input, select, textarea');

    if (loading) {
      buttons.forEach(button => this.setButtonLoading(button, true));
      inputs.forEach(input => {
        input.disabled = true;
        input.classList.add('opacity-50');
      });
    } else {
      buttons.forEach(button => this.setButtonLoading(button, false));
      inputs.forEach(input => {
        input.disabled = false;
        input.classList.remove('opacity-50');
      });
    }
  }

  // Progress bar
  static showProgressBar(progress = 0) {
    let progressBar = document.getElementById('globalProgress');

    if (!progressBar) {
      progressBar = document.createElement('div');
      progressBar.id = 'globalProgress';
      progressBar.className = 'fixed top-0 left-0 right-0 h-1 bg-gray-200 z-50';
      progressBar.innerHTML = `
        <div class="h-full bg-primary-500 transition-all duration-300 ease-out" style="width: 0%"></div>
      `;
      document.body.appendChild(progressBar);
    }

    const fill = progressBar.querySelector('div');
    fill.style.width = `${Math.min(100, Math.max(0, progress))}%`;

    if (progress >= 100) {
      setTimeout(() => {
        progressBar.classList.add('opacity-0', 'transition-opacity', 'duration-500');
        setTimeout(() => {
          if (progressBar.parentNode) {
            progressBar.parentNode.removeChild(progressBar);
          }
        }, 500);
      }, 1000);
    }

    return progressBar;
  }

  // Loading spinner component
  static spinner(size = 'md', color = 'primary') {
    const sizeClasses = {
      sm: 'h-4 w-4',
      md: 'h-6 w-6',
      lg: 'h-8 w-8',
      xl: 'h-12 w-12'
    };

    const colorClasses = {
      primary: 'text-primary-500',
      gray: 'text-gray-500',
      white: 'text-white',
      success: 'text-green-500',
      error: 'text-red-500'
    };

    const spinnerSize = sizeClasses[size] || sizeClasses.md;
    const spinnerColor = colorClasses[color] || colorClasses.primary;

    return `
      <svg class="animate-spin ${spinnerSize} ${spinnerColor}" fill="none" viewBox="0 0 24 24">
        <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
        <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
      </svg>
    `;
  }

  // Inline loading indicator
  static inlineLoading(message = 'Loading...') {
    return `
      <div class="flex items-center justify-center py-8">
        <div class="text-center">
          ${this.spinner()}
          <p class="text-gray-600 mt-2">${message}</p>
        </div>
      </div>
    `;
  }
}