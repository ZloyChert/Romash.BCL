using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class FileWatcherSettingSection : ConfigurationSection
    {
        [ConfigurationProperty("Localization")]
        public LocalizationElement Localization => (LocalizationElement)this["Localization"];
        [ConfigurationProperty("ListeningFolders")]
        public ListeningFolderCollection ListeningFolders => (ListeningFolderCollection) this["ListeningFolders"];
        [ConfigurationProperty("MovingRules")]
        public MovingRulesCollection MovingRules => (MovingRulesCollection)this["MovingRules"];
    }
}
