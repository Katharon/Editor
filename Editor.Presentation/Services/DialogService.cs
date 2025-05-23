﻿// <copyright file="DialogService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Services
{
    using System.Windows;
    using Editor.Application;
    using Microsoft.Win32;

    /// <summary>
    /// .
    /// </summary>
    public class DialogService : IDialogService
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
        public void ShowMessage(string message, string title = "Info")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <inheritdoc/>
        public void ShowError(string message, string title = "Fehler")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}