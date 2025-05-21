namespace Editor.PluginContracts
{
    public interface IExtension
    {
        string Name { get; set; }
        void Initialize();
    }
}