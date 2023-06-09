using System.IO;
using System.Text.Json;
using AppiumTest.Utils;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace AppiumTest.Pages
{
    public class BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public WaitHelpers wait;

        public bool isIOS;

        public BasePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            wait = new WaitHelpers();
            PageFactory.InitElements(AppiumDriverHelper.GetDriver(), this);
            
            JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText("/Users/nhict/Desktop/Projects/Appium-Specflow/AppiumTest/config.json"));
            isIOS = jsonDocument.RootElement.GetProperty("isIOSDevice").GetBoolean(); ;
        }
    }
}