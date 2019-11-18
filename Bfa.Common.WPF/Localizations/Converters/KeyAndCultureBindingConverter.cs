// -----------------------------------------------------------------------
// <copyright file="KeyAndCultureBindingConverter.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;

    using Bfa.Common.Strings;

    /// <summary>
    ///     Key Binding And Culture Binding Converter
    /// </summary>
    /// <seealso cref="LocTextBindingExtensionConverterBase{KeyBindingAndCultureBindingConverter}" />
    internal class KeyAndCultureBindingConverter : LocTextBindingExtensionConverterBase<KeyAndCultureBindingConverter>
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
            if (!(values[0] is CultureInfo forceCulture))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            if (!this.TryGetFullyQualifiedKey(key, parameter, out var fullyQualifiedKey))
            {
                return GetKeyAsString(key);
            }

            if (!this.TryGetFormatterCulture(fullyQualifiedKey, forceCulture, parameter, out var formatter))
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