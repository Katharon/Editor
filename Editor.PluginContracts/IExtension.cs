namespace Editor.PluginContracts
{
    public interface IExtension
    {
        string Name { get; set; }

        bool IsActive { get; set; }

        void Initialize();
    }
}