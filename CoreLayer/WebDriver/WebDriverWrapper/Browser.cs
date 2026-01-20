using OpenQA.Selenium;

namespace CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _timeout;
        private const int ImplicitWaitTimeInSeconds = 10;
        private const int ExplicitWaitTimeInSeconds = 10;

        public WebDriverWrapper(IWebDriver driver)
        {
            this._driver = driver;
            this._timeout = TimeSpan.FromSeconds(ExplicitWaitTimeInSeconds);
        }

        public void ImplicitWaitTime(int implicitWaitTime = ImplicitWaitTimeInSeconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public void Close()
        {
            _driver?.Dispose();
        }
    }
}
