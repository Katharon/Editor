namespace Editor.Application.Events
{
    public class FileChangedEventArgs
    {
        public FileChangedEventArgs(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }
    }
}