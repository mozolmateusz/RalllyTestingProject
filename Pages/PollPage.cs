using OpenQA.Selenium;

namespace RalllyTestingProject.Pages
{
    public class PollPage : BasePage
    {
        private readonly By _pollTitle = By.CssSelector("h1");

        public PollPage(IWebDriver driver) : base(driver) { }

        public PollPage WaitUntilLoaded()
        {
            WaitUntilVisible(_pollTitle);
            return this;
        }

        public bool IsAt()
        {
            return Driver.Url.Contains("/invite/") && WaitUntilVisible(_pollTitle).Displayed;
        }

        public string GetPollTitle()
        {
            return WaitUntilVisible(_pollTitle).Text;
        }
    }
}
