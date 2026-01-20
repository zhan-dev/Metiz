using BusinessLayer.Enums;
using BusinessLayer.MetizCompany.src;
using CoreLayer.WebDriver;
using CoreLayer.WebDriver.WebDriverWrapper;

namespace Metiz.Tests.MetizCompany.src
{
    [TestFixture]
    public class CatalogPageTests
    {
        private WebDriverWrapper driverWrapper;

        [SetUp]
        public void SetUp()
        {
            var chromeDriver = new ChromeDriverFactory();
            var driver = chromeDriver.CreateDriver(WebBrowserMode.Silent);

            this.driverWrapper = new WebDriverWrapper(driver);
            this.driverWrapper.WindowMaximize();
            this.driverWrapper.GoToUrl("https://metiz.company/ru/katalog");
        }

        [Test]
        public void OpenCatalogPage_UserIsOpenCatalogPage_CatalogPageIsLoads()
        {
            // Assert
            Assert.That(driverWrapper.GetTitle(), Is.Not.Empty);
        }

        [Test]
        public void OpenCatalogPage_UserIsOpenCatalogPage_CatalogPageTitleIsAsExpected()
        {
            // Assert
            Assert.That(driverWrapper.GetTitle(),
                Is.EqualTo("Каталог товаров. Стальные канаты, проволока, стропы, комплектующие для строп"));
        }

        [TearDown]
        public void TearDown()
        {
            driverWrapper?.Close();
        }
    }
}
