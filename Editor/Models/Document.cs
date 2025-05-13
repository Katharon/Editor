namespace Editor.Models
{
    using System;
    using System.ComponentModel;
    using System.Windows.Documents;

    public class Document : INotifyPropertyChanged
    {
        public string FileName { get; set; } = string.Empty;
        public FlowDocument FlowDocument { get; set; } = new ();
        public string FilePath { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
