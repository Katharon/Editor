namespace Editor.Application
{
    using Editor.PluginContracts;
    using System.Collections.Generic;

    public class ExtensionSetManager : ObservableObject, IExtensionSetManager
    {
        public ExtensionSetManager()
        {
            this.ExtensionSets = new List<ExtensionSet>();
        }

        required public IEnumerable<IExtensionSet> ExtensionSets
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }
    }
}