using BusinessLayer.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CoreLayer.WebDriver
{
    internal sealed class EdgeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver(WebBrowserMode mode)
        {
            var service = EdgeDriverService.CreateDefaultService();
            var options = new EdgeOptions();

            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--inprivate");

            if (mode is WebBrowserMode.Silent)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
            }

            return new EdgeDriver(service, options, TimeSpan.FromSeconds(30));
        }
    }
}
