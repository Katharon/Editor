namespace Editor.Application.Events
{
    using System;

    public static class EditorTextChangedEvent
    {
        public static event EventHandler? EditorTextChanged;

        public static void RaiseOnEditorTextChanged(object sender, EventArgs e)
        {
            EditorTextChanged?.Invoke(sender, e);
        }
    }
}