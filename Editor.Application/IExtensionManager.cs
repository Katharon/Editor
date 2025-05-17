namespace Editor.Application
{
    using Editor.PluginContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IExtensionManager
    {
        IEnumerable<IExtension> Extensions { get; set; }

        void Load();

        void Refresh();
    }
}