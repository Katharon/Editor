using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Domain
{
    public interface IExtensionSet
    {
        string Name { get; set; }
        IEnumerable<IExtension> Extensions { get; set; }
    }
}