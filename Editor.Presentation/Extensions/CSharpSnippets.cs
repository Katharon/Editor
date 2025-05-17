// <copyright file="CSharpSnippets.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Extensions
{
    using System;
    using System.Collections.Generic;
    using Editor.Models;

    /// <summary>
    /// .
    /// </summary>
    public class CSharpSnippets : ISnippetProvider
    {
        private record Snippet(string shortcut, string code);

        private static readonly Snippet[] Snippets =
        [
            new ("cw", "Console.WriteLine($\"{variable}\");"),
            new ("for", "for (int i = 0; i < length; i++)\n{\n    \n}"),
            new ("forr", "for (int i = length - 1; i >= 0; i--)\n{\n    \n}"),
            new ("foreach", "foreach (var item in collection)\n{\n    \n}"),
        ];

        /// <summary>
        /// Gets.
        /// </summary>
        public string Name => "C# Snippets";

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
            foreach (var s in Snippets)
            {
                var shortcut = s.shortcut + "\t\t";
                var idx = context.Text.LastIndexOf(shortcut, StringComparison.Ordinal);
                if (idx >= 0 && idx + shortcut.Length == context.CaretIndex)
                {
                    // context.Editor.Select(idx, shortcut.Length);
                    // context.Editor.Selection.Text = s.Code;
                    context.Editor.CaretPosition = context.Editor.Selection.End;
                    break;
                }
            }
        }
    }
}
