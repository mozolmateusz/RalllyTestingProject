using NUnit.Framework;
using RalllyTestingProject.Pages;

namespace RalllyTestingProject.Tests
{
    [TestFixture]
    public class RalllySmokeTests : BaseTest
    {
        [Test]
        public void GivenUserIsOnHomePage_WhenPageLoads_ThenTitleIsCorrect()
        {
            var isAtHomePage = HomePage.Open()
                                       .WaitUntilLoaded()
                                       .IsAt();

            Assert.That(isAtHomePage, Is.True, "User was not on Home page.");
        }

        [Test]
        public void GivenUserIsOnHomePage_WhenClickSignUpLink_ThenIsRedirectedToRegisterPage()
        {
            var isAtRegisterPage = HomePage.Open()
                                           .WaitUntilLoaded()
                                           .ClickSignUp()
                                           .WaitUntilLoaded()
                                           .IsAt();

            Assert.That(isAtRegisterPage, Is.True, "User was not navigated to the Register page.");
        }

        [Test]
        public void GivenUserIsOnRegisterPage_WhenPageLoads_ThenHeaderIsCorrect()
        {
            string headerText = HomePage.Open()
                                        .WaitUntilLoaded()
                                        .ClickSignUp()
                                        .WaitUntilLoaded()
                                        .GetHeaderText();

            Assert.That(headerText, Is.EqualTo("Create Your Account"), $"Unexpected header text: {headerText}");
        }

        [Test]
        public void GivenUserIsOnRegisterPage_WhenFillFormAndSubmit_ThenNavigatesToVerifyEmailPage()
        {
            var verifyEmailPage = HomePage.Open()
                                  .WaitUntilLoaded()
                                  .ClickSignUp()
                                  .WaitUntilLoaded()
                                  .EnterEmail($"testUser_{DateTime.Now.Ticks}@example.com")
                                  .EnterName("John Wick")
                                  .ClickRegister()
                                  .WaitUntilLoaded(); 
            
            Assert.That(verifyEmailPage.IsAt(), Is.True, "User was not navigated to the Verify Email page.");
            Assert.That(verifyEmailPage.GetHeaderText(), Does.Contain("Finish Registering"));
        }

        [Test]
        public void GivenUserIsOnRegisterPage_WhenSubmitInvalidEmail_ThenShowsValidationError()
        {
            string errorMessage = HomePage.Open()
                                          .WaitUntilLoaded()
                                          .ClickSignUp()
                                          .WaitUntilLoaded()
                                          .EnterEmail("invalid-email")
                                          .EnterName("John Wick")
                                          .ClickRegisterExpectingError()
                                          .GetEmailErrorMessage();

            Assert.That(errorMessage, Is.EqualTo("Invalid email"), $"Unexpected error message: {errorMessage}");
        }
    }
}
