// Theme Management for TradePulse
class ThemeManager {
  constructor() {
    this.currentTheme = this.getStoredTheme() || "dark";
    this.init();
  }

  init() {
    this.applyTheme(this.currentTheme);
    this.watchSystemPreference();
  }

  getStoredTheme() {
    return localStorage.getItem("tradepulse-theme");
  }

  setStoredTheme(theme) {
    localStorage.setItem("tradepulse-theme", theme);
  }

  applyTheme(theme) {
    const root = document.documentElement;
    const pageWrapper = document.querySelector(".page-wrapper");

    if (pageWrapper) {
      pageWrapper.setAttribute("data-theme", theme);
    }

    this.currentTheme = theme;
    this.setStoredTheme(theme);

    // Update theme toggle icon
    this.updateThemeToggleIcon();
  }

  toggleTheme() {
    const newTheme = this.currentTheme === "dark" ? "light" : "dark";
    this.applyTheme(newTheme);

    // Add visual feedback
    this.addToggleFeedback();

    return newTheme;
  }

  updateThemeToggleIcon() {
    const toggleButtons = document.querySelectorAll(".theme-toggle svg");
    const isDark = this.currentTheme === "dark";

    toggleButtons.forEach((svg) => {
      if (isDark) {
        // Sun icon for dark mode (clicking will enable light mode)
        svg.innerHTML = `
                    <path d="M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707" 
                          stroke="currentColor" stroke-width="2" stroke-linecap="round"/>
                `;
      } else {
        // Moon icon for light mode (clicking will enable dark mode)
        svg.innerHTML = `
                    <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z" 
                          stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                `;
      }
    });
  }

  addToggleFeedback() {
    const toggleButton = document.querySelector(".theme-toggle");
    if (toggleButton) {
      toggleButton.style.transform = "scale(0.95)";
      setTimeout(() => {
        toggleButton.style.transform = "";
      }, 150);
    }
  }

  watchSystemPreference() {
    const mediaQuery = window.matchMedia("(prefers-color-scheme: dark)");
    mediaQuery.addEventListener("change", (e) => {
      // Only auto-switch if user hasn't manually set a preference
      if (!this.getStoredTheme()) {
        this.applyTheme(e.matches ? "dark" : "light");
      }
    });
  }
}

// Global theme manager instance
window.themeManager = new ThemeManager();

// Global function for Blazor to call
window.toggleTheme = function () {
  return window.themeManager.toggleTheme();
};

// Auto-initialize when DOM is ready
if (document.readyState === "loading") {
  document.addEventListener("DOMContentLoaded", () => {
    window.themeManager.updateThemeToggleIcon();
  });
} else {
  window.themeManager.updateThemeToggleIcon();
}
