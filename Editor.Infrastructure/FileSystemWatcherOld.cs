
namespace Editor.Infrastructure
{
    using System;
    using System.IO;
    using Editor.Application;
    using Editor.Application.Events;

    public class FileSystemWatcherOld : IFileSystemWatcherOld
    {
        private readonly FileSystemWatcher? watcher;

        public event EventHandler<FileChangedEventArgs>? FileCreated;

        public event EventHandler<FileChangedEventArgs>? FileChanged;

        public void StartWatching(string path, string filter = "*.*")
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}