using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using ConsoleUI.Configuration;
using FileWatcher;
using messages = ConsoleUI.Resources.Strings;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var settings = (FileWatcherSettingSection) ConfigurationManager.GetSection("FileWatcherSetting");
            List<string> directories = settings.ListeningFolders.ToList();
            List<FileMovingRule> rules = settings.MovingRules.ToList();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Localization.Culture);

            FilesWatcher fw = new FilesWatcher(directories, rules, "D:/logs/");
            fw.FileFoundEvent += (sender, eventArgs) => Console.WriteLine($@"{messages.FileFound} {eventArgs.FileName}");
            fw.FileMovedEvent += (sender, eventArgs) => Console.WriteLine($@"{messages.FileMoved} {eventArgs.Directory}");
            fw.RuleCheckedEvent += (sender, eventArgs) => Console.WriteLine($@"{messages.RuleMatch} {eventArgs.IsMatched}");
            fw.FileAlreadyExistsEvent += (sender, eventArgs) => Console.WriteLine($@"{messages.FileExists} {eventArgs.Directory}");
            fw.StartWatch();
            Console.Read();
        }
    }
}
