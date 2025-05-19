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
        public static readonly DependencyProperty BindableDocumentProperty =
            DependencyProperty.Register(
                nameof(BindableDocument),
                typeof(FlowDocument),
                typeof(BindableRichTextBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableDocumentChanged));

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public FlowDocument BindableDocument
        {
            get => (FlowDocument)this.GetValue(BindableDocumentProperty);
            set => this.SetValue(BindableDocumentProperty, value);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="e">..</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            this.SetCurrentValue(BindableDocumentProperty, this.Document);
        }

        private static void OnBindableDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rtb = (BindableRichTextBox)d;
            rtb.Document = e.NewValue as FlowDocument ?? new FlowDocument();
        }
    }
}
