using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class JobDetailPage : BasePage
    {
        public JobDetailPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*textViewApplyNow"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement textViewApplyNow;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().text(""Successfully applied!"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement lblSuccessfulApplied;

        public void ClickOnApplyNowButton()
        {
            wait.WaitForElementClickable(textViewApplyNow);
            textViewApplyNow.Click();
        }
        public void VerifySuccessfullApplied()
        {
            Assert.True(lblSuccessfulApplied.Displayed);
        }

    }
}