// <copyright file="ExtensionService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Services
{
    using Editor.Extensions;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Loader;

    /// <summary>
    /// Provides functionality for managing and interacting with editor extensions.
    /// </summary>
    public class ExtensionService : IExtensionService
    {
        private readonly Dictionary<string, Assembly> extensions = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionService"/> class.
        /// </summary>
        public ExtensionService()
        {
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions");
            Directory.CreateDirectory(pluginsPath);

            var watcher = new FileSystemWatcher(pluginsPath, "*.dll")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
            };
            watcher.Created += (_, e) => this.LoadPlugin(e.FullPath);
            watcher.Changed += (_, e) => this.ReloadPlugin(e.FullPath);
            watcher.EnableRaisingEvents = true;

        }

        private void LoadPlugin(string fullPath)
        {
            // .NET 6+ : lädt die DLL in denselben Kontext
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(fullPath);
            this.extensions[fullPath] = assembly;

            // Alle Typen suchen, die das Plug-in-Interface implementieren
            var extensions = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && typeof(IEditorExtension).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IEditorExtension>();

            foreach (var extension in extensions)
            {
                ExtensionRegistry.Register(extension);
            }
        }

        private void ReloadPlugin(string fullPath)
        {
            throw new NotImplementedException();
        }
    }
}