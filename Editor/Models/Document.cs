// <copyright file="Document.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Models
{
    using System.ComponentModel;
    using System.Windows.Documents;

    /// <summary>
    /// Represents a document model containing metadata and content for editing.
    /// Supports property change notifications for data binding.
    /// </summary>
    public class Document : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document()
        {
            this.FlowDocument = new FlowDocument();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the <see cref="FlowDocument"/> that contains the rich text content of the document.
        /// </summary>
        public FlowDocument FlowDocument
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.FlowDocument));
                field = value;
            }
        }

        /// <summary>
        /// Gets or sets the file name of the document (without path).
        /// </summary>
        public string? FileName
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.FileName));
                field = value;
            }
        }

        /// <summary>
        /// Gets or sets the full file path of the document.
        /// </summary>
        public string? FilePath
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.FilePath));
                field = value;
            }
        }

        /// <summary>
        /// Gets or sets the plain text representation of the document content.
        /// </summary>
        public string? Content
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.Content));
                field = value;
            }
        }

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