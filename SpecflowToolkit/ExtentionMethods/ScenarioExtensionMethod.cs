using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Logging;
using SpecflowToolkit.Configuration;
using SpecflowToolkit.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecflowToolkit.ExtentionMethods
{
    public static class ScenarioExtensionMethod
    {
        private static readonly string errorImage = "Error";
        private static readonly string evidenceImage = "Evidence";

        private static ExtentTest CreateExtentTest(ExtentTest extent, StepDefinitionType stepDefinitionType, ScenarioStepContext scenarioStepContext)
        {
            var stepText = scenarioStepContext.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => extent.CreateNode<Given>(stepText),
                StepDefinitionType.Then => extent.CreateNode<Then>(stepText),
                StepDefinitionType.When => extent.CreateNode<When>(stepText),
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

        private static ExtentTest CreateExtentTestError(ExtentTest extent, StepDefinitionType stepDefinitionType, ScenarioContext scenarioContext)
        {
            var error = scenarioContext.TestError;
            var extentTest = CreateExtentTest(extent, stepDefinitionType, scenarioContext.StepContext);

            extentTest.AddScreenCaptureFromBase64String(DriverHelper.PrintScreen(), errorImage);
            extentTest.Log(Status.Fail, error.Message);
            extentTest.Fail(error);

            return extentTest;
        }

        public static void CreateExtentTest(this ExtentTest extent, ScenarioContext scenarioContext, StepDefinitionType stepDefinitionType)
        {
            var extentTest = scenarioContext.TestError == null ?
                CreateExtentTest(extent, stepDefinitionType, scenarioContext.StepContext) :
                CreateExtentTestError(extent, stepDefinitionType, scenarioContext);

            if (TestConfigurationManager.SpecflowToolkitConfiguration.LogLevel == LogLevel.Trace)
                foreach (var contexts in scenarioContext.StepContext)
                    extentTest.AddScreenCaptureFromBase64String(contexts.Value.ToString(), evidenceImage);
        }
    }
}
