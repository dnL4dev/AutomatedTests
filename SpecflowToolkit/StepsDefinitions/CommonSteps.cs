using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SpecflowToolkit.Exceptions;
using SpecflowToolkit.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowToolkit.StepsDefinitions
{
    [Binding]
    public static class CommonSteps
    {
        [Given(@"que acesso a url '(.*)'")]
        [Then(@"acesso a url '(.*)'")]
        [When(@"acesso a url '(.*)'")]
        public static void Navigate(string url)
        {
            StepHelper.Navigate(url);
        }

        [Given(@"que acesso o módulo '(.*)'")]
        [Then(@"acesso o módulo '(.*)'")]
        [When(@"acesso o módulo '(.*)'")]
        public static void NavigateToModule(string module)
        {
            StepHelper.NavigateToModule(module);
        }

        [Given(@"que o valor '(.*)' é exibido no elemento de '(.*)'")]
        [Then(@"o valor '(.*)' é exibido no elemento de '(.*)'")]
        [When(@"o valor '(.*)' é exibido no elemento de '(.*)'")]
        public static void CompareElementValue(string texto, By by)
        {
            StepHelper.CompareElementValue(by, texto);
        }

        [Given(@"que clico no elemento de '(.*)'")]
        [Then(@"clico no elemento de '(.*)'")]
        [When(@"clico no elemento de '(.*)'")]
        public static void Click(By by)
        {
            StepHelper.WaitElementLoad(by).Click();
        }

        [Given(@"que espero '(.*)'")]
        [Then(@"espero '(.*)'")]
        [When(@"espero '(.*)'")]
        public static void Wait(TimeSpan time)
        {
            Thread.Sleep(time);
        }

        [Given(@"que desço página")]
        [Then(@"desço a página")]
        [When(@"desço a página")]
        public static void Scroll()
        {
            StepHelper.Scroll();
        }

        [Then(@"movo a tela para o elemento de id '(.*)'")]
        [When(@"movo a tela para o elemento de id '(.*)'")]
        [Given(@"que movo a tela para o elemento de id '(.*)'")]
        public static void MoveToElement(string id)
        {
            StepHelper.MoveToElement(id);
        }

        [Given(@"que o campo de '(.*)' está '(.*)'")]
        [Then(@"o campo de '(.*)' está '(.*)'")]
        [When(@"o campo de '(.*)' está '(.*)'")]
        public static void ValidateElementDisabled(By by, string state)
        {
            var elemento = StepHelper.WaitElementLoad(ExpectedConditions.ElementExists(by));

            if (elemento.Enabled && state == "desabilitado"
             || !elemento.Enabled && state == "habilitado")
            {
                throw new UnexpectedFieldStateException($"Enabled: {elemento.Enabled} - Expected: {state}");
            }
        }
    }
}
