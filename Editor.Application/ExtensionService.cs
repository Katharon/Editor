namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public class ExtensionService : IExtensionService
    {
        private readonly IPluginLoader pluginLoader;

        public ExtensionService()
        {
            this.pluginLoader = new PluginLoader();
        }

        public IEnumerable<IExtension> LoadExtensions()
        {
            return this.pluginLoader.LoadAll();
        }
    }
}