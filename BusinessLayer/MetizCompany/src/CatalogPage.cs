using CoreLayer.WebDriver.WebDriverWrapper;

namespace BusinessLayer.MetizCompany.src
{
    internal class CatalogPage
    {
        private readonly WebDriverWrapper driverWrapper;
        private string Url { get; } = "https://metiz.company/ru/katalog";

        public CatalogPage(WebDriverWrapper driver)
        {
            this.driverWrapper = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public void NavigatePage()
        {
            driverWrapper.GoToUrl(Url);
        }

        public string GetTitle()
        {
            return driverWrapper.GetTitle();
        }
    }
}
