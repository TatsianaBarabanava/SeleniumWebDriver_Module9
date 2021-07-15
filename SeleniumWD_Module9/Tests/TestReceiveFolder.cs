using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestReceiveFolder : BaseTest
    {
        [Test]
        public void ReceiveFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(yandexEmailInstance);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.ClickOnRecepientField(yandexEmailInstance.Email); 
            draftPage.ClickOnSendButtonWithActions();
            Browser.PressEscape();
            var receivePage = draftPage.ClickOnInboxFolder();
            Browser.RefreshPage();

            //Assert
            var actualSender = receivePage.GetTextFromRecepientField(yandexEmailInstance.Email); 
            var actualSubject = receivePage.GetTextFromMailTopicField();
            var actualContent = receivePage.GetTextFromContentField();
            Assert.AreEqual(yandexEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.IsTrue(actualSubject.Contains(yandexEmailInstance.Subject), "Email Subject field has an invalid value");
            Assert.AreEqual(receivePage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}