using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.BusinessObjects;

namespace SeleniumWebDriver
{
    [TestFixture]
    public abstract class BaseTest : Browser
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected static string gmailEmail = "snieczka@gmail.com";
        protected static string sender = "Tatsiana Barabanava";
        protected static string yandexEmail = "snieczka@yandex.by";
        protected string composeLinkText = "Написать письмо";
        protected readonly User user = User.GetDefaultUser();
        protected readonly EmailInstance yandexEmailInstance = EmailInstance.getInstanceWithRandomSubjectAndContent(sender, yandexEmail);
        protected readonly EmailInstance gmailEmailInstance = EmailInstance.getInstanceWithRandomSubjectAndContent(sender, gmailEmail);

        [SetUp]
        public void TestSetup()
        {
            this.driver = Browser.GetDriver();
            this.baseUrl = YandexHomePage.url;

            Browser.NavigateTo(this.baseUrl);
            Browser.WindowMaximize();
            
            var homePage = new YandexHomePage();
            homePage.ClickOnLoginButton().Login(user).WaitForComposeLinkIsVisible();
        }

        [TearDown]
          public void CleanUp()
         {
             Browser.Quit();
         }
    }
}