using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class FilePage : BasePage
    {
        public FilePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        [FindsBy(How = How.Custom, Using = "Show roots", CustomFinderType = typeof(ByAccessibilityId))]
        protected IWebElement ShowRoot;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().text(""Downloads"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement downloadTab;
        protected IWebElement file(string fileName) => AppiumDriverHelper.GetDriver().FindElement(MobileBy.AndroidUIAutomator($@"new UiSelector().textContains(""{fileName}"")"));

        public void ChooseFileInGalery(string fileName)
        {
            wait.WaitForElementClickable(ShowRoot);
            ShowRoot.Click();
            downloadTab.Click();
            wait.WaitForElementClickable(file(fileName));
            file(fileName).Click();
        }
    }
}