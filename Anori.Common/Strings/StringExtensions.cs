// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Strings
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     General String Extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Determines whether [is null or empty].
        /// </summary>
        /// <param name="s">
        ///     The s.
        /// </param>
        /// <returns>
        ///     <c>true</c> if [is null or empty] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty([CanBeNull] this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        ///     Determines whether [is null or white space].
        /// </summary>
        /// <param name="s">
        ///     The s.
        /// </param>
        /// <returns>
        ///     <c>true</c> if [is null or white space] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace([CanBeNull] this string s) => string.IsNullOrWhiteSpace(s);

        /// <summary>
        ///     Formats the specified arguments.
        /// </summary>
        /// <param name="format">
        ///     The format.
        /// </param>
        /// <param name="args">
        ///     The arguments.
        /// </param>
        /// <returns>
        ///     The format string.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     format is null.
        /// </exception>
        public static string FormatWith([NotNull] this string format, [NotNull] [ItemNotNull] params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            return string.Format(format, args);
        }

        /// <summary>
        ///     Formats the with.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///     The format string.
        /// </returns>
        /// <exception cref="ArgumentNullException">format is null.</exception>
        public static string FormatWith([NotNull] this string format, [NotNull] [ItemNotNull] params string[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            return string.Format(format, args);
        }
    }
}