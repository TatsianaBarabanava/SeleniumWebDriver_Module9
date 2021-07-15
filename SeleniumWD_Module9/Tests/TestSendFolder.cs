using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendFolder : BaseTest
    {
       
        [Test]
        public void SendFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmailInstance);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.ClickOnRecepientField(gmailEmailInstance.Email);
            draftPage.ClickOnSendButtonWithActions();
            Browser.PressEscape();
            var sendPage = draftPage.ClickOnSendFolder();

            //Assert
            var actualSender = sendPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = sendPage.GetTextFromMailTopicField();
            var actualContent = sendPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(sendPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}