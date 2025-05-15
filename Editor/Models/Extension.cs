// <copyright file="Extension.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Models
{
    using System.ComponentModel;

    /// <summary>
    /// Represents an extension that can be activated or deactivated in the editor.
    /// </summary>
    public class Extension : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Extension"/> class.
        /// </summary>
        public Extension()
        {
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the extension is currently active.
        /// </summary>
        public bool IsActive
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.IsActive));
                field = value;
            }
        }

        /// <summary>
        /// Gets or sets the display name of the extension.
        /// </summary>
        public string? Name
        {
            get => field;
            set
            {
                this.OnPropertyChanged(nameof(this.Name));
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