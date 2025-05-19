namespace Editor.Application
{
    using Editor.Domain;
    using System;
    using System.Collections.Generic;

    public class ExtensionMapper : ObservableObject, IExtensionMapper
    {
        public ExtensionMapper()
        {
            // this.ExtensionSets = new List<IExtensionSet>();
            this.FileExtension = string.Empty;
        }

        // public List<IExtensionSet> ExtensionSets
        // {
        //     get => field;
        //     set
        //     {
        //         this.SetProperty(ref field, value);
        //     }
        // }

        required public string FileExtension
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        required public string Description
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        public Dictionary<string, IExtensionSet> ExtensionMappings => throw new NotImplementedException();

        public void Map()
        {
            throw new NotImplementedException();
        }
    }
}