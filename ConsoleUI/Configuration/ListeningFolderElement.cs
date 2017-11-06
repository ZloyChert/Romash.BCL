using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class ListeningFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsKey = true)]
        public string DirectoryPath => (string) base["path"];

    }
}
