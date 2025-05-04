using OpenQA.Selenium;

namespace RalllyTestingProject.Pages
{
    public class PollCreationPage : BasePage
    {
        private readonly By _titleInput = By.Name("title");
        private readonly By _nextButton = By.CssSelector("button[type='submit']");
        private readonly By _shareLink = By.CssSelector("span.min-w-0.truncate");

        public PollCreationPage(IWebDriver driver) : base(driver) { }

        public PollCreationPage WaitUntilLoaded()
        {
            WaitUntilVisible(_titleInput);
            return this;
        }

        public PollCreationPage EnterTitle(string title)
        {
            var titleInput = WaitUntilVisible(_titleInput);
            titleInput.Clear();
            titleInput.SendKeys(title);
            return this;
        }

        public PollCreationPage PickTodayDate()
        {
            int today = DateTime.Now.Day;

            var dayButton = WaitUntilClickable(By.XPath($"//span[contains(@class, 'z-10') and text()='{today}']"));
            dayButton.Click();

            return this;
        }

        public PollCreationPage ClickNext()
        {
            WaitUntilClickable(_nextButton).Click();
            return this;
        }

        public bool IsShareLinkDisplayed()
        {
            try
            {
                var linkSpan = WaitUntilVisible(_shareLink);
                return linkSpan.Text.Contains("rallly.co/invite/");
            }
            catch
            {
                return false;
            }
        }

        public string GetPollLink()
        {
            var linkSpan = WaitUntilVisible(_shareLink);
            return linkSpan.Text;
        }
    }
}
