// -----------------------------------------------------------------------
// <copyright file="KeyAndGroupBindingConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;

    using Anori.Common.Strings;

    /// <summary>
    ///     The Key and GroupBinding converter class
    /// </summary>
    /// <seealso cref="LocTextBindingExtensionConverterBase{KeyAndGroupBindingConverter}" />
    internal class KeyAndGroupBindingConverter : LocTextBindingExtensionConverterBase<KeyAndGroupBindingConverter>
    {
        /// <summary>
        ///     Converts the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        protected override string Convert(object[] values, LocTextBindingExtension parameter, CultureInfo culture)
        {
            var count = values.Length;
            if (count < 1)
            {
                return null;
            }

            var key = parameter.Key;
            if (key.IsNullOrWhiteSpace())
            {
                return null;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!TryGetKey(values[0], out var group))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            if (!this.TryGetFullyQualifiedKey(parameter.Source, group, key, out var fullyQualifiedKey))
            {
                return GetKeyAsString(key);
            }

            if (!this.TryGetFormatter(fullyQualifiedKey, parameter, out var formatter))
            {
                return GetKeyAsString(key);
            }

            if (count == 1)
            {
                return formatter;
            }

            try
            {
                return string.Format(formatter, GetFormatterObjects(values, 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return formatter;
            }
        }
    }
}