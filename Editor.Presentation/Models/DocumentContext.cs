// <copyright file="DocumentContext.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Models
{
    using Editor.Presentation.Controls;

    /// <summary>
    /// .
    /// </summary>
    public class DocumentContext
    {
        /// <summary>
        /// Gets or sets.
        /// </summary>
        required public string FileType { get; set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        required public string Text { get; set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        required public int CaretIndex { get; set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        required public BindableRichTextBox Editor { get; set; }
    }
}