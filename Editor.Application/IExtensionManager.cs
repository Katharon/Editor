namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public interface IExtensionManager
    {
        IEnumerable<IExtension> Extensions { get; set; }

        void Load();

        void Refresh();
    }
}