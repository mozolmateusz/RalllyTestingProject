using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RalllyTestingProject.Drivers
{
    public static class WebDriverManager
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            return new ChromeDriver(options);
        }
    }
}
