using BusinessLayer.MetizCompany.src;

namespace Metiz.Tests.MetizCompany.src.Catalog
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class CatalogPageTests : BaseSetup
    {
        private CatalogPage page;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.page = new CatalogPage(this.driverWrapper);
            page.NavigatePage();
        }

        [Test]
        public void OpenCatalogPage_UserIsOpenCatalogPage_CatalogPageIsLoaded()
        {
            // Assert
            Assert.That(page.GetTitle(), Is.Not.Empty);
        }

        [Test]
        public void OpenCatalogPage_UserIsOpenCatalogPage_CatalogPageTitleIsAsExpected()
        {
            //Arrange
            string expectedTitle =
                "Каталог товаров. Стальные канаты, проволока, стропы, комплектующие для строп";

            // Assert
            Assert.That(page.GetTitle(),Is.EqualTo(expectedTitle));
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
