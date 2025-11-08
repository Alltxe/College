# Test Website for Laboratory Work №5

This is a simple static website created for testing purposes, to be deployed on GitHub Pages.

## Website Structure

- `index.html` - Home page
- `about.html` - About page
- `contact.html` - Contact page
- `products.html` - Products page with links to individual products
- `product1.html`, `product2.html`, `product3.html` - Individual product pages
- `form.html` - Feedback form page
- `styles.css` - CSS styles
- `script.js` - JavaScript functionality

## Deployment to GitHub Pages

1. Push this repository to GitHub.
2. Go to repository settings.
3. In "Pages" section, select "Deploy from a branch" and choose `main` branch.
4. The site will be available at `https://<username>.github.io/<repository-name>/`

## Test Cases

30 test cases are described in `test_cases.md`.

## Selenium IDE Tests

15 test cases implemented in `test_suite.side`. Import this file into Selenium IDE to run the tests.

## C# Selenium Tests

Located in `Tests/WebsiteTests/`.

- `ChromeTests.cs` - 15 tests for Chrome browser
- `FirefoxTests.cs` - 15 tests for Firefox browser

### Running C# Tests

1. Ensure .NET SDK is installed.
2. Navigate to `Tests/WebsiteTests/`
3. Run `dotnet test` to execute all tests.

Note: Tests are configured to run in headless mode. Remove `--headless` from options if you want to see the browser.

## Requirements

- For C# tests: .NET 6+, Chrome or Firefox browser installed.
- For Selenium IDE: Selenium IDE extension installed in browser.