// <copyright file="SimpleWordCorrection.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Extensions
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows.Documents;
    using Editor.Models;

    /// <summary>
    /// .
    /// </summary>
    public class SimpleWordCorrection : ITextTransformer
    {
        private static readonly Dictionary<string, string> Map = new ()
        {
            ["wei"] = "wie",
            ["Gottfired"] = "Gottfried",
            ["Halo"] = "Hallo",
            ["Wiso"] = "Wieso",
        };

        /// <summary>
        /// Gets.
        /// </summary>
        public string Name => "Simple Word Correction";

        /// <summary>
        /// Gets.
        /// </summary>
        public IReadOnlyCollection<string> FileTypes => new List<string>() { ".txt" };

        /// <summary>
        /// .
        /// </summary>
        /// <param name="context">..</param>
        public void Apply(DocumentContext context)
        {
            var newText = Regex.Replace(context.Text, @"\b(" + string.Join("|", Map.Keys) + @")\b", m => Map[m.Value]);
            if (newText != context.Text)
            {
                var caret = context.CaretIndex;
                context.Editor.Document.Blocks.Clear();
                context.Editor.Document.Blocks.Add(new Paragraph(new Run(newText)));
                context.Editor.CaretPosition = context.Editor.Document.ContentStart.GetPositionAtOffset(caret);
            }
        }
    }
}
