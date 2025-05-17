namespace Editor.Application.Events
{
    using System;

    public class EditorTextChangedEvent
    {
        public event EventHandler? EditorTextChanged;

        public void RaiseOnEditorTextChanged()
        {
            EditorTextChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}