namespace Editor.Application.Events
{
    using Editor.PluginContracts;

    public class ExtensionsLoadedEventArgs : EventArgs
    {
        public ExtensionsLoadedEventArgs(IEnumerable<IExtension> loadedExtensions)
        {
            this.LoadedExtensions = loadedExtensions;
        }

        public IEnumerable<IExtension> LoadedExtensions { get; }
    }
}