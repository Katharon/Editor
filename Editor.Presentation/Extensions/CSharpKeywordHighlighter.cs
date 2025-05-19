namespace Editor.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Editor.Presentation.Models;

    /// <summary>
    /// .
    /// </summary>
    public partial class CSharpKeywordHighlighter : IHighlighter
    {
        private static readonly Regex Keywords = new (@"\b(abstract|as|base|…|while)\b", RegexOptions.Compiled);

        /// <summary>
        /// Gets.
        /// </summary>
        public string Name => "C# Keywords";

        /// <summary>
        /// Gets.
        /// </summary>
        public IReadOnlyCollection<string> FileTypes => new List<string>() { ".cs" };

        /// <summary>
        /// .
        /// </summary>
        /// <param name="context">..</param>
        public void Apply(DocumentContext context)
        {
            // Sehr simple Variante:
            context.Editor.TextChanged -= this.Editor_TextChanged;
            context.Editor.SelectAll();
            context.Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.White);
            context.Editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);

            foreach (Match match in Keywords.Matches(context.Text))
            {
                // context.Editor.Select(match.Index, match.Length);
                context.Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.CornflowerBlue);
                context.Editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }

            // context.Editor.Select(context.CaretIndex, 0);
            context.Editor.TextChanged += this.Editor_TextChanged;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
