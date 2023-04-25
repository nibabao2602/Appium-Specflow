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
        private JobDetailPage jobdetailpage;
        private ApplyJobPage applyjobpage;
        private FilePage filepage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            homepage = new HomePage(_scenarioContext);
            loginpage = new LoginPage(_scenarioContext);
            jobdetailpage = new JobDetailPage(_scenarioContext);
            applyjobpage = new ApplyJobPage(_scenarioContext);
            filepage = new FilePage(_scenarioContext);
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
        [StepDefinition("Go to First Job")]
        public void GoToFirstJob()
        {
            homepage.ClickOnFirstJob();
        }
        [StepDefinition("Upload file")]
        public void UploadFile()
        {
            applyjobpage.GoToUploadFile();
            filepage.ChooseFileInGalery("test.pdf");
            applyjobpage.ClickOnDoneButton();
        }
        [StepDefinition("Verify file is attached successfully")]
        public void VerifyFileIsAttach()
        {
            applyjobpage.VerifyCVIsAttached();
        }

        [StepDefinition(@"Enter job title ""(.*)""")]
        public void EnterJobTitle(string title)
        {
            applyjobpage.EnterJobTitle(title);
        }
        [StepDefinition(@"Click on confirm apply")]
        public void ClickOnConfirmApply()
        {
            applyjobpage.ClickOnConfirmApply();
        }
        [StepDefinition(@"Verify successful apply")]
        public void VerifySuccessfulApply()
        {
            jobdetailpage.VerifySuccessfullApplied();
        }

        [StepDefinition("Click on Apply Now")]
        public void ClickOnApplyNow()
        {
            jobdetailpage.ClickOnApplyNowButton();
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
