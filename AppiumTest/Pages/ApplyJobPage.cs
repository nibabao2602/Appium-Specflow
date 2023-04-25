using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class ApplyJobPage : BasePage
    {
        public ApplyJobPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*upload_btn"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement upload_btn;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*linearUpload"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement linearUpload;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*btnDone"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement btnDone;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*checkbox_attached_cv"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement checkbox_attached_cv;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*edtJobTitle"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement edtJobTitle;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*send_btn"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement send_btn;

        public void GoToUploadFile()
        {
            AppiumDriverHelper.GetDriver().PushFile("/sdcard/download/test.pdf", new FileInfo("/Users/nhict/Desktop/Projects/Appium-Specflow/AppiumTest/Asset/candidate2.pdf"));
            wait.WaitForElementClickable(upload_btn);
            upload_btn.Click();
            linearUpload.Click();
        }
        public void ClickOnDoneButton()
        {
            wait.WaitForElementClickable(btnDone);
            btnDone.Click();
        }
        public void VerifyCVIsAttached(bool isAttached = true)
        {
            Assert.AreEqual(bool.Parse(checkbox_attached_cv.GetAttribute("checked")), isAttached);
        }

        public void EnterJobTitle(string title)
        {
            edtJobTitle.SendKeys(title);
        }
        public void ClickOnConfirmApply()
        {
            send_btn.Click();
        }

    }
}