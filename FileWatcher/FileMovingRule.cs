namespace FileWatcher
{
    public class FileMovingRule
    {
        public string FileNamePattern { get; set; }
        public string TargetDirectory { get; set; }
        public bool IsSerialNumber { get; set; }
        public bool IsDateMoving { get; set; }
    }
}
