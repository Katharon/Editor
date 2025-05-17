// <copyright file="ExtensionRegistry.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// .
    /// </summary>
    public class ExtensionRegistry
    {
        /// <summary>
        /// Gets or sets.
        /// </summary>
        public static List<IEditorExtension> Extensions { get; set; } = new ();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="extension">..</param>
        public static void Register(IEditorExtension extension) => Extensions.Add(extension);
    }
}
