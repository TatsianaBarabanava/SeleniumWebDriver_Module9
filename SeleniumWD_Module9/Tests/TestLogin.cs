using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestLogin : BaseTest
    {

        [Test]
        public void Login()
        {
            //Arrange
            var homePage = new YandexHomePage();
            var actualExpression = homePage.GetTextFromComposeLink();

            //Assert
            Assert.AreEqual(composeLinkText, actualExpression, "You are on the wrong page");
        }
    }
}