// <copyright file="MainView.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Views
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainView.xaml. Represents the main editor view.
    /// </summary>
    public partial class MainView : Page
    {
        private readonly Window window;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        /// <param name="window">The parent window that hosts this page.</param>
        public MainView(Window window)
        {
            this.InitializeComponent();
            this.window = window;
        }

        /// <summary>
        /// Handles the Loaded event of the editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Editor_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the TextChanged event of the editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        /// <summary>
        /// Minimizes the window when the Minimize button is clicked.
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data.</param>
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.window.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Toggles between normal and maximized window state when the Maximize button is clicked.
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data.</param>
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.window.WindowState = (this.window.WindowState == WindowState.Maximized)
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        /// <summary>
        /// Closes the window when the Close button is clicked.
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data.</param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.window.Close();
        }
    }
}