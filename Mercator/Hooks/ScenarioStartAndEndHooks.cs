using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Mercator.Hooks
{
    [Binding]
    public class ScenarioStartAndEndHooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _webDriver;

        public ScenarioStartAndEndHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _webDriver = new ChromeDriver(chromeOptions);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
            _webDriver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void ShutDownWebDriver()
        {
            _webDriver.Quit();
        }
    }
}
