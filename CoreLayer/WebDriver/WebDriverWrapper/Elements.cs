using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CoreLayer.WebDriver.WebDriverWrapper
{
    internal partial class WebDriverWrapper
    {
        public void Click(By by, int waitTime = defaultLocalWaitTimeSeconds)
        {
            WaitForElementToBePresent(this._driver, by, this.Timeout(waitTime)).Click();
        }

        public void EnterText(By by, string text, int waitTime = defaultLocalWaitTimeSeconds)
        {
            var element = WaitForElementToBePresent(this._driver, by, Timeout(waitTime));
            element.Clear();
            element.SendKeys(text);
        }

        public void ClearText(By by, int waitTime = defaultLocalWaitTimeSeconds)
        {
            var element = WaitForElementToBePresent(this._driver, by, Timeout(waitTime));
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public IWebElement FindElement(By by, int waitTime = defaultLocalWaitTimeSeconds)
        {
            var elementPresent = WaitForElementToBePresent(this._driver, by, Timeout(waitTime));
            return elementPresent.FindElement(by);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by, int waitTime = defaultLocalWaitTimeSeconds)
        {
            var elementsPresent = WaitForElementToBePresent(this._driver, by, Timeout(waitTime));
            return elementsPresent.FindElements(by);
        }

        public IWebElement FindChildByName(By byParent, string childName, int waitTime = defaultLocalWaitTimeSeconds)
        {
            var elementParent = WaitForElementToBePresent(this._driver, byParent, Timeout(waitTime));
            return elementParent.FindElement(By.Name(childName));
        }

        public void ClickAndSendAction(IWebElement element, string textToSend)
        {
            var clickAndSendKeysActions = new Actions(this._driver);
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

        private TimeSpan Timeout(int waitTime)
        {
            return waitTime is 0 ? this._timeout : TimeSpan.FromSeconds(waitTime);
        }
    }
}
