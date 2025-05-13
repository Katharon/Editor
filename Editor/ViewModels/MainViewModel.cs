namespace Editor.ViewModels
{
    using Editor.Commands;
    using Editor.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class MainViewModel
    {
        public string StatusMessage { get; set; } = string.Empty;
        public string CaretPosition { get; set; } = string.Empty;
        public ObservableCollection<Extension> ExtensionSets { get; set; } = new ();
        public Extension? SelectedExtensionSet { get; set; }
        public ObservableCollection<Document> Documents { get; set; } = new ();
        public Document? ActiveDocument { get; set; }
        public ICommand NewCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand OpenCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand SaveCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand SaveAsCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand ExitCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand ManageExtensionSetsCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand ManageMappingsCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand AboutCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand AddSetCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand EditSetCommand => new RelayCommand(() => Console.WriteLine());
        public ICommand DeleteSetCommand => new RelayCommand(() => Console.WriteLine());
    }
}
