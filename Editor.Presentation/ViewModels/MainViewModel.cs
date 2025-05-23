﻿// <copyright file="MainViewModel.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using Editor.Application;
    using Editor.Application.Events;
    using Editor.PluginContracts;
    using Editor.Presentation.Commands;

    /// <summary>
    /// Represents the main view model of the application, containing documents, extensions,
    /// editor commands, and state information such as the status message and caret position.
    /// </summary>
    public class MainViewModel : ObservableObject, INotifyPropertyChanged
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

            this.Extensions = new ObservableCollection<IExtension>();
            this.ExtensionSets = new ObservableCollection<IExtensionSet>();
            this.Documents = new ObservableCollection<Document>();

            this.NewFileCommand.Execute(null);
            this.Extensions = new ObservableCollection<IExtension>(this.extensionService.LoadExtensions());

            EditorTextChangedEvent.EditorTextChanged += this.UpdateHighlights;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChangedOld;

        /// <summary>
        /// Gets or sets the status message shown to the user.
        /// </summary>
        public string? StatusMessage
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
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
                this.SetProperty(ref field, value);
            }
        }

        /// <summary>
        /// Gets or sets the collection of available extensions.
        /// </summary>
        public ObservableCollection<IExtension> Extensions { get; set; }

        /// <summary>
        /// Gets or sets the currently selected extension.
        /// </summary>
        public IExtension? SelectedExtension
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        /// <summary>
        /// Gets or sets the collection of available extension sets.
        /// </summary>
        public ObservableCollection<IExtensionSet> ExtensionSets { get; set; }

        /// <summary>
        /// Gets or sets the currently selected extension set.
        /// </summary>
        public IExtensionSet? SelectedExtensionSet
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
            }
        }

        /// <summary>
        /// Gets or sets the collection of open documents.
        /// </summary>
        public ObservableCollection<Document> Documents { get; set; }

        /// <summary>
        /// Gets or sets the currently active document.
        /// </summary>
        public Document? SelectedDocument
        {
            get => field;
            set
            {
                this.SetProperty(ref field, value);
                this.OnPropertyChanged(nameof(this.SelectedDocument));
                this.OnPropertyChanged(nameof(this.SaveFileCommand));
                this.OnPropertyChanged(nameof(this.SaveFileAsCommand));
            }
        }

        /// <summary>
        /// Gets the command to create a new document.
        /// </summary>
        public ICommand NewFileCommand => new RelayCommand(() =>
        {
            var document = new Document
            {
                FileName = "New File",
            };

            this.Documents.Add(document);
            this.SelectedDocument = document;
        });

        /// <summary>
        /// Gets the command to open an existing file.
        /// </summary>
        public ICommand OpenFileCommand => new RelayCommand(() =>
        {
            string? filePath = this.dialogService.ShowOpenFileDialog("Datei öffnen", string.Empty);
            if (filePath == null)
            {
                // FEHLERMELDUNG!!!!!
                return;
            }

            try
            {
                var flowDocument = new FlowDocument();
                var range = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);

                using var stream = new FileStream(filePath, FileMode.Open);
                range.Load(stream, DataFormats.Text);

                var document = new Document()
                {
                    FilePath = filePath,
                    FileName = Path.GetFileName(filePath),
                    Content = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd).Text,
                };

                this.Documents.Add(document);
                this.SelectedDocument = document;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });

        /// <summary>
        /// Gets the command to save the current document.
        /// </summary>
        public ICommand SaveFileCommand => new RelayCommand(
            canExecute: () => this.SelectedDocument != null,
            execute: () =>
            {
                if (this.SelectedDocument != null)
                {
                    if (!string.IsNullOrWhiteSpace(this.SelectedDocument.FilePath))
                    {
                        try
                        {
                            // var flowDocument = this.SelectedDocument.Content;
                            // var range = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                            // File.WriteAllText(this.SelectedDocument.FilePath, range.Text);
                            File.WriteAllText(this.SelectedDocument.FilePath, this.SelectedDocument.Content);

                            this.StatusMessage = $"Gespeichert: {this.SelectedDocument.FileName}";
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
                        return;
                    }

                    try
                    {
                        // var flowDocument = this.SelectedDocument.FlowDocument;
                        // var range = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                        // File.WriteAllText(filePath, range.Text);
                        File.WriteAllText(filePath, this.SelectedDocument.Content);

                        this.SelectedDocument.FilePath = filePath;
                        this.SelectedDocument.FileName = Path.GetFileName(filePath);
                        this.StatusMessage = $"Gespeichert als: {this.SelectedDocument.FileName}";
                    }
                    catch (Exception ex)
                    {
                        this.StatusMessage = $"NICHT Gespeichert: {this.SelectedDocument.FileName}";
                        this.dialogService.ShowError("Fehler beim Speichern", ex.Message);
                    }
                }
            });

        /// <summary>
        /// Gets the command to save the current document under a new file name.
        /// </summary>
        public ICommand SaveFileAsCommand => new RelayCommand(
            canExecute: () => this.SelectedDocument != null,
            execute: () =>
            {
                if (this.SelectedDocument != null)
                {
                    string? filePath = this.dialogService.ShowSaveFileDialog("Datei speichern", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", ".txt");
                    if (filePath == null)
                    {
                        return;
                    }

                    try
                    {
                        // var flowDocument = this.SelectedDocument.FlowDocument;
                        // var range = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                        // File.WriteAllText(filePath, range.Text);
                        File.WriteAllText(filePath, this.SelectedDocument.Content);

                        this.SelectedDocument.FilePath = filePath;
                        this.SelectedDocument.FileName = Path.GetFileName(filePath);
                        this.StatusMessage = $"Gespeichert als: {this.SelectedDocument.FileName}";
                    }
                    catch (Exception ex)
                    {
                        this.StatusMessage = $"NICHT Gespeichert: {this.SelectedDocument.FileName}";
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
        /// Gets the command to add a new extension set.
        /// </summary>
        public ICommand NewExtensionSetCommand => new RelayCommand(() =>
        {
            // ToDo: nur Extensionnamen speichern.
            string? filePath = this.dialogService.ShowSaveFileDialog("Extension Set Namen wählen", "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*", string.Empty);
            if (filePath == null)
            {
                return;
            }

            var extensionSet = new ExtensionSet()
            {
                Name = Path.GetFileName(filePath),
                IsEnabled = false,
            };

            this.ExtensionSets.Add(extensionSet);
            this.SelectedExtensionSet = extensionSet;
        });

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
        /// Gets.
        /// </summary>
        public ObservableCollection<HighlightSpan> Highlights { get; } = new ();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="sender">..</param>
        /// <param name="e">...</param>
        private void UpdateHighlights(object? sender, EventArgs e)
        {
            this.Highlights.Clear();

            var document = new Document
            {
                Content = this.SelectedDocument?.Content ?? string.Empty,
                FileName = this.SelectedDocument?.FileName!,
            };

            foreach (var highlighter in this.Extensions.OfType<ISyntaxHighlighter>())
            {
                foreach (var span in highlighter.GetHighlights(document))
                {
                    if (highlighter.IsActive)
                    {
                        this.Highlights.Add(span);
                    }
                }
            }

            var eventArgs = new HighlightsLoadedEventArgs(this.Highlights);
            HighlightsLoadedEvent.RaiseOnHighlightsLoaded(sender!, eventArgs);
        }

        /// <summary>
        /// Raises the <see cref="PropertyChangedOld"/> event for the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChangedOld?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}