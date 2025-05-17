namespace Editor.Application
{
    using Editor.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IExtensionSetManager
    {
        IEnumerable<IExtensionSet> ExtensionSets { get; set; }
    }
}