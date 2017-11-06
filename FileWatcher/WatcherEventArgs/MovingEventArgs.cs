using System;

namespace FileWatcher.WatcherEventArgs
{
    public class MovingEventArgs : EventArgs
    {
        public string Directory { get; set; }
    }
}
