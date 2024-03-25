using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Logging;
using SpecflowToolkit.Configuration;
using SpecflowToolkit.ExtentionMethods;
using SpecflowToolkit.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowToolkit
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;

        private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}";

        [BeforeTestRun(Order = 1)]
        public static void ConfigureTest()
        {
            DriverHelper.Initialize();

            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel != LogLevel.None)
            {
                var reporter = new ExtentHtmlReporter(PathReport);

                _extent = new ExtentReports();

                _extent.AttachReporter(reporter);
            }
        }

        [AfterTestRun]
        public static void EndTest()
        {
            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel != LogLevel.None)
                _extent.Flush();

            DriverHelper.EndDriver();
        }

        [BeforeFeature(Order = 1)]
        public static void ConfigureFeature(FeatureContext featureContext)
        {
            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel != LogLevel.None)
                _feature = _extent.CreateTest(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario(Order = 1)]
        public static void CreateScenario(ScenarioContext scenarioContext)
        {
            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel != LogLevel.None)
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep(Order = 1)]
        public static void ConfigureStep(ScenarioContext scenarioContext)
        {
            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel == LogLevel.Trace)
                scenarioContext.StepContext.Add(Guid.NewGuid().ToString(), DriverHelper.PrintScreen());
        }

        [AfterStep]
        public static void EndStep(ScenarioContext scenarioContext)
        {
            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel != LogLevel.None)
                _scenario.CreateExtentTest(scenarioContext, scenarioContext.StepContext.StepInfo.StepDefinitionType);
        }
    }
}
