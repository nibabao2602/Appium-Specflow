using AppiumTest.Utils;
using AppiumTest.Wrapper;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class HomePage : BasePage
    {

        [FindsBy(How = How.Custom, Using = @"new UiSelector().text(""Menu"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement presonalTab;

        [FindsBy(How = How.Custom, Using = "**/XCUIElementTypeButton[`label == 'img person circle'`]", CustomFinderType = typeof(ByIosClassChain))]
        protected IWebElement presonalTab_IOS;

        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*btnSignIn"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement signInBtn;
        // [FindsBy(How = How.Custom, Using = "btnSignIn", CustomFinderType = typeof(ById))]
        // protected IWebElement signInBtn;
        [FindsBy(How = How.Custom, Using = "**/XCUIElementTypeButton[`label == 'Đăng Nhập hoặc Đăng Ký' OR label == 'Sign in or Sign up'`]", CustomFinderType = typeof(ByIosClassChain))]
        protected IWebElement signInBtn_IOS;
        [FindsBy(How = How.Custom, Using = @"new UiSelector().resourceIdMatches("".*btnSubmit"")", CustomFinderType = typeof(ByAndroidUIAutomator))]
        protected IWebElement skipBtn;

        // [FindsBy(How = How.Custom, Using = "btnSubmit", CustomFinderType = typeof(ById))]
        // protected IWebElement skipBtn;
        [FindsBy(How = How.Custom, Using = "**/XCUIElementTypeButton[`label == 'Bỏ qua' OR label == 'Skip'`]", CustomFinderType = typeof(ByIosClassChain))]
        protected IWebElement skipBtn_IOS;
        private readonly ScenarioContext _scenarioContext;

        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public LoginPage NavigateToLoginPage()
        {
            if (isIOS)
            {
                presonalTab_IOS.Click();
                signInBtn_IOS.Click();
            }
            else
            {
                wait.WaitForElementClickable(presonalTab);
                presonalTab.Click();

                wait.WaitForElementClickable(signInBtn);
                signInBtn.Click();
            }
            return new LoginPage(_scenarioContext);
        }
        public HomePage SkipNotiAfterLogin()
        {
            if (isIOS) {
                wait.WaitForElementClickable(skipBtn_IOS);
                skipBtn_IOS.Click();
            } 
            else
            {
                wait.WaitForElementClickable(skipBtn);
                skipBtn.Click();
            }
            return this;
        }
        public bool IsPageDisplay()
        {
            if (isIOS) return presonalTab_IOS != null ? presonalTab_IOS.Displayed : false;
            return presonalTab != null ? presonalTab.Displayed : false;
        }
    }
}