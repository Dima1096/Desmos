using Aquality.Selenium.Browsers;
using TechTalk.SpecFlow;


namespace DesmosSpecFlow.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public static void BeforeScenario() => AqualityServices.Browser.Maximize();

        [AfterScenario(Order = 1)]
        public void AfterScenario() => AqualityServices.Browser.Quit();
    }
}