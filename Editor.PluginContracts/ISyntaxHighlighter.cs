namespace Editor.PluginContracts
{
    using System.Collections.Generic;

    public interface ISyntaxHighlighter : IExtension
    {
        IEnumerable<HighlightSpan> GetHighlights(Document document);
    }
}