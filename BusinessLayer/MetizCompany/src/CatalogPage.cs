using CoreLayer.WebDriver.WebDriverWrapper;

namespace BusinessLayer.MetizCompany.src
{
    internal class CatalogPage
    {
        private readonly WebDriverWrapper _driverWrapper;
        //private string Url { get; } = "https://metiz.company/ru/katalog";

        public CatalogPage(WebDriverWrapper driver)
        {
            this._driverWrapper = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        //public void NavigatePage()
        //{
        //    _driverWrapper.GoToUrl(Url);
        //}

        //public string GetTitle()
        //{
        //    return _driverWrapper.GetTitle();
        //}
    }
}
