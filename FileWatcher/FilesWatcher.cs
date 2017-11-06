using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using FileWatcher.WatcherEventArgs;

namespace FileWatcher
{
    public class FilesWatcher
    {
        private static int initNumber;
        private readonly List<string> watcherDirectories;
        private readonly List<FileMovingRule> movingRules;
        private readonly string defaultFolder;

        public event EventHandler<FileEventArgs> FileFoundEvent;
        public event EventHandler<RuleMatchingEventArgs> RuleCheckedEvent;
        public event EventHandler<MovingEventArgs> FileMovedEvent;

        public FilesWatcher(List<string> directories, List<FileMovingRule> rules, string defaultFolder)
        {
            watcherDirectories = directories;
            movingRules = rules;
            this.defaultFolder = defaultFolder;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void StartWatch()
        {
            foreach (var watcherDirectory in watcherDirectories)
            {
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = watcherDirectory,
                };
                watcher.Created += OnChanged;
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            OnRaiseFileFoundEvent(new FileEventArgs{ FileName = e.Name });
            var movingRule = movingRules.FirstOrDefault(rule => IsNessesaryFile(e.Name, rule.FileNamePattern));
            if (movingRule != null)
            {
                OnRaiseRuleCheckedEvent(new RuleMatchingEventArgs
                {
                    IsMatched = true,
                    MovingRule = movingRule
                });
                var target = movingRule.TargetDirectory +
                             BuildFileName(e.Name, movingRule.IsSerialNumber, movingRule.IsDateMoving);
                File.Move(e.FullPath, target);
                OnRaiseFileMovedEvent(new MovingEventArgs { Directory = target });
            }
            else
            {
                OnRaiseRuleCheckedEvent(new RuleMatchingEventArgs{ IsMatched = true });
                File.Move(e.FullPath, defaultFolder + e.Name);
                OnRaiseFileMovedEvent(new MovingEventArgs { Directory = defaultFolder + e.Name });
            }
        }

        private bool IsNessesaryFile(string fileName, string namePattern)
        {
            Regex regex = new Regex(namePattern);
            return regex.IsMatch(fileName);
        }

        private string BuildFileName(string fileName, bool isNumber, bool isDate)
        {
            string dateFormat = @"MM-dd-yyyy_HH-mm-ss";
            string extension = fileName.Substring(fileName.LastIndexOf(".") + 1);
            string newName = fileName.Substring(0, fileName.LastIndexOf("."));
            newName = isNumber ? $"{newName}_{initNumber++}" : newName;
            newName = isDate ? $"{newName}_{DateTime.Now.ToString(dateFormat)}" : newName;
            return $"{newName}.{extension}";
        }

        protected virtual void OnRaiseFileFoundEvent(FileEventArgs fileEventArgs)
        {
            FileFoundEvent?.Invoke(this, fileEventArgs);
        }

        protected virtual void OnRaiseFileMovedEvent(MovingEventArgs movingEventArgs)
        {
            FileMovedEvent?.Invoke(this, movingEventArgs);
        }

        protected virtual void OnRaiseRuleCheckedEvent(RuleMatchingEventArgs ruleEventArgs)
        {
            RuleCheckedEvent?.Invoke(this, ruleEventArgs);
        }
    }
}
