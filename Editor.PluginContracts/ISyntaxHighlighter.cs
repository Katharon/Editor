namespace Editor.PluginContracts
{
    using System;
    using System.Collections.Generic;

    public interface ISyntaxHighlighter : IExtension
    {
        IEnumerable<HighlightSpan> GetHighlights(Document document);
    }
}