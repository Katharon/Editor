// <copyright file="ExtensionSet.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Editor.Presentation.Models;

    /// <summary>
    /// .
    /// </summary>
    public class ExtensionSet
    {
        /// <summary>
        /// Gets.
        /// </summary>
        public string DisplayName { get; init; } = string.Empty;

        /// <summary>
        /// Gets.
        /// </summary>
        public ObservableCollection<IEditorExtension> Extensions { get; } = new ();

        /// <summary>
        /// Gets or sets a value indicating whether.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="context">..</param>
        public void Apply(DocumentContext context)
        {
            if (!this.IsEnabled)
            {
                return;
            }

            foreach (var extension in this.Extensions.Where(e => e.FileTypes.Contains(context.FileType)))
            {
                extension.Apply(context);
            }
        }
    }
}
