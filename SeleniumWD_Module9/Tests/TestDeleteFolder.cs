using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDeleteFolder : BaseTest
    {

        [Test]
        public void DeleteFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            mailPage.ComposeEmailWithRandomContent(gmailEmailInstance);
            Browser.PressEscape();
            var draftPage = mailPage.ClickOnDraftLink();
            draftPage.SelectEmailByNumber(0, gmailEmailInstance.Email);
            draftPage.deleteButton.Click();
            var deletePage = draftPage.ClickOnDeleteFolder();

            //Assert
            var actualSender = deletePage.GetTextFromRecepientField(yandexEmailInstance.Email);
            var actualSubject = deletePage.GetTextFromMailTopicField();
            var actualContent = deletePage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(deletePage.GetTextFromContentField(), actualContent,  "Content field has an invalid value");
        }
    }
}