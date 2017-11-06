using System;

namespace FileWatcher.WatcherEventArgs
{
    public class RuleMatchingEventArgs : EventArgs
    {
        public FileMovingRule MovingRule { get; set; }
        public bool IsMatched { get; set; }
    }
}
