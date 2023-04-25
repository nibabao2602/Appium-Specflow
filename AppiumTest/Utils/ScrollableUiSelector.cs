using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;

namespace AppiumTest.Utils
{
    public class ScrollableUiSelector : ByAndroidUIAutomator
    {
        public ScrollableUiSelector(string selector) : base($@"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView({selector});")
        {
        }
    }
}