using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace RalllyTestingProject.Pages
{
    internal class DashboardPage : BasePage
    {
        // Locator for the dashboard header
        private readonly By _header = By.CssSelector("h2.text-xl"); // By.XPath("//h2[contains(text(), 'My Polls')]");

        public DashboardPage(IWebDriver driver) : base(driver) { }

        // Verifies if user is on the Dashboard page
        public bool IsAt()
        {
            return WaitUntilVisible(_header).Displayed;
        }

        // Waits until Dashboard page is fully loaded
        public DashboardPage WaitUntilLoaded()
        {
            WaitUntilVisible(_header);
            return this;
        }
    }
}
