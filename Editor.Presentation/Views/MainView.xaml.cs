// <copyright file="MainView.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Views
{
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Editor.Presentation.Controls;
    using Editor.Presentation.Helpers;

    /// <summary>
    /// Interaction logic for MainView.xaml. Represents the main editor view.
    /// </summary>
    public partial class MainView : Page
    {
        private static readonly Dictionary<string, SolidColorBrush> KeywordColors = new ()
        {
            // Sichtbarkeiten
            ["public"] = Brushes.MediumPurple,
            ["private"] = Brushes.MediumPurple,
            ["protected"] = Brushes.MediumPurple,
            ["internal"] = Brushes.MediumPurple,

            // Typen
            ["int"] = Brushes.Orange,
            ["float"] = Brushes.Orange,
            ["string"] = Brushes.Orange,
            ["bool"] = Brushes.Orange,
            ["void"] = Brushes.Orange,

            // Kontrollfluss
            ["if"] = Brushes.LightGreen,
            ["else"] = Brushes.LightGreen,
            ["return"] = Brushes.LightGreen,

            // Klassendeklaration
            ["class"] = Brushes.DeepSkyBlue,

            // Methoden
            ["static"] = Brushes.Coral,
        };

        private readonly Window window;

        private bool isUpdatingInternally = false;

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
            if (this.isUpdatingInternally)
            {
                return;
            }

            this.isUpdatingInternally = true;

            if (sender is BindableRichTextBox textBox)
            {
                var document = textBox.Document;

                var fullRange = new TextRange(document.ContentStart, document.ContentEnd);
                fullRange.ClearAllProperties();
                fullRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.White);
                fullRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);

                string fullText = fullRange.Text;

                var keywordRegex = new Regex(@"\b(" + string.Join("|", KeywordColors.Keys) + @")\b");
                foreach (Match match in keywordRegex.Matches(fullText))
                {
                    var word = match.Value;

                    if (!KeywordColors.TryGetValue(word, out var color))
                    {
                        continue;
                    }

                    var start = TextHelper.GetTextPositionAtOffset(document.ContentStart, match.Index);
                    var end = TextHelper.GetTextPositionAtOffset(start!, match.Length);

                    if (start != null && end != null)
                    {
                        var highlightRange = new TextRange(start, end);
                        highlightRange.ApplyPropertyValue(TextElement.ForegroundProperty, color);
                        highlightRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                    }
                }
            }

            this.isUpdatingInternally = false;
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