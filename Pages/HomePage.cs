using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace RalllyTestingProject.Pages
{
    public class HomePage : BasePage
    {
        // Locators
        private readonly By _signInLink = By.CssSelector("a[href=\"https://app.rallly.co/login\"]"); //By.XPath("//a[contains(text(), 'Sign in')]");
        private readonly By _signUpLink = By.CssSelector("a[href=\"https://app.rallly.co/register\"]"); //By.XPath("//a[contains(text(), 'Sign Up')]");

        private const string HomeUrl = "https://rallly.co/en";

        public HomePage(IWebDriver driver) : base(driver) { }

        // Verifies if user is on the Home Page
        public bool IsAt()
        {
            return Wait.Until(driver => driver.Title.Contains("Rallly"));
        }

        // Opens the home page
        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            return this;
        }

        // Waits until Home Page is fully loaded
        public HomePage WaitUntilLoaded()
        {
            WaitUntilVisible(_signInLink);
            return this;
        }

        // Clicks on the "Sign Up" link
        public RegisterPage ClickSignUp()
        {
            WaitUntilClickable(_signUpLink).Click();
            return GetPage<RegisterPage>();
        }

        // Gets the current page title
        public string GetTitle()
        {
            return Driver.Title;
        }
    }
}
