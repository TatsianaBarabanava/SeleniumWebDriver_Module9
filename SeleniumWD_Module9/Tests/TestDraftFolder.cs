using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDraftFolder : BaseTest
    {

         [Test]
        public void DraftContent()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmailInstance);
            Browser.PressEscape();
            mailPage.resendLink.WaitForIsVisible();
            var draftPage = mailPage.ClickOnDraftLink();

            //Assert
            var actualSender = draftPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = draftPage.GetTextFromMailTopicField();
            var actualContent = draftPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(draftPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}