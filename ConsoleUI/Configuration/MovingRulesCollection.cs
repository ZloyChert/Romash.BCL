using System.Configuration;

namespace ConsoleUI.Configuration
{
    public class MovingRulesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MovingRuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MovingRuleElement) element).FileNamePattern;
        }
    }
}
