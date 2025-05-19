// <copyright file="MainWindow.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor
{
    using System.Windows;
    using Editor.Application;
    using Editor.Presentation.Services;
    using Editor.Presentation.ViewModels;
    using Editor.Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApplicationService applicationService = new ApplicationService();

        private readonly IDialogService dialogService = new DialogService();

        private readonly IExtensionService extensionService = new ExtensionService();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            var mainView = new MainView(this)
            {
                DataContext = new MainViewModel(this.applicationService, this.dialogService, this.extensionService),
            };

            this.MainFrame.Navigate(mainView);
        }
    }
}