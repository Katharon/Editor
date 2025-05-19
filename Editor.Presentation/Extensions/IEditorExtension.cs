// <copyright file="IEditorExtension.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Extensions
{
    using Editor.Presentation.Models;

    /// <summary>
    /// .
    /// </summary>
    public interface IEditorExtension
    {
        /// <summary>
        /// Gets.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        IReadOnlyCollection<string> FileTypes { get; }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="context">..</param>
        void Apply(DocumentContext context);
    }
}