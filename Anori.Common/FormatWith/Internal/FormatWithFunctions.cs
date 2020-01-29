// -----------------------------------------------------------------------
// <copyright file="FormatWithFunctions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Anori.Common.FormatWith.Exceptions;

    using JetBrains.Annotations;

    /// <summary>
    ///     Format With Methods
    /// </summary>
    internal static class FormatWithFunctions
    {
        /// <summary>
        ///     The property binding flags
        /// </summary>
        private const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public;

        /// <summary>
        ///     Formats the with.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(
            string formatString,
            IDictionary<string, string> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            string fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormatWith(
                formatString,
                key => new ReplacementResult(replacements.TryGetValue(key, out var value), value),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats the with.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(
            string formatString,
            IDictionary<string, object> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormatWith(
                formatString,
                key => new ReplacementResult(replacements.TryGetValue(key, out var value), value),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats the with.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacementObject">The replacement object.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(
            [NotNull] string formatString,
            [NotNull] object replacementObject,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormatWith(
                formatString,
                key => FormatWithFunctions.FromReplacementObject(key, replacementObject),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats the with.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(
            string formatString,
            Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            if (formatString.Length == 0)
            {
                return string.Empty;
            }

            if ((missingKeyBehavior == MissingKeyBehavior.ReplaceWithFallback) && (fallbackReplacementValue == null))
            {
                throw new NoFallbackException();
            }

            // get the parameters from the format string
            var tokens = FormatHelpers.Tokenize(formatString, openBraceChar, closeBraceChar);
            return FormatHelpers.ProcessTokens(
                tokens,
                handler,
                missingKeyBehavior,
                fallbackReplacementValue,
                formatString.Length * 2);
        }

        /// <summary>
        ///     Computes the formattable sting.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formattable string.</returns>
        public static FormattableString FormattableWith(
            string formatString,
            IDictionary<string, string> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            string fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                key => new ReplacementResult(replacements.TryGetValue(key, out var value), value),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Computes the formattable sting.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formattable string.</returns>
        public static FormattableString FormattableWith(
            string formatString,
            IDictionary<string, object> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                key => new ReplacementResult(replacements.TryGetValue(key, out var value), value),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Computes the formattable sting.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="replacementObject">The replacement object.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formattable string.</returns>
        public static FormattableString FormattableWith(
            string formatString,
            object replacementObject,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                key => FormatWithFunctions.FromReplacementObject(key, replacementObject),
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Computes the formattable sting.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="missingKeyBehavior">The missing key behavior.</param>
        /// <param name="fallbackReplacementValue">The fallback replacement value.</param>
        /// <param name="openBraceChar">The open brace character.</param>
        /// <param name="closeBraceChar">The close brace character.</param>
        /// <returns>The formattable string.</returns>
        public static FormattableString FormattableWith(
            string formatString,
            Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            // get the parameters from the format string
            var tokens = FormatHelpers.Tokenize(formatString, openBraceChar, closeBraceChar);
            return FormatHelpers.ProcessTokensIntoFormattableString(
                tokens,
                handler,
                missingKeyBehavior,
                fallbackReplacementValue,
                formatString.Length * 2);
        }

        /// <summary>
        ///     Gets an <see cref="IEnumerable{String}">IEnumerable&lt;string&gt;</see> that will return all format parameters used
        ///     within the format string.
        /// </summary>
        /// <param name="formatString">The format string to be parsed</param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The formatted parameters.</returns>
        public static IEnumerable<string> GetFormatParameters(
            string formatString,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar) =>
            FormatHelpers.Tokenize(formatString, openBraceChar, closeBraceChar)
                .Where(t => t.TokenType == TokenType.Parameter)
                .Select(pt => pt.Value);

        /// <summary>
        ///     From the replacement object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="replacementObject">The replacement object.</param>
        /// <returns>
        ///     The replacement result.
        /// </returns>
        private static ReplacementResult FromReplacementObject(string key, object replacementObject)
        {
            var propertyInfo = replacementObject.GetType().GetProperty(key, FormatWithFunctions.PropertyBindingFlags);
            return propertyInfo == null
                       ? new ReplacementResult(false, null)
                       : new ReplacementResult(true, propertyInfo.GetValue(replacementObject));
        }
    }
}