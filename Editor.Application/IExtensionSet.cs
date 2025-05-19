namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public interface IExtensionSet
    {
        string Name { get; set; }

        IEnumerable<IExtension> Extensions { get; set; }
    }
}