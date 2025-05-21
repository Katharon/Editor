namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public class ExtensionManager : ObservableObject, IExtensionManager
    {
        public ExtensionManager()
        {
            this.Extensions = new List<IExtension>();    
        }

        required public IEnumerable<IExtension> Extensions
        {
            get => field;
            set
            {
                SetProperty(ref field, value);
            }
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}