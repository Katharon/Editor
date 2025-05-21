// <copyright file="MainView.xaml.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Editor.Application.Events;
    using Editor.Presentation.Controls;
    using Editor.Presentation.Helpers;

    /// <summary>
    /// Interaction logic for MainView.xaml. Represents the main editor view.
    /// </summary>
    public partial class MainView : Page
    {
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

            HighlightsLoadedEvent.HighlightsLoaded += this.OnHighlightsLoaded;
        }

        /// <summary>
        /// Handles the TextChanged event of the editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is BindableRichTextBox textBox)
            {
                EditorTextChangedEvent.RaiseOnEditorTextChanged(textBox, e);
            }
        }

        private void OnHighlightsLoaded(object? sender, HighlightsLoadedEventArgs e)
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

                var highlightSpans = e.Highlights.ToList();
                foreach (var span in highlightSpans)
                {
                    if (span.StartIndex < 0 || span.Length <= 0)
                    {
                        continue;
                    }

                    var start = TextHelper.GetTextPositionAtOffset(document.ContentStart, span.StartIndex);
                    var end = TextHelper.GetTextPositionAtOffset(start!, span.Length);

                    if (start != null && end != null)
                    {
                        var range = new TextRange(start, end);

                        if (!string.IsNullOrWhiteSpace(span.HexColor))
                        {
                            var color = (Color)ColorConverter.ConvertFromString(span.HexColor);
                            range.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color));
                            range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                        }
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