using OpenQA.Selenium;

namespace CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _timeout;
        private const int defaultLocalWaitTimeSeconds = 10;
        private const int defaultGlobalWaitTimeSeconds = 0;

        public WebDriverWrapper(IWebDriver driver, int localWaitTimeSeconds = defaultLocalWaitTimeSeconds)
        {
            this._driver = driver;
            this._timeout = TimeSpan.FromSeconds(localWaitTimeSeconds);
        }

        public void SetGlobalWaitTime(int globalWaitTimeSeconds = defaultGlobalWaitTimeSeconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(globalWaitTimeSeconds);
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
