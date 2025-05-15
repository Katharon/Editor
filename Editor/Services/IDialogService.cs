// <copyright file="IDialogService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a service that handles various types of dialogs, such as file dialogs, error messages, and user confirmations.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Displays an open file dialog.
        /// </summary>
        /// <param name="title">The title of the dialog window.</param>
        /// <param name="filter">The file type filter (e.g., "Text files (*.txt)|*.txt").</param>
        /// <returns>The selected file path, or <c>null</c> if canceled.</returns>
        string? ShowOpenFileDialog(string title, string filter);

        /// <summary>
        /// Displays a save file dialog.
        /// </summary>
        /// <param name="title">The title of the dialog window.</param>
        /// <param name="filter">The file type filter.</param>
        /// <param name="defaultExtension">The default file extension (e.g., ".txt").</param>
        /// <returns>The selected file path, or <c>null</c> if canceled.</returns>
        string? ShowSaveFileDialog(string title, string filter, string defaultExtension);

        /// <summary>
        /// Displays an open file dialog for loading extension sets.
        /// </summary>
        /// <returns>The selected file path, or <c>null</c> if canceled.</returns>
        string? ShowLoadExtensionSetDialog();

        /// <summary>
        /// Displays a save file dialog for saving extension sets.
        /// </summary>
        /// <returns>The selected file path, or <c>null</c> if canceled.</returns>
        string? ShowSaveExtensionSetDialog();

        /// <summary>
        /// Displays an error message dialog.
        /// </summary>
        /// <param name="title">The title of the error dialog.</param>
        /// <param name="message">The error message to display.</param>
        void ShowError(string title, string message);

        /// <summary>
        /// Displays a confirmation dialog with OK and Cancel buttons.
        /// </summary>
        /// <param name="title">The title of the confirmation dialog.</param>
        /// <param name="message">The message to display.</param>
        /// <returns><c>true</c> if the user confirms; otherwise, <c>false</c>.</returns>
        bool ShowConfirmation(string title, string message);

        /// <summary>
        /// Displays a dialog to select one option from a list of strings.
        /// </summary>
        /// <param name="title">The title of the selection dialog.</param>
        /// <param name="options">A collection of selectable options.</param>
        /// <returns>The selected option, or <c>null</c> if canceled.</returns>
        string? ShowSelectionDialog(string title, IEnumerable<string> options);
    }
}