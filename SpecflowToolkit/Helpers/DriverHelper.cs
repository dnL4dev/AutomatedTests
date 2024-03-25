using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowToolkit.Configuration;

namespace SpecflowToolkit.Helpers
{
    public static class DriverHelper
    {
        public static IWebDriver Driver;
        public static TestConfigurationManager TestConfiguration;

        public static void Initialize()
        {
            if (TestConfiguration == null)
            {
                TestConfiguration = new TestConfigurationManager();
                var options = new ChromeOptions();

                if (TestConfigurationManager.SpecflowToolkitConfiguration.Options.Any())
                    options.AddArguments(TestConfigurationManager.SpecflowToolkitConfiguration.Options.ToArray());

                Driver = new ChromeDriver(Environment.CurrentDirectory, options);
            }
        }

        public static void EndDriver()
        {
            TestConfiguration = null;
            Driver?.Manage().Cookies.DeleteAllCookies();
            Driver?.Quit();
            Driver?.Dispose();
        }

        public static string PrintScreen()
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }
    }
}
