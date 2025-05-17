namespace Editor.Application.Events
{
    using System;

    public class CursorPositionChangedEvent
    {
        public event EventHandler? CursorPositionChanged;

        public void RaiseOnCursorPositionChanged()
        {
            CursorPositionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}