using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Globalization;

namespace SpecflowToolkit.Configuration
{
    public class SpecflowToolkitConfiguration
    {
        public string UrlApplication { get; set; }
        public int SecondsTimeout { get; set; }
        public string Language { get; set; }
        public IDictionary<string, string> Modules { get; set; }
        public IList<string> Options { get; set; } = new List<string>();
        public LogLevel LogLevel { get; set; }

        [JsonIgnore]
        public CultureInfo Culture => CultureInfo.CreateSpecificCulture(Language);
    }
}
