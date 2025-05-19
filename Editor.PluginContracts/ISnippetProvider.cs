namespace Editor.PluginContracts
{
    using Editor.Domain;

    public interface ISnippetProvider : IExtension
    {
        Snippet? TryExpandSnippet(Document document, CursorPosition cursor);
    }
}