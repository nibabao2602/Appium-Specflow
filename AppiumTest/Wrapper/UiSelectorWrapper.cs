using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumTest.Wrapper
{
    public static class UiSelectorWrapper
    {
        public static By ByResourceId(string text) {
            string locator = string.Format(@"new UiSelector().resourceId(""{0}"")", text);
            return MobileBy.AndroidUIAutomator(locator);
        }
        public static By ByText(string text) {
            string locator = string.Format(@"new UiSelector().text(""{0}"")", text);
            return MobileBy.AndroidUIAutomator(locator);
        }
    }
}