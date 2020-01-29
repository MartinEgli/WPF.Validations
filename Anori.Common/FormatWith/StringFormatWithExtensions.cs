// -----------------------------------------------------------------------
// <copyright file="StringFormatWithExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Anori.Common.FormatWith.Internal;

    using JetBrains.Annotations;

    /// <summary>
    ///     The string extensions provided by FormatWith for string formatting.
    /// </summary>
    public static class StringFormatWithExtensions
    {
        /// <summary>
        ///     The open brace character
        /// </summary>
        [NotNull]
        internal const char OpenBraceChar = '{';

        /// <summary>
        ///     The close brace character
        /// </summary>
        [NotNull]
        internal const char CloseBraceChar = '}';

        /// <summary>
        ///     Gets an <see cref="IEnumerable{String}" /> that will return all format parameters used within the format string.
        /// </summary>
        /// <param name="formatString">The format string to be parsed</param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The formatted Parameters.</returns>
        [NotNull]
        public static IEnumerable<string> GetFormatParameters(
            [NotNull] this string formatString,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.GetFormatParameters(formatString, openBraceChar, closeBraceChar);
        }

        /// <summary>
        ///     Formats a string with the values given by the properties on an input object.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacementObject">The object whose properties should be injected in the string</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith([NotNull] this string formatString, [NotNull] object replacementObject)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException(nameof(formatString));
            }

            if (replacementObject == null)
            {
                throw new ArgumentNullException(nameof(replacementObject));
            }

            // wrap the type object in a wrapper Dictionary class that exposes the properties as dictionary keys via reflection
            return FormatWithFunctions.FormatWith(formatString, replacementObject);
        }

        /// <summary>
        /// Formats the with.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="text">The text.</param>
        /// <returns>The formatted string.</returns>
        /// <exception cref="ArgumentNullException">
        /// formatString
        /// or
        /// text
        /// </exception>
        [NotNull]
        public static string FormatWith([NotNull] this string formatString, [NotNull] string text)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException(nameof(formatString));
            }

            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return Strings.StringExtensions.FormatWith(formatString, text);
        }

        /// <summary>
        ///     Formats a string with the values given by the properties on an input object.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacementObject">The object whose properties should be injected in the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>
        ///     The formatted string
        /// </returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] object replacementObject,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            // wrap the type object in a wrapper Dictionary class that exposes the properties as dictionary keys via reflection
            return FormatWithFunctions.FormatWith(
                formatString,
                replacementObject,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats a string with the values of the dictionary.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, string> replacements)
        {
            // wrap the IDictionary<string, string> in a wrapper Dictionary class that casts the values to objects as needed
            return FormatWithFunctions.FormatWith(formatString, replacements);
        }

        /// <summary>
        ///     Formats a string with the values of the dictionary.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, string> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] string fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            // wrap the IDictionary<string, string> in a wrapper Dictionary class that casts the values to objects as needed
            return FormatWithFunctions.FormatWith(
                formatString,
                replacements,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats a string with the values of the dictionary.
        ///     The string representation of each object value in the dictionary is used as the format parameter.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, object> replacements)
        {
            return FormatWithFunctions.FormatWith(formatString, replacements);
        }

        /// <summary>
        ///     Formats a string with the values of the dictionary.
        ///     The string representation of each object value in the dictionary is used as the format parameter.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, object> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormatWith(
                formatString,
                replacements,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Formats a string, using a handler function to provide the value
        ///     of each parameter.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="handler">A handler function that transforms each parameter into a <see cref="ReplacementResult" /></param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] Func<string, ReplacementResult> handler)
        {
            return FormatWithFunctions.FormatWith(formatString, handler);
        }

        /// <summary>
        ///     Formats a string, using a handler function to provide the value
        ///     of each parameter.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="handler">A handler function that transforms each parameter into a <see cref="ReplacementResult" /></param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that cannot be
        ///     replaced by the handler
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this object is used as a fallback replacement value.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The formatted string</returns>
        [NotNull]
        public static string FormatWith(
            [NotNull] this string formatString,
            [NotNull] Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormatWith(
                formatString,
                handler,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacementObject">The object whose properties should be injected in the string</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] object replacementObject)
        {
            // wrap the type object in a wrapper Dictionary class that exposes the properties as dictionary keys via reflection
            return FormatWithFunctions.FormattableWith(formatString, replacementObject);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacementObject">The object whose properties should be injected in the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] object replacementObject,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                replacementObject,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, string> replacements)
        {
            // wrap the IDictionary<string, string> in a wrapper Dictionary class that casts the values to objects as needed
            return FormatWithFunctions.FormattableWith(formatString, replacements);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, string> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] string fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            // wrap the IDictionary<string, string> in a wrapper Dictionary class that casts the values to objects as needed
            return FormatWithFunctions.FormattableWith(
                formatString,
                replacements,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, object> replacements)
        {
            return FormatWithFunctions.FormattableWith(formatString, replacements);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="replacements">An <see cref="IDictionary" /> with keys and values to inject into the string</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present in
        ///     the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] IDictionary<string, object> replacements,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                replacements,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="handler">A handler function that transforms each parameter into a <see cref="ReplacementResult" /></param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] Func<string, ReplacementResult> handler)
        {
            return FormatWithFunctions.FormattableWith(formatString, handler);
        }

        /// <summary>
        ///     Produces a <see cref="FormattableString" /> representing the input format string.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="handler">A handler function that transforms each parameter into a <see cref="ReplacementResult" /></param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that cannot be
        ///     replaced by the handler
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this object is used as a fallback replacement value.
        /// </param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>The resultant <see cref="FormattableString" /></returns>
        [NotNull]
        public static FormattableString FormattableWith(
            [NotNull] this string formatString,
            [NotNull] Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior = MissingKeyBehavior.ThrowException,
            [CanBeNull] object fallbackReplacementValue = null,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            return FormatWithFunctions.FormattableWith(
                formatString,
                handler,
                missingKeyBehavior,
                fallbackReplacementValue,
                openBraceChar,
                closeBraceChar);
        }
    }
}