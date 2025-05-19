namespace Editor.PluginContracts
{
    using Editor.Domain;

    public interface ITextTransformer : IExtension
    {
        void Transform(Document document);
    }
}