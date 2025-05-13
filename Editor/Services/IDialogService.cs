namespace Editor.Services
{
    using System.Collections.Generic;

    public interface IDialogService
    {
        string? ShowOpenFileDialog(string title, string filter);
        string? ShowSaveFileDialog(string title, string filter, string defaultExtension);
        string? ShowLoadExtensionSetDialog();
        string? ShowSaveExtensionSetDialog();
        void ShowError(string title, string message);
        bool ShowConfirmation(string title, string message);
        string? ShowSelectionDialog(string title, IEnumerable<string> options);
    }
}
