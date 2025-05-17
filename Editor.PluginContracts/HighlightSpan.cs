namespace Editor.PluginContracts
{
    using System;

    public class HighlightSpan
    {
        public int StartIndex { get; set; }
        public int Length { get; set; }
        public string HighlightType { get; set; } = string.Empty;
    }
}