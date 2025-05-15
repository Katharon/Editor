// <copyright file="MainViewModel.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using Editor.Commands;
    using Editor.Models;
    using Editor.Services;

    /// <summary>
    /// Represents the main view model of the application, containing documents, extensions,
    /// editor commands, and state information such as the status message and caret position.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IApplicationService applicationService;
        private readonly IDialogService dialogService;
        private readonly IExtensionService extensionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="applicationService">The application service used to perform system-level actions.</param>
        /// <param name="dialogService">The dialog service used to interact with the user.</param>
        /// <param name="extensionService">The extension service used to manage editor extensions.</param>
        public MainViewModel(IApplicationService applicationService, IDialogService dialogService, IExtensionService extensionService)
        {
            this.applicationService = applicationService;
            this.dialogService = dialogService;
            this.extensionService = extensionService;

            this.ExtensionSets = new ObservableCollection<Extension>();
            this.Documents = new ObservableCollection<Document>();

            this.NewCommand.Execute(null);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the status message shown to the user.
        /// </summary>
        public string? StatusMessage
        {
            get => field;
            set
            {
                field = value;
                this.OnPropertyChanged(nameof(this.StatusMessage));
            }
        }

        /// <summary>
        /// Gets or sets the current caret position in the document.
        /// </summary>
        public string? CaretPosition
        {
            get => field;
            set
            {
                field = value;
                this.OnPropertyChanged(nameof(this.CaretPosition));
            }
        }

        /// <summary>
        /// Gets or sets the collection of available extension sets.
        /// </summary>
        public ObservableCollection<Extension> ExtensionSets { get; set; }

        /// <summary>
        /// Gets or sets the currently selected extension set.
        /// </summary>
        public Extension? SelectedExtensionSet
        {
            get => field;
            set
            {
                field = value;
                this.OnPropertyChanged(nameof(this.SelectedExtensionSet));
            }
        }

        /// <summary>
        /// Gets or sets the collection of open documents.
        /// </summary>
        public ObservableCollection<Document> Documents { get; set; }

        /// <summary>
        /// Gets or sets the currently active document.
        /// </summary>
        public Document? ActiveDocument
        {
            get => field;
            set
            {
                field = value;
                this.OnPropertyChanged(nameof(this.ActiveDocument));
                this.OnPropertyChanged(nameof(this.SaveCommand));
                this.OnPropertyChanged(nameof(this.SaveAsCommand));
            }
        }

        /// <summary>
        /// Gets the command to create a new document.
        /// </summary>
        public ICommand NewCommand => new RelayCommand(() =>
        {
            var document = new Document
            {
                FileName = "New File",
            };
            this.Documents.Add(document);
            this.ActiveDocument = document;
        });

        /// <summary>
        /// Gets the command to open an existing file.
        /// </summary>
        public ICommand OpenCommand => new RelayCommand(() =>
        {
            string? filePath = this.dialogService.ShowOpenFileDialog("Datei öffnen", string.Empty);
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

        /// <summary>
        /// Gets the command to save the current document.
        /// </summary>
        public ICommand SaveCommand => new RelayCommand(
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
            });

        /// <summary>
        /// Gets the command to save the current document under a new file name.
        /// </summary>
        public ICommand SaveAsCommand => new RelayCommand(
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
            });

        /// <summary>
        /// Gets the command to exit the application.
        /// </summary>
        public ICommand ExitCommand => new RelayCommand(() =>
        {
            this.applicationService.Shutdown();
        });

        /// <summary>
        /// Gets the command to manage extension sets.
        /// </summary>
        public ICommand ManageExtensionSetsCommand => new RelayCommand(() => MessageBox.Show("Manage Extension-Sets Command"));

        /// <summary>
        /// Gets the command to manage file mappings.
        /// </summary>
        public ICommand ManageMappingsCommand => new RelayCommand(() => MessageBox.Show("Manage Mappings Command"));

        /// <summary>
        /// Gets the command to show the "About" dialog.
        /// </summary>
        public ICommand AboutCommand => new RelayCommand(() => MessageBox.Show("About Command"));

        /// <summary>
        /// Gets the command to add a new set.
        /// </summary>
        public ICommand AddSetCommand => new RelayCommand(() => MessageBox.Show("Add Set Command"));

        /// <summary>
        /// Gets the command to edit the selected set.
        /// </summary>
        public ICommand EditSetCommand => new RelayCommand(() => MessageBox.Show("Edit Set Command"));

        /// <summary>
        /// Gets the command to delete the selected set.
        /// </summary>
        public ICommand DeleteSetCommand => new RelayCommand(() => MessageBox.Show("Delete Set Command"));

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}