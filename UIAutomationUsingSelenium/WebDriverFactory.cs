using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationUsingSelenium
{
    public static class WebDriverFactory
    {
        public static ChromeDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
