using Microsoft.Extensions.Configuration;

namespace SpecflowToolkit.Configuration
{
    public class TestConfigurationManager
    {
        public static IConfiguration? Configuration { get; private set; }
        public static SpecflowToolkitConfiguration SpecflowToolkitConfiguration { get; private set; } = new();

        public TestConfigurationManager()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            Configuration.GetSection("AutomatedTest").Bind(SpecflowToolkitConfiguration);
        }
    }
}
