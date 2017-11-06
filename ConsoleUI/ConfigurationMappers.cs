using System.Collections.Generic;
using ConsoleUI.Configuration;
using FileWatcher;

namespace ConsoleUI
{
    public static class ConfigurationMappers
    {
        public static List<string> ToList(this ListeningFolderCollection folders)
        {
            List<string> foldersList = new List<string>();
            foreach (var folder in folders)
            {
                foldersList.Add(((ListeningFolderElement)folder).DirectoryPath);
            }
            return foldersList;
        }

        public static List<FileMovingRule> ToList(this MovingRulesCollection rules)
        {
            List<FileMovingRule> rulesList = new List<FileMovingRule>();
            foreach (var rule in rules)
            {
                rulesList.Add(((MovingRuleElement)rule).ToFileMovingRule());
            }
            return rulesList;
        }

        public static FileMovingRule ToFileMovingRule(this MovingRuleElement movingRule)
        {
            return new FileMovingRule
            { 
                FileNamePattern = movingRule.FileNamePattern,
                TargetDirectory = movingRule.TargetFolder,
                IsSerialNumber = movingRule.IsSerialNumber,
                IsDateMoving = movingRule.IsDating
            };
        }
    }
}
