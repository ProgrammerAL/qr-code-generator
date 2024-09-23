/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "../../QrCodeHelpers/wwwroot/index.html",
    "../../QrCodeHelpers/App.razor",
    "../../QrCodeHelpers/Pages/*.{html,razor}",
    "../../QrCodeHelpers/Pages/**/*.{html,razor}",
    "../../QrCodeHelpers/Components/*.{html,razor}",
    "../../QrCodeHelpers/Components/**/*.{html,razor}",
    "../../QrCodeHelpers/Shared/*.{html,razor}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
