using System.Threading;
using AppiumTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AppiumTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private HomePage homepage;
        private LoginPage loginpage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            homepage = new HomePage(_scenarioContext);
            loginpage = new LoginPage(_scenarioContext);
        }

        [StepDefinition(@"Navigate to Login page")]
        public void NavigateToLoginPage()
        {
            homepage.NavigateToLoginPage();
        }

        [StepDefinition(@"Enter (.*) and (.*)")]
        public void EnterEmailAndPassword(string email, string password)
        {
            loginpage.FillLoginForm(email, password);
        }

        [StepDefinition("Homepage is displayed")]
        public void HomepageIsDisplayed()
        {
            Assert.True(homepage.IsPageDisplay());
        }

        [StepDefinition("Click on Login button")]
        public void ClickOnLoginButton()
        {
            loginpage.ClickOnLoginButton();
        }
        
        [StepDefinition(@"Wait (.*)")]
        public void WaitTime(int time)
        {
            homepage.wait.WaitForSpecificTime(time);
        }

        [StepDefinition("Dismiss Notifications After Login")]
        public void ThenDismissNotificationsAfterLogin()
        {
            homepage.SkipNotiAfterLogin();
        }
    }
}
