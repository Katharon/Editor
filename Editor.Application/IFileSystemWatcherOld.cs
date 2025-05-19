namespace Editor.Application
{
    using Editor.Application.Events;
    using System;

    public interface IFileSystemWatcherOld : IDisposable
    {
        void StartWatching(string path, string filter = "*.*");

        event EventHandler<FileChangedEventArgs>? FileCreated;

        event EventHandler<FileChangedEventArgs>? FileChanged;
    }
}