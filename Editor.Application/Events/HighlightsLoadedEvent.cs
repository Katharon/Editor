namespace Editor.Application.Events
{
    using Editor.PluginContracts;
    using System;

    public static class HighlightsLoadedEvent
    {
        public static event EventHandler<HighlightsLoadedEventArgs>? HighlightsLoaded;

        public static void RaiseOnHighlightsLoaded(object sender, HighlightsLoadedEventArgs e)
        {
            HighlightsLoaded?.Invoke(sender, e);
        }
    }
}
