using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumWebDriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(BrowserType.TypesList type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.TypesList.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.TypesList.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.TypesList.remoteFirefox:
                    {
                        var capability = new DesiredCapabilities();
                        capability.SetCapability(CapabilityType.BrowserName, "firefox");
                        capability.SetCapability(CapabilityType.PlatformName, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
                        break;
                    }
                case BrowserType.TypesList.remoteChrome:
                    {
                        var capability = new DesiredCapabilities();
                        capability.SetCapability(CapabilityType.BrowserName, "chrome");
                        capability.SetCapability(CapabilityType.PlatformName, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
                        break;
                    }
            }
            return driver;
        }
    }
}