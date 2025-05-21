// <copyright file="BindableRichTextBox.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    /// <summary>
    /// .
    /// </summary>
    public class BindableRichTextBox : RichTextBox
    {
        /// <summary>
        /// .
        /// </summary>
        public static readonly DependencyProperty BindableContentProperty =
            DependencyProperty.Register(
                nameof(ContentText),
                typeof(string),
                typeof(BindableRichTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnContentTextChanged));

        private bool isUpdatingInternally = false;

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public string ContentText
        {
            get => (string)this.GetValue(BindableContentProperty);
            set => this.SetValue(BindableContentProperty, value);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="e">..</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (this.isUpdatingInternally)
            {
                return;
            }

            base.OnTextChanged(e);

            var text = new TextRange(this.Document.ContentStart, this.Document.ContentEnd).Text;
            this.SetCurrentValue(BindableContentProperty, text);
        }

        private static void OnContentTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var richTextBox = (BindableRichTextBox)dependencyObject;
            var newText = e.NewValue as string ?? string.Empty;

            if (richTextBox.isUpdatingInternally)
            {
                return;
            }

            richTextBox.isUpdatingInternally = true;

            var range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            var currentText = range.Text;

            if (currentText != newText)
            {
                range.Text = newText;
            }

            richTextBox.isUpdatingInternally = false;
        }
    }
}
