// <copyright file="MainWindow.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation
{
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using Editor.Application;
    using Editor.Presentation.Services;
    using Editor.Presentation.ViewModels;
    using Editor.Presentation.Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApplicationService applicationService;

        private readonly IDialogService dialogService;

        private readonly IExtensionService extensionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            // Loads Assembly instead of Dependency Injection ("forbidden" in this project).
            string solutionPath = Directory
                .GetParent(AppDomain.CurrentDomain.BaseDirectory)
                ?.Parent
                ?.Parent
                ?.Parent
                ?.Parent
                ?.FullName
                ?? throw new ArgumentNullException(nameof(solutionPath));

            string applicationPath = Path.Combine(
                solutionPath,
                "Editor.Application",
                "bin",
                "Debug",
                "net9.0",
                "Editor.Application.dll");

            Assembly assembly = Assembly.LoadFrom(applicationPath);
            Type type = assembly.GetType("Editor.Application.ExtensionService") ?? throw new ArgumentNullException(nameof(applicationPath));
            object instance = Activator.CreateInstance(type) ?? throw new ArgumentNullException(nameof(type));
            IExtensionService extensionService = instance as IExtensionService ?? throw new ArgumentNullException(nameof(extensionService));

            // Injects the loaded `extensionService`.
            this.extensionService = extensionService;
            this.applicationService = new ApplicationService();
            this.dialogService = new DialogService();

            var mainView = new MainView(this)
            {
                DataContext = new MainViewModel(this.applicationService, this.dialogService, this.extensionService),
            };

            this.MainFrame.Navigate(mainView);
        }
    }
}