using Allure.Commons;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using DesmosTest.Configurations;
using DesmosTest.Utils;
using NUnit.Framework;
using SpecFlowTask.Support;

using TechTalk.SpecFlow;


namespace DesmosSpecFlow.Hooks
{
    [Binding]
    public class PluginsHooks
    {
        private ScenarioContext _scenarioContext;
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        public PluginsHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
            AllureUtils.AddEnvironment();
        }
     
     /*   [AfterScenario(Order = -1)]
        public void UpdateAllureTestCaseName()
        {
            _scenarioContext.TryGetValue(out TestResult testResult);
            AllureLifecycle.Instance.UpdateTestCase(testResult.uuid, testCase =>
            {
                testCase.historyId = TestContext.CurrentContext.Test.FullName;
                testCase.description = testResult.fullName;
                var link = new Link();
                link.url = Configuration.StartUrl;
                testCase.links.Add(link);
            });
        }*/

   /*     [AfterTestRun]
        public static void AfterTestRun() => AllureUtils.AddCategorys();*/
    }
}
