using OpenQA.Selenium;

namespace RalllyTestingProject.Pages
{
    public class RegisterPage : BasePage
    {
        // Locators
        private readonly By _header = By.CssSelector("h1.text-2xl"); // By.XPath("//h1[contains(text(), 'Create Your Account')]");
        private readonly By _emailInput = By.Name("email");
        private readonly By _nameInput = By.Name("name");
        private readonly By _registerButton = By.CssSelector("button[type='submit']");
        private readonly By _emailError = By.Id("«r1»-form-item-message");

        public RegisterPage(IWebDriver driver) : base(driver) { }

        // Verifies if user is on the Register Page
        public bool IsAt()
        {
            bool isUrlCorrect = Wait.Until(driver => driver.Url.Contains("register"));
            bool isHeaderVisible = WaitUntilVisible(_header).Displayed;
            return isUrlCorrect && isHeaderVisible;
        }

        // Waits until Register Page is fully loaded
        public RegisterPage WaitUntilLoaded()
        {
            WaitUntilVisible(_header);
            return this;
        }

        // Fills in the Email field
        public RegisterPage EnterEmail(string email)
        {
            var emailInput = WaitUntilVisible(_emailInput);
            emailInput.Clear();
            emailInput.SendKeys(email);
            return this;
        }

        // Fills in the Name field
        public RegisterPage EnterName(string name)
        {
            var nameInput = WaitUntilVisible(_nameInput);
            nameInput.Clear();
            nameInput.SendKeys(name);
            return this;
        }

        // Clicks the Register button
        public VerifyEmailPage ClickRegister() // Positive flow
        {
            WaitUntilClickable(_registerButton).Click();
            return GetPage<VerifyEmailPage>(); //Move to next page
        }
        public RegisterPage ClickRegisterExpectingError() // Negative flow
        {
            WaitUntilClickable(_registerButton).Click();
            return this; // Stay on the same page
        }

        // Gets the Register page header text
        public string GetHeaderText()
        {
            return WaitUntilVisible(_header).Text;
        }

        // Gets the validation error message for Email field
        public string GetEmailErrorMessage()
        {
            return WaitUntilVisible(_emailError).Text;
        }
    }
}
