namespace Editor.Infrastructure
{
    using Editor.Application;
    using Editor.Application.Events;
    using Editor.PluginContracts;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Loader;

    public class AssemblyLoader : IAssemblyLoader
    {
        private readonly HashSet<string> loadedAssemblies;

        private readonly string pluginDirectory;

        public AssemblyLoader()
        {
            this.loadedAssemblies = new HashSet<string>();
            this.pluginDirectory = Path.Combine(AppContext.BaseDirectory, "Extensions");
            Directory.CreateDirectory(this.pluginDirectory);
        }

        public event EventHandler<ExtensionsLoadedEventArgs>? AssemblyLoaded;

        public IEnumerable<IExtension> LoadAll()
        {
            var result = new List<IExtension>();

            foreach (var dllPath in Directory.EnumerateFiles(this.pluginDirectory, "*.dll"))
            {
                if (this.loadedAssemblies.Contains(dllPath))
                {
                    continue;
                }

                try
                {
                    // var assembly = Assembly.Load(dllPath);
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);

                    var types = assembly.GetTypes()
                        .Where(t => typeof(IExtension).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);

                    foreach (var type in types)
                    {
                        if (Activator.CreateInstance(type) is IExtension instance)
                        {
                            result.Add(instance);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            if (result.Count != 0)
            {
                this.RaiseOnAssemblyLoaded(result);
            }

            return result;
        }

        public void StartWatching()
        {
            var watcher = new FileSystemWatcher(this.pluginDirectory, "*.dll")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };

            watcher.Created += (_, e) => LoadAll();
            watcher.Changed += (_, e) => LoadAll();
        }

        private void RaiseOnAssemblyLoaded(IEnumerable<IExtension> loadedExtensions)
        {
            this.AssemblyLoaded?.Invoke(this, new ExtensionsLoadedEventArgs(loadedExtensions));
        }
    }
}