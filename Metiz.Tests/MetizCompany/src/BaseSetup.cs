using CoreLayer.Enums;
using CoreLayer.WebDriver;
using CoreLayer.WebDriver.WebDriverWrapper;

namespace Metiz.Tests.MetizCompany.src
{
    internal abstract class BaseSetup
    {
        protected WebDriverWrapper driverWrapper;

        [SetUp]
        public virtual void SetUp()
        {
            var chromeDriver = new ChromeDriverFactory();
            var driver = chromeDriver.CreateDriver(WebBrowserMode.Silent);

            this.driverWrapper = new WebDriverWrapper(driver);
            this.driverWrapper.WindowMaximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            driverWrapper?.Close();
        }
    }
}
