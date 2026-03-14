using CoreLayer.Enums;
using OpenQA.Selenium;

namespace CoreLayer.WebDriver
{
    internal interface IWebDriverFactory
    {
        public IWebDriver CreateDriver(WebBrowserMode mode);
    }
}
