namespace Editor.PluginContracts
{
    public interface ITextTransformer : IExtension
    {
        void Transform(Document document);
    }
}