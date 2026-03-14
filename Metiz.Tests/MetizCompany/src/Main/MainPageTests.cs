using BusinessLayer.MetizCompany.src;

namespace Metiz.Tests.MetizCompany.src.Main
{
    [TestFixture]
    internal class MainPageTests : BaseSetup
    {
        private MainPage page;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.page = new MainPage(this.driverWrapper);
            page.NavigatePage();
        }

        [Test]
        public void OpenMainPage_UserIsOpenMainPage_MainPageIsLoaded()
        {
            // Assert
            Assert.That(page.GetTitle(), Is.Not.Empty);
        }

        [Test]
        public void OpenMainPage_UserIsOpenMainPage_MainPageTitleIsAsExpected()
        {
            //Arrange
            string expectedTitle = 
                "ТПК Метиз. Крупнейший импортер стальных канатов и проволоки в Украине, производитель грузоподъемных строп";

            // Assert
            Assert.That(page.GetTitle(), Is.EqualTo(expectedTitle));
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
