# RalllyTestingProject

Test Automation project using C#, Selenium, and NUnit to automate UI tests for [rallly.co](https://rallly.co).

## Features
- UI Tests using Selenium WebDriver
- Page Object Model (POM) with Fluent API
- NUnit as test runner
- Tests for Registration and Poll creation flows
- Ready to run with `dotnet test`

## Tech stack
- **C#**
- **Selenium WebDriver**
- **NUnit**
- **ChromeDriver**

## How to run tests

1. Make sure you have .NET SDK installed (>= 7.0). You can check it with:
    ```bash
    dotnet --version
    ```

2. Clone this repository:
    ```bash
    git clone https://github.com/mozolmateusz/RalllyTestingProject.git
    cd RalllyTestingProject
    ```

3. Run tests:
    ```bash
    dotnet test
    ```

Tests will run in **Chrome** browser by default.

---

## Test coverage so far
- Smoke tests for Rallly Home and Register pages
- End-to-End test for creating a new poll (without registration)
- More E2E tests coming soon...

---

## Planned next steps
- Add negative tests (e.g., invalid email, missing poll title)
- Add parameterized tests with `TestCaseSource`
- Add screenshots on test failure
- Setup GitHub Actions for CI/CD test runs

---

### About Rallly
[Rallly.co](https://rallly.co) is an open-source meeting poll platform. This test project is for educational and portfolio purposes only.
