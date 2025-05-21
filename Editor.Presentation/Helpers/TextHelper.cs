// <copyright file="TextHelper.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Helpers
{
    using System.Windows.Documents;

    /// <summary>
    /// .
    /// </summary>
    internal static class TextHelper
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="start">..</param>
        /// <param name="offset">...</param>
        /// <returns>....</returns>
        internal static TextPointer? GetTextPositionAtOffset(TextPointer start, int offset)
        {
            int count = 0;
            var pointer = start;

            while (pointer != null)
            {
                if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                    if (count + textRun.Length >= offset)
                    {
                        return pointer.GetPositionAtOffset(offset - count);
                    }

                    count += textRun.Length;
                }

                pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
            }

            return null;
        }
    }
}
