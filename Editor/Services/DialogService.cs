namespace Editor.Services
{
    using Microsoft.Win32;
    using System.Collections.Generic;
    using System.Windows;

    public class DialogService : IDialogService
    {
        public string? ShowOpenFileDialog(string title, string filter)
        {
            var dlg = new OpenFileDialog
            {
                Title = title,
                Filter = filter
            };

            return dlg.ShowDialog() == true ? dlg.FileName : null;
        }

        public string? ShowSaveFileDialog(string title, string filter, string defaultExtension)
        {
            var dlg = new SaveFileDialog
            {
                Title = title,
                Filter = filter,
                DefaultExt = defaultExtension
            };

            return dlg.ShowDialog() == true ? dlg.FileName : null;
        }

        public string? ShowLoadExtensionSetDialog()
        {
            return ShowOpenFileDialog("Erweiterungsset laden", "Erweiterungssets (*.extset)|*.extset");
        }

        public string? ShowSaveExtensionSetDialog()
        {
            return ShowSaveFileDialog("Erweiterungsset speichern", "Erweiterungssets (*.extset)|*.extset", ".extset");
        }

        public void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowConfirmation(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }

        public string? ShowSelectionDialog(string title, IEnumerable<string> options)
        {
            // Für einfache Auswahl kannst du ein eigenes Fenster bauen oder einen InputDialog nutzen.
            // Hier nur Platzhalter:
            return null;
        }
    }
}
