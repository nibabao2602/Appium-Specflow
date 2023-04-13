using TechTalk.SpecFlow;

namespace AppiumTest.Hook
{
    [Binding]
    public class Hook
    {
        private readonly ScenarioContext _scenarioContext;

        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Initialize()
        {
            _scenarioContext.Set(AppiumDriverHelper.GetDriver());
        }
        
        [AfterScenario]
        public void CleanUp()
        {
            AppiumDriverHelper.CloseAppiumServer();
            AppiumDriverHelper.CloseEmulator();
            //AppiumDriver.GetDriver().RemoveApp("com.vietnamworks.vietnamworks.staging");
            //AppiumDriverHelper.DriverQuit();
        }
    }
}
