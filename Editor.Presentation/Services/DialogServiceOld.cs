// <copyright file="DialogServiceOld.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Services
{
    using System.Collections.Generic;
    using System.Windows;
    using Microsoft.Win32;

    /// <summary>
    /// Provides various dialog functionalities for file handling and user interaction.
    /// </summary>
    public class DialogServiceOld // : IDialogService
    {
        /// <inheritdoc/>
        public string? ShowOpenFileDialog(string title, string filter)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
            };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }

        /// <inheritdoc/>
        public string? ShowSaveFileDialog(string title, string filter, string defaultExtension)
        {
            var dialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter,
                DefaultExt = defaultExtension,
            };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }

        /// <inheritdoc/>
        public string? ShowLoadExtensionSetDialog()
        {
            return ShowOpenFileDialog("Erweiterungsset laden", "Erweiterungssets (*.extset)|*.extset");
        }

        /// <inheritdoc/>
        public string? ShowSaveExtensionSetDialog()
        {
            return ShowSaveFileDialog("Erweiterungsset speichern", "Erweiterungssets (*.extset)|*.extset", ".extset");
        }

        /// <inheritdoc/>
        public void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <inheritdoc/>
        public bool ShowConfirmation(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }

        /// <inheritdoc/>
        public string? ShowSelectionDialog(string title, IEnumerable<string> options)
        {
            return null;
        }
    }
}