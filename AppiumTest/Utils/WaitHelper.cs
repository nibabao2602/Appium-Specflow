using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AppiumTest.Utils
{
    public class WaitHelpers
    {
        private static WebDriverWait wait;
        private static WebDriverWait longWait;
        private TimeSpan TIME_OUT = TimeSpan.FromSeconds(10);
        
        public WaitHelpers(){
            wait = new WebDriverWait(AppiumDriverHelper.GetDriver(), TIME_OUT);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(WebDriverTimeoutException));
        }
        
        public static WebDriverWait GetWait() {
            return wait;
        }
        public static IWebElement WaitForElementVisible(By by) {
            return wait.Until(EC.ElementIsVisible(by));
        }
        public void WaitForElementClickable(IWebElement element) {
            wait.Until(EC.ElementToBeClickable(element));
        }
        public IWebElement WaitForElementLocated(By by) {
            wait.Until(EC.ElementExists(by));
            return WaitForElementVisible(by);
        }
        public void WaitForSpecificTime(int time) {
            Thread.Sleep(time);
        }
    }
}