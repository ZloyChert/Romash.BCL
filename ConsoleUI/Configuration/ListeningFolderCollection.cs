using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class ListeningFolderCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ListeningFolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ListeningFolderElement)element).DirectoryPath;
        }
    }
}
