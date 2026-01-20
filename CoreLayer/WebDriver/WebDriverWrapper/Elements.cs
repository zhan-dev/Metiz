using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        public void Click(By by)
        {
            WaitForElementToBePresent(_driver, by, _timeout).Click();
        }

        public void EnterText(By by, string text)
        {
            var element = WaitForElementToBePresent(_driver, by, _timeout);
            element.Clear();
            element.SendKeys(text);
        }
        public IWebElement FindElement(By by)
        {
            var elementPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementPresent.FindElement(by);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elementsPresent = WaitForElementToBePresent(_driver, by, _timeout);
            return elementsPresent.FindElements(by);
        }

        public IWebElement FindChildByName(By byParent, string childName)
        {
            var elementParent = WaitForElementToBePresent(_driver, byParent, _timeout);
            return elementParent.FindElement(By.Name(childName));
        }

        public void ClickAndSendAction(IWebElement element, string textToSend)
        {
            var clickAndSendKeysActions = new Actions(_driver);
            clickAndSendKeysActions.Click(element)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(textToSend)
                .Perform();
        }

        public static IWebElement WaitForElementToBePresent(IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);

            return wait.Until(drv =>
            {
                try
                {
                    var element = drv.FindElement(by);
                    return element.Displayed ? element : null;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"WaitForElementToBePresent method: 'ArgumentNullException' is found.");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("WaitForElementToBePresent method: 'NoSuchElementException' is found.");
                }

                return null;
            });
        }
    }
}
