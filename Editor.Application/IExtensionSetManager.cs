namespace Editor.Application
{
    using System.Collections.Generic;

    public interface IExtensionSetManager
    {
        IEnumerable<IExtensionSet> ExtensionSets { get; }
    }
}