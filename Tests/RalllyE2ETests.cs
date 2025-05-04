using NUnit.Framework;
using RalllyTestingProject.Pages;

namespace RalllyTestingProject.Tests
{
    [TestFixture]
    public class RalllyE2ETests : BaseTest
    {
        [Test]
        public void GivenUserCreatesPoll_WhenPollSubmitted_ThenPollLinkIsDisplayed()
        {
            HomePage.Open()
                    .WaitUntilLoaded()
                    .ClickCreatePoll();

            var pollPage = GetPage<PollCreationPage>()
                           .WaitUntilLoaded()
                           .EnterTitle("My Automated Poll")
                           .PickTodayDate()
                           .ClickNext()
                           .ClickNext(); // skip extra steps

            Assert.That(pollPage.IsShareLinkDisplayed(), Is.True, "Poll link was not displayed.");
        }

        [Test]
        public void GivenUserCreatesPoll_WhenPollLinkOpened_ThenPollIsDisplayed()
        {
            string testTitle = "My Second Automated Poll";
            var pollPage = HomePage.Open()
                                   .WaitUntilLoaded()
                                   .ClickCreatePoll();

            var creationPage = GetPage<PollCreationPage>()
                               .WaitUntilLoaded()
                               .EnterTitle(testTitle)
                               .PickTodayDate()
                               .ClickNext()
                               .ClickNext();

            string pollLink = creationPage.GetPollLink();

            Driver.Navigate().GoToUrl("https://" + pollLink);

            var pollPageObj = GetPage<PollPage>()
                              .WaitUntilLoaded();

            Assert.That(pollPageObj.IsAt(), Is.True, "Poll page was not loaded correctly.");
            Assert.That(pollPageObj.GetPollTitle(), Is.EqualTo(testTitle), "Poll title mismatch.");
        }
    }
}
