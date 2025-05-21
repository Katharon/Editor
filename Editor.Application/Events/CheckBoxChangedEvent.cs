namespace Editor.Application.Events
{
    using System;

    public static class CheckBoxChangedEvent
    {
        public static event EventHandler<bool>? CheckBoxChanged;

        public static void RaiseOnCheckBoxChanged(object sender, bool e)
        {
            CheckBoxChanged?.Invoke(sender, e);
        }
    }
}