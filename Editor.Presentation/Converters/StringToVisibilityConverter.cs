// <copyright file="StringToVisibilityConverter.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts a string to a <see cref="Visibility"/> value.
    /// Returns <see cref="Visibility.Collapsed"/> if the string is null, empty, or whitespace; otherwise, returns <see cref="Visibility.Visible"/>.
    /// </summary>
    public class StringToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? input = value as string;
            return string.IsNullOrWhiteSpace(input) ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}