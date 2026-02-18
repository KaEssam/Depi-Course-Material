// Form Validation Utility
export const Validation = {
  // Validation Schemas
  schemas: {
    login: {
      email: {
        required: true,
        pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
        message: 'Please enter a valid email address'
      },
      password: {
        required: true,
        message: 'Password is required'
      }
    },
    register: {
      email: {
        required: true,
        pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
        maxLength: 255,
        message: 'Please enter a valid email address'
      },
      firstName: {
        required: true,
        minLength: 1,
        maxLength: 100,
        pattern: /^[a-zA-Z\s'-]+$/,
        message: 'First name must be 1-100 characters (letters, spaces, hyphens, apostrophes)'
      },
      lastName: {
        required: true,
        minLength: 1,
        maxLength: 100,
        pattern: /^[a-zA-Z\s'-]+$/,
        message: 'Last name must be 1-100 characters (letters, spaces, hyphens, apostrophes)'
      },
      password: {
        required: true,
        minLength: 8,
        maxLength: 100,
        pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/,
        message: 'Password must be 8-100 characters with uppercase, lowercase, number, and special character'
      },
      confirmPassword: {
        required: true,
        custom: 'validatePasswordMatch',
        message: 'Passwords must match'
      }
    },
    profile: {
      bio: {
        maxLength: 500,
        message: 'Bio must be less than 500 characters'
      },
      phone: {
        pattern: /^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,9}$/,
        message: 'Please enter a valid phone number'
      }
    }
  },

  // Validation Functions
  validateField(value, rules, formData = {}) {
    if (!rules) return { isValid: true, error: '' };

    // Required validation
    if (rules.required && (!value || value.toString().trim() === '')) {
      return { isValid: false, error: rules.message || 'This field is required' };
    }

    // Skip other validations if field is empty and not required
    if (!value || value.toString().trim() === '') {
      return { isValid: true, error: '' };
    }

    // Min length validation
    if (rules.minLength && value.length < rules.minLength) {
      return { isValid: false, error: rules.message || `Minimum length is ${rules.minLength} characters` };
    }

    // Max length validation
    if (rules.maxLength && value.length > rules.maxLength) {
      return { isValid: false, error: rules.message || `Maximum length is ${rules.maxLength} characters` };
    }

    // Pattern validation
    if (rules.pattern && !rules.pattern.test(value)) {
      return { isValid: false, error: rules.message || 'Invalid format' };
    }

    // Custom validation
    if (rules.custom) {
      const customResult = this.runCustomValidation(rules.custom, value, formData);
      if (!customResult.isValid) {
        return { isValid: false, error: customResult.error || rules.message };
      }
    }

    return { isValid: true, error: '' };
  },

  runCustomValidation(validationType, value, formData) {
    switch (validationType) {
      case 'validatePasswordMatch':
        return {
          isValid: value === formData.password,
          error: value !== formData.password ? 'Passwords must match' : ''
        };

      case 'validateEmailAvailable':
        // This would typically be an API call
        return { isValid: true, error: '' };

      default:
        return { isValid: true, error: '' };
    }
  },

  validateForm(formData, schema) {
    const errors = {};
    const isValid = true;

    for (const fieldName in schema) {
      const fieldRules = schema[fieldName];
      const fieldValue = formData[fieldName];
      const validation = this.validateField(fieldValue, fieldRules, formData);

      if (!validation.isValid) {
        errors[fieldName] = validation.error;
      }
    }

    return {
      isValid: Object.keys(errors).length === 0,
      errors
    };
  },

  // Real-time validation
  addFieldValidation(formElement, fieldName, rules, formData = {}) {
    const input = formElement.querySelector(`[name="${fieldName}"]`);
    if (!input) return;

    const errorElement = formElement.querySelector(`[data-error="${fieldName}"]`) ||
      this.createErrorElement(formElement, fieldName);

    // Validate on blur
    input.addEventListener('blur', () => {
      const value = input.value;
      const validation = this.validateField(value, rules, formData);

      if (validation.isValid) {
        input.classList.remove('border-red-500');
        input.classList.add('border-gray-300');
        errorElement.textContent = '';
      } else {
        input.classList.add('border-red-500');
        input.classList.remove('border-gray-300');
        errorElement.textContent = validation.error;
      }
    });

    // Clear error on input
    input.addEventListener('input', () => {
      if (input.classList.contains('border-red-500')) {
        input.classList.remove('border-red-500');
        input.classList.add('border-gray-300');
        errorElement.textContent = '';
      }
    });
  },

  createErrorElement(formElement, fieldName) {
    const errorDiv = document.createElement('div');
    errorDiv.setAttribute('data-error', fieldName);
    errorDiv.className = 'form-error';
    errorDiv.textContent = '';

    const input = formElement.querySelector(`[name="${fieldName}"]`);
    if (input && input.parentNode) {
      input.parentNode.insertBefore(errorDiv, input.nextSibling);
    }

    return errorDiv;
  },

  // Utility validation methods
  isEmail(email) {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  },

  isPhone(phone) {
    return /^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,9}$/.test(phone);
  },

  isStrongPassword(password) {
    return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/.test(password) &&
           password.length >= 8;
  },

  sanitizeInput(input) {
    return input
      .trim()
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;')
      .replace(/"/g, '&quot;')
      .replace(/'/g, '&#x27;');
  }
};