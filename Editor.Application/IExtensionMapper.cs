namespace Editor.Application
{
    using System.Collections.Generic;

    public interface IExtensionMapper
    {
        Dictionary<string, IExtensionSet> ExtensionMappings { get; }

        void Map();
    }
}