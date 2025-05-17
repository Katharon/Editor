namespace Editor.Application
{
    using Editor.PluginContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExtensionManager : IExtensionManager
    {
        public List<IExtension> Extensions
        {
            get => default;
            set
            {
            }
        }
    }
}