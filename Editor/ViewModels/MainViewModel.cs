namespace Editor.ViewModels
{
    using Editor.Commands;
    using Editor.Models;
    using Editor.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IApplicationService applicationService;
        private readonly IDialogService dialogService;
        private readonly IExtensionService extensionService;

        public MainViewModel(IApplicationService applicationService, IDialogService dialogService, IExtensionService extensionService)
        {
            this.applicationService = applicationService;
            this.dialogService = dialogService;
            this.extensionService = extensionService;

            this.NewCommand.Execute(null);
        }

        public string? StatusMessage
        {
            get => field ?? string.Empty;
            set
            {
                field = value ?? throw new ArgumentNullException("");
                this.OnPropertyChanged(nameof(this.StatusMessage));
            }
        }
        public string? CaretPosition
        {
            get => field ?? string.Empty;
            set
            {
                field = value ?? throw new ArgumentNullException("");
                this.OnPropertyChanged(nameof(this.CaretPosition));
            }
        }

        public ObservableCollection<Extension> ExtensionSets { get; set; } = [];
        public Extension? SelectedExtensionSet
        {
            get => field;
            set
            {
                field = value ?? throw new ArgumentNullException("");
                this.OnPropertyChanged(nameof(this.SelectedExtensionSet));
            }
        }

        public ObservableCollection<Document> Documents { get; set; } = [];
        public Document? ActiveDocument
        {
            get => field;
            set
            {
                field = value ?? throw new ArgumentNullException("");
                this.OnPropertyChanged(nameof(this.ActiveDocument));
                this.OnPropertyChanged(nameof(this.SaveCommand));
                this.OnPropertyChanged(nameof(this.SaveAsCommand));
            }
        }

        // Dialog Commands
        public ICommand NewCommand => new RelayCommand(() =>
        {
            var document = new Document
            {
                FileName = "New File",
            };
            this.Documents.Add(document);
            this.ActiveDocument = document;
        });

        public ICommand OpenCommand => new RelayCommand(() =>
        {
            string? filePath = this.dialogService.ShowOpenFileDialog("Datei öffnen", "");
            if (filePath == null)
            {
                // FEHLERMELDUNG!!!!!
                return;
            }

            try
            {
                var content = File.ReadAllText(filePath);
                var document = new Document
                {
                    FilePath = filePath,
                    FileName = Path.GetFileName(filePath),
                    Content = content,
                };

                this.Documents.Add(document);
                this.ActiveDocument = document;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });

        public ICommand SaveCommand => new RelayCommand
        (
            canExecute: () => this.ActiveDocument != null,
            execute: () =>
            {
                if (this.ActiveDocument != null)
                {
                    if (!string.IsNullOrWhiteSpace(this.ActiveDocument.FilePath))
                    {
                        try
                        {
                            File.WriteAllText(this.ActiveDocument.FilePath, this.ActiveDocument.Content);
                            this.StatusMessage = $"Gespeichert: {this.ActiveDocument.FileName}";
                        }
                        catch (Exception ex)
                        {
                            this.dialogService.ShowError("Speichern fehlgeschlagen", ex.Message);
                        }
                        return;
                    }

                    string? filePath = this.dialogService.ShowSaveFileDialog("Datei speichern", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ".txt");
                    if (filePath == null)
                    {
                        MessageBox.Show("No Filepath");
                        return;
                    }

                    try
                    {
                        File.WriteAllText(filePath, this.ActiveDocument.Content);
                        this.ActiveDocument.FilePath = filePath;
                        this.ActiveDocument.FileName = Path.GetFileName(filePath);
                        this.StatusMessage = $"Gespeichert als: {this.ActiveDocument.FileName}";
                    }
                    catch (Exception ex)
                    {
                        this.StatusMessage = $"NICHT Gespeichert: {this.ActiveDocument.FileName}";
                        this.dialogService.ShowError("Fehler beim Speichern", ex.Message);
                    }
                }
            }
        );

        public ICommand SaveAsCommand => new RelayCommand
        (
            canExecute: () => this.ActiveDocument != null,
            execute: () =>
            {
                if (this.ActiveDocument != null)
                {
                    string? filePath = this.dialogService.ShowSaveFileDialog("Datei speichern", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ".txt");
                    if (filePath == null)
                    {
                        MessageBox.Show("No Filepath");
                        return;
                    }

                    try
                    {
                        File.WriteAllText(filePath, this.ActiveDocument.Content);
                        this.ActiveDocument.FilePath = filePath;
                        this.ActiveDocument.FileName = Path.GetFileName(filePath);
                        this.StatusMessage = $"Gespeichert als: {this.ActiveDocument.FileName}";
                    }
                    catch (Exception ex)
                    {
                        this.StatusMessage = $"NICHT Gespeichert: {this.ActiveDocument.FileName}";
                        this.dialogService.ShowError("Fehler beim Speichern", ex.Message);
                    }
                }
            }
        );

        public ICommand ExitCommand => new RelayCommand(() =>
        {
            this.applicationService.Shutdown();
        });

        // Application Commands
        public ICommand ManageExtensionSetsCommand => new RelayCommand(() => MessageBox.Show("Manage Extension Sets Command"));
        public ICommand ManageMappingsCommand => new RelayCommand(() => MessageBox.Show("Manage Mappings Command"));
        public ICommand AboutCommand => new RelayCommand(() => MessageBox.Show("About Command"));
        public ICommand AddSetCommand => new RelayCommand(() => MessageBox.Show("Add Set Command"));
        public ICommand EditSetCommand => new RelayCommand(() => MessageBox.Show("Edit Set Command"));
        public ICommand DeleteSetCommand => new RelayCommand(() => MessageBox.Show("Delete Set Command"));

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
