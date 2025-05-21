namespace Editor.PluginContracts
{
    public class Document : ObservableObject
    {
        required public string FileName
        {
            get => field;
            set
            {
                SetProperty(ref field, value);
            }
        }

        public string? FileExtension
        {
            get => field;
            set
            {
                SetProperty(ref field, value);
            }
        }

        public string? FilePath
        {
            get => field;
            set
            {
                SetProperty(ref field, value);
            }
        }

        public string? Content
        {
            get => field;
            set
            {
                SetProperty(ref field, value);
            }
        }
    }
}