using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class MovingRuleElement : ConfigurationElement
    {
        [ConfigurationProperty("fileNamePattern", IsKey = true)]
        public string FileNamePattern => (string) base["fileNamePattern"];
        [ConfigurationProperty("targetFolder")]
        public string TargetFolder => (string) base["targetFolder"];
        [ConfigurationProperty("isSerialNumber")]
        public bool IsSerialNumber => (bool) base["isSerialNumber"];
        [ConfigurationProperty("isDating")]
        public bool IsDating => (bool) base["isDating"];
    }
}
