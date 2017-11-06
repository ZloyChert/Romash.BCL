using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class LocalizationElement : ConfigurationElement
    {
        [ConfigurationProperty("culture")]
        public string Culture => (string)base["culture"];
    }
}
