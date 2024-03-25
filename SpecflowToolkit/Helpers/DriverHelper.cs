using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowToolkit.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ChromeOptions options = null;

                if (TestConfigurationManager.SpecflowToolkitConfiguration.Options.Any())
                {
                    options.AddArguments(TestConfigurationManager.SpecflowToolkitConfiguration.Options.ToArray());

                    //Driver = new ChromeDriver(Environment.CurrentDirectory, options);
                }
                //else
                //{
                Driver = new ChromeDriver(Environment.CurrentDirectory);
                //}
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
