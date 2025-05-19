namespace Editor.PluginContracts
{
    using Editor.Domain;
    using System.Collections.Generic;

    public interface ISyntaxHighlighter : IExtension
    {
        IEnumerable<HighlightSpan> GetHighlights(Document document);
    }
}