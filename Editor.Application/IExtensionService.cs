namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public interface IExtensionService
    {
        IEnumerable<IExtension> LoadExtensions();
    }
}