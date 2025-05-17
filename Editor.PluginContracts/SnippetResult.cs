namespace Editor.PluginContracts
{
    using System;

    public class Snippet
    {
        public int ReplaceStart { get; set; }
        public int ReplaceLength { get; set; }
        public string ReplacementText { get; set; } = string.Empty;
    }
}