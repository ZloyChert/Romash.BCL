using System;

namespace FileWatcher.WatcherEventArgs
{
    public class FileEventArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
