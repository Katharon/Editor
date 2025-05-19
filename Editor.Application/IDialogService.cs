namespace Editor.Application
{
    public interface IDialogService
    {
        string? ShowOpenFileDialog(string title, string filter);

        string? ShowSaveFileDialog(string title, string filter, string defaultExtension);

        void ShowMessage(string message, string title = "Info");

        void ShowError(string message, string title = "Fehler");
    }
}