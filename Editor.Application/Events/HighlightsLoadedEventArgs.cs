namespace Editor.Application.Events
{
    using Editor.PluginContracts;
    using System;
    using System.Collections.ObjectModel;

    public class HighlightsLoadedEventArgs : EventArgs
    {
        public HighlightsLoadedEventArgs(ObservableCollection<HighlightSpan> highlights)
        {
            this.Highlights = highlights;   
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public ObservableCollection<HighlightSpan> Highlights { get; }
    }
}
