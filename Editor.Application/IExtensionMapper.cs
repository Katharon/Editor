namespace Editor.Application
{
    using Editor.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IExtensionMapper
    {
        Dictionary<string, IExtensionSet> ExtensionMappings { get; }

        void Map();
    }
}