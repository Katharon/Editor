namespace Editor.PluginContracts
{
    using System;

    public interface ITextTransformer : IExtension
    {
        void Transform(Document document);
    }
}