using OpenQA.Selenium;
using SpecflowToolkit.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowToolkit.StepsDefinitions
{
    [Binding]
    public static class TextSteps
    {
        [Given(@"que limpo o campo de texto de '(.*)'")]
        [Then(@"limpo o campo de texto de '(.*)'")]
        [When(@"limpo o campo de texto de '(.*)'")]
        public static void ClearTextField(By by)
        {
            StepHelper.WaitElementLoad(by).Clear();
        }

        [Given(@"que preencho o campo de '(.*)' com o valor '(.*)'")]
        [Then(@"preencho o campo de '(.*)' com o valor '(.*)'")]
        [When(@"preencho o campo de '(.*)' com o valor '(.*)'")]
        public static void FillTextField(By by, string value)
        {
            StepHelper.WaitElementLoad(by).SendKeys(value);
        }
    }
}
