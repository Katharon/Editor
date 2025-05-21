namespace Editor.PluginContracts
{
    public interface ISnippetProvider : IExtension
    {
        Snippet? TryExpandSnippet(Document document, CursorPosition cursor);
    }
}