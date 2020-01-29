// -----------------------------------------------------------------------
// <copyright file="StringBuilderExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith.Internal
{
    using System.Text;

    using JetBrains.Annotations;

    /// <summary>
    ///     String Builder Extensions
    /// </summary>
    internal static class StringBuilderExtensions
    {
        /// <summary>
        ///     Appends the with escaped brackets.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        public static void AppendWithEscapedBrackets(
            [NotNull] this StringBuilder stringBuilder,
            [NotNull] string value,
            int startIndex,
            int count,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            var currentTokenStart = startIndex;
            for (var i = startIndex; i < startIndex + count; i++)
            {
                if (value[i] == openBraceChar)
                {
                    stringBuilder.Append(value, currentTokenStart, i - currentTokenStart);
                    stringBuilder.Append(openBraceChar);
                    currentTokenStart = i;
                }
                else if (value[i] == closeBraceChar)
                {
                    stringBuilder.Append(value, currentTokenStart, i - currentTokenStart);
                    stringBuilder.Append(closeBraceChar);
                    currentTokenStart = i;
                }
            }

            // add the final section
            stringBuilder.Append(value, currentTokenStart, (startIndex + count) - currentTokenStart);
        }
    }
}