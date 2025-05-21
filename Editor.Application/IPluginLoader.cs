namespace Editor.Application
{
    using Editor.Application.Events;
    using Editor.PluginContracts;

    public interface IPluginLoader
    {
        IEnumerable<IExtension> LoadAll();

        void StartWatching();

        event EventHandler<ExtensionsLoadedEventArgs>? AssemblyLoaded;
    }
}