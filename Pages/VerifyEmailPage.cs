using OpenQA.Selenium;

namespace RalllyTestingProject.Pages
{
    public class VerifyEmailPage : BasePage
    {
        public readonly By _header = By.CssSelector("h1.text-2xl");

        public VerifyEmailPage(IWebDriver driver) : base(driver) { }

        public bool IsAt()
        {
            bool urlCorrect = Wait.Until(driver => driver.Url.Contains("verify"));
            bool headerVisible = WaitUntilVisible(_header).Displayed;
            return urlCorrect && headerVisible;
        }

        public VerifyEmailPage WaitUntilLoaded()
        {
            WaitUntilVisible(_header);
            return this;
        }

        public string GetHeaderText()
        {
            return WaitUntilVisible(_header).Text;
        }
    }
}
