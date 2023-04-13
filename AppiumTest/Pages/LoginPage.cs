using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class LoginPage : BasePage
    {
        
        [FindsBy(How = How.Custom, Using = "editTextEmail", CustomFinderType = typeof(ById))]
        [FindsBy(How = How.XPath, Using = "//XCUIElementTypeStaticText[@name='Email']/following-sibling::*/XCUIElementTypeTextField")]
        protected IWebElement emailInput;

        [FindsBy(How = How.Custom, Using = "editTextPassword", CustomFinderType = typeof(ById))]
        [FindsBy(How = How.XPath, Using = "//XCUIElementTypeStaticText[@name='Mật Khẩu' or @name='Password']/following-sibling::*/XCUIElementTypeSecureTextField")]
        protected IWebElement passwordInput;
        
        [FindsBy(How = How.Custom, Using = "btnLogin", CustomFinderType = typeof(ById))]
        protected IWebElement loginBtn;

        [FindsBy(How = How.Custom, Using = "**/XCUIElementTypeButton[`name == 'Đăng Nhập' OR name == 'Sign in'`]", CustomFinderType = typeof(ByIosClassChain))]
        protected IWebElement loginBtn_IOS;
        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public LoginPage FillLoginForm(string email, string password)
        {
            emailInput.Clear();
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            return this;
        }
        public void ClickOnLoginButton()
        {
            if(isIOS) loginBtn_IOS.Click();
            else loginBtn.Click();
        }
    }
}