// Navigation Component
export class Navigation {
  static init() {
    this.createNavigation();
    this.setupEventListeners();
    this.updateAuthState();
    this.highlightActivePage();
  }

  static createNavigation() {
    const nav = document.createElement('nav');
    nav.className = 'bg-white shadow-sm border-b border-gray-200';
    nav.innerHTML = `
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="flex justify-between h-16">
          <div class="flex items-center">
            <div class="flex-shrink-0 flex items-center">
              <a href="/" class="text-2xl font-bold text-primary-600">Mentora</a>
            </div>
            <div class="hidden md:block md:ml-10">
              <div class="flex items-baseline space-x-4">
                <a href="/" class="nav-link text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium" data-page="home">Home</a>
                <a href="/search.html" class="nav-link text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium" data-page="search">Find Mentors</a>
                <a href="/dashboard.html" class="nav-link text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium auth-only" data-page="dashboard">Dashboard</a>
                <a href="/my-sessions.html" class="nav-link text-gray-700 hover:text-primary-600 px-3 py-2 rounded-md text-sm font-medium auth-only" data-page="sessions">My Sessions</a>
              </div>
            </div>
          </div>

          <div class="flex items-center">
            <!-- Authenticated user dropdown -->
            <div class="hidden md:block auth-only" id="userDropdown">
              <div class="relative">
                <button type="button" class="flex items-center text-sm rounded-full focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-500" id="userMenuButton" aria-expanded="false" aria-haspopup="true">
                  <span class="sr-only">Open user menu</span>
                  <img class="h-8 w-8 rounded-full" id="userAvatar" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixqx=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="">
                </button>
                <div class="origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 divide-y divide-gray-100 focus:outline-none hidden" id="userMenu">
                  <div class="px-4 py-3">
                    <p class="text-sm text-gray-900" id="userName">Loading...</p>
                    <p class="text-sm text-gray-500 truncate" id="userEmail">Loading...</p>
                  </div>
                  <div class="py-1">
                    <a href="/profile.html" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Your Profile</a>
                    <a href="/settings.html" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Settings</a>
                    <button type="button" id="logoutBtn" class="block w-full text-left px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Sign out</button>
                  </div>
                </div>
              </div>
            </div>

            <!-- Guest auth buttons -->
            <div class="hidden md:block guest-only" id="authButtons">
              <a href="/login.html" class="btn btn-outline mr-3">Log in</a>
              <a href="/register.html" class="btn btn-primary">Sign up</a>
            </div>

            <!-- Mobile menu button -->
            <div class="md:hidden">
              <button type="button" class="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-primary-500" id="mobileMenuButton">
                <span class="sr-only">Open main menu</span>
                <svg class="block h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                </svg>
                <svg class="hidden h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Mobile menu -->
      <div class="md:hidden hidden" id="mobileMenu">
        <div class="px-2 pt-2 pb-3 space-y-1 sm:px-3">
          <a href="/" class="mobile-nav-link text-gray-700 hover:text-primary-600 hover:bg-gray-50 block px-3 py-2 rounded-md text-base font-medium" data-page="home">Home</a>
          <a href="/search.html" class="mobile-nav-link text-gray-700 hover:text-primary-600 hover:bg-gray-50 block px-3 py-2 rounded-md text-base font-medium" data-page="search">Find Mentors</a>
          <a href="/dashboard.html" class="mobile-nav-link text-gray-700 hover:text-primary-600 hover:bg-gray-50 block px-3 py-2 rounded-md text-base font-medium auth-only" data-page="dashboard">Dashboard</a>
          <a href="/my-sessions.html" class="mobile-nav-link text-gray-700 hover:text-primary-600 hover:bg-gray-50 block px-3 py-2 rounded-md text-base font-medium auth-only" data-page="sessions">My Sessions</a>

          <div class="border-t border-gray-200 pt-4">
            <!-- Mobile user info -->
            <div class="auth-only hidden px-3 py-2" id="mobileUserInfo">
              <div class="flex items-center">
                <img class="h-8 w-8 rounded-full mr-3" id="mobileUserAvatar" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixqx=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="">
                <div>
                  <p class="text-sm font-medium text-gray-700" id="mobileUserName">Loading...</p>
                  <p class="text-sm text-gray-500" id="mobileUserEmail">Loading...</p>
                </div>
              </div>
              <div class="mt-3 space-y-1">
                <a href="/profile.html" class="block px-3 py-2 rounded-md text-base font-medium text-gray-700 hover:text-primary-600 hover:bg-gray-50">Your Profile</a>
                <a href="/settings.html" class="block px-3 py-2 rounded-md text-base font-medium text-gray-700 hover:text-primary-600 hover:bg-gray-50">Settings</a>
                <button type="button" id="mobileLogoutBtn" class="block w-full text-left px-3 py-2 rounded-md text-base font-medium text-gray-700 hover:text-primary-600 hover:bg-gray-50">Sign out</button>
              </div>
            </div>

            <!-- Mobile auth buttons -->
            <div class="guest-only space-y-1" id="mobileAuthButtons">
              <a href="/login.html" class="block px-3 py-2 rounded-md text-base font-medium text-gray-700 hover:text-primary-600 hover:bg-gray-50">Log in</a>
              <a href="/register.html" class="block px-3 py-2 rounded-md text-base font-medium text-primary-600 hover:text-primary-700 hover:bg-gray-50">Sign up</a>
            </div>
          </div>
        </div>
      </div>
    `;

    // Insert navigation at the beginning of body
    const firstElement = document.body.firstChild;
    document.body.insertBefore(nav, firstElement);
  }

  static setupEventListeners() {
    // Mobile menu toggle
    const mobileMenuButton = document.getElementById('mobileMenuButton');
    const mobileMenu = document.getElementById('mobileMenu');

    mobileMenuButton?.addEventListener('click', () => {
      mobileMenu.classList.toggle('hidden');
      const icons = mobileMenuButton.querySelectorAll('svg');
      icons.forEach(icon => icon.classList.toggle('hidden'));
    });

    // User dropdown
    const userMenuButton = document.getElementById('userMenuButton');
    const userMenu = document.getElementById('userMenu');

    userMenuButton?.addEventListener('click', () => {
      userMenu.classList.toggle('hidden');
    });

    // Close dropdown when clicking outside
    document.addEventListener('click', (e) => {
      if (!e.target.closest('#userDropdown')) {
        userMenu?.classList.add('hidden');
      }
    });

    // Logout buttons
    document.getElementById('logoutBtn')?.addEventListener('click', () => {
      this.handleLogout();
    });

    document.getElementById('mobileLogoutBtn')?.addEventListener('click', () => {
      this.handleLogout();
    });

    // Listen for auth state changes
    State.onStateChange(() => {
      this.updateAuthState();
    });
  }

  static updateAuthState() {
    const isAuthenticated = State.isAuthenticated;
    const user = State.user;

    // Update visibility based on auth state
    const authElements = document.querySelectorAll('.auth-only');
    const guestElements = document.querySelectorAll('.guest-only');

    authElements.forEach(el => {
      el.classList.toggle('hidden', !isAuthenticated);
    });

    guestElements.forEach(el => {
      el.classList.toggle('hidden', isAuthenticated);
    });

    // Update user info
    if (isAuthenticated && user) {
      this.updateUserInfo(user);
    }
  }

  static updateUserInfo(user) {
    const elements = {
      userName: document.getElementById('userName'),
      userEmail: document.getElementById('userEmail'),
      userAvatar: document.getElementById('userAvatar'),
      mobileUserName: document.getElementById('mobileUserName'),
      mobileUserEmail: document.getElementById('mobileUserEmail'),
      mobileUserAvatar: document.getElementById('mobileUserAvatar')
    };

    // Update names
    const fullName = `${user.firstName || ''} ${user.lastName || ''}`.trim() || user.email;
    elements.userName?.forEach(el => el.textContent = fullName);
    elements.mobileUserName?.forEach(el => el.textContent = fullName);

    // Update emails
    elements.userEmail?.forEach(el => el.textContent = user.email);
    elements.mobileUserEmail?.forEach(el => el.textContent = user.email);

    // Update avatars
    const avatarUrl = user.profileImage || 'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80';
    elements.userAvatar?.forEach(el => el.src = avatarUrl);
    elements.mobileUserAvatar?.forEach(el => el.src = avatarUrl);
  }

  static highlightActivePage() {
    const currentPage = this.getCurrentPage();
    const navLinks = document.querySelectorAll('.nav-link, .mobile-nav-link');

    navLinks.forEach(link => {
      const page = link.dataset.page;
      if (page === currentPage) {
        link.classList.add('bg-primary-50', 'text-primary-700');
        link.classList.remove('text-gray-700');
      } else {
        link.classList.remove('bg-primary-50', 'text-primary-700');
        link.classList.add('text-gray-700');
      }
    });
  }

  static getCurrentPage() {
    const path = window.location.pathname;
    const page = path.replace(/\.html$/, '').replace(/^\/+/, '') || 'home';
    return page === 'index' ? 'home' : page;
  }

  static async handleLogout() {
    try {
      await Auth.logout();
      Toast.success('Logged out successfully');
    } catch (error) {
      console.error('Logout error:', error);
      // Even if logout fails, clear local state
      State.setUser(null);
      window.location.href = '/login.html';
    }
  }
}