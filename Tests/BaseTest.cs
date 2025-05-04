using NUnit.Framework;
using OpenQA.Selenium;
using RalllyTestingProject.Drivers;
using RalllyTestingProject.Pages;

namespace RalllyTestingProject.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected HomePage HomePage;

        [SetUp]
        public void SetUp()
        {
            Driver = WebDriverManager.CreateChromeDriver();
            HomePage = new HomePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        protected T GetPage<T>() where T : BasePage
        {
            return Activator.CreateInstance(typeof(T), Driver) as T;
        }
    }
}
