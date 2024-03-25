using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecflowToolkit.Configuration;
using SpecflowToolkit.Exceptions;

namespace SpecflowToolkit.Helpers
{
    public static class StepHelper
    {
        private static readonly int Timeout = TestConfigurationManager.SpecflowToolkitConfiguration.SecondsTimeout;

        public static IWebElement WaitElementLoad(By by)
        {
            var wait = new WebDriverWait(DriverHelper.Driver, TimeSpan.FromSeconds(Timeout));
            wait.Until(ExpectedConditions.ElementExists(by));

            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static IWebElement WaitElementLoad(Func<IWebDriver, IWebElement> waitCondition)
        {
            var wait = new WebDriverWait(DriverHelper.Driver, TimeSpan.FromSeconds(Timeout));

            return wait.Until(waitCondition);
        }

        public static void Navigate(string url)
        {
            DriverHelper.Driver.Navigate().GoToUrl(url);
        }

        public static void NavigateToModule(string module)
        {
            if (!TestConfigurationManager.SpecflowToolkitConfiguration.Modules.ContainsKey(module))
                throw new ArgumentException("Módulo não localizado no arquivo de configuração");

            var url = $"{TestConfigurationManager.SpecflowToolkitConfiguration.UrlApplication}{TestConfigurationManager.SpecflowToolkitConfiguration.Modules[module]}";

            Navigate(url);
        }

        public static void CompareElementValue(By by, string texto)
        {
            var element = WaitElementLoad(by);

            if (element == null || !element.Text.Equals(texto))
                throw new ValuesMismatchException(texto);
        }

        public static void Scroll()
        {
            var js = (IJavaScriptExecutor)DriverHelper.Driver;
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0, 300)", "");
            Thread.Sleep(1000);
        }

        public static void MoveToElement(string id)
        {
            var js = (IJavaScriptExecutor)DriverHelper.Driver;
            Thread.Sleep(1000);
            js.ExecuteScript("document.getElementById(\"" + id + "\").scrollIntoView()");
            Thread.Sleep(1000);
        }
    }
}
