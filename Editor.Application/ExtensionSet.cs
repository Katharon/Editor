namespace Editor.Application
{
    using Editor.Domain;
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public class ExtensionSet : ObservableObject, IExtensionSet
    {
        public ExtensionSet()
        {
            this.Extensions = new List<IExtension>();
        }

        required public bool IsEnabled
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        required public string Name
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        public IEnumerable<IExtension> Extensions
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }
    }
}