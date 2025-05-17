namespace Editor.PluginContracts
{
    using System;

    public interface ISnippetProvider : IExtension
    {
        Snippet? TryExpandSnippet(Document document, CursorPosition cursor);
    }
}