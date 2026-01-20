using BusinessLayer.Enums;
using BusinessLayer.MetizCompany.src;
using CoreLayer.WebDriver;
using CoreLayer.WebDriver.WebDriverWrapper;

namespace Metiz.Tests.MetizCompany.src
{
    [TestFixture]
    internal class MainPageTests
    {
        //private MainPage page;
        private WebDriverWrapper driverWrapper;

        [SetUp]
        public void SetUp()
        {
            var chromeDriver = new ChromeDriverFactory();
            var driver = chromeDriver.CreateDriver(WebBrowserMode.Silent);

            this.driverWrapper = new WebDriverWrapper(driver);
            this.driverWrapper.WindowMaximize();
            this.driverWrapper.GoToUrl("https://metiz.company/ru");

            //this.page = new MainPage(this.driverWrapper);
        }

        [Test]
        public void OpenMainPage_UserIsOpenMainPage_MainPageIsLoads()
        {
            // Assert
            Assert.That(driverWrapper.GetTitle(), Is.Not.Empty);
        }

        [Test]
        public void OpenMainPage_UserIsOpenMainPage_MainPageTitleIsAsExpected()
        {
            // Assert
            Assert.That(driverWrapper.GetTitle(), 
                Is.EqualTo("ТПК Метиз. Крупнейший импортер стальных канатов и проволоки в Украине, производитель грузоподъемных строп"));
        }

        [TearDown]
        public void TearDown()
        {
            driverWrapper?.Close();
        }
    }
}
