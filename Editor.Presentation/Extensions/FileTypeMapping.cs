// <copyright file="FileTypeMapping.cs" company="Fachhochschule Wiener Neustadt GmbH">
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

    /// <summary>
    /// .
    /// </summary>
    public class FileTypeMapping
    {
        public string Extension { get; init; } = ".cs";

        public string Description { get; init; } = "C#-Datei";

        public ObservableCollection<ExtensionSet> Sets { get; } = new ();
    }
}
