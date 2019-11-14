// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndCultureBindingConverter.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;

    /// <summary>
    ///     Key Binding And Culture Binding Converter
    /// </summary>
    /// <seealso cref="LocTextBindingExtensionConverterBase{KeyBindingAndCultureBindingConverter}" />
    internal class
        KeyBindingAndCultureBindingConverter : LocTextBindingExtensionConverterBase<KeyBindingAndCultureBindingConverter
        >
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
            if (count < 2)
            {
                return null;
            }

            if (!TryGetKey(values[0], out var key))
            {
                return null;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(values[1] is CultureInfo forceCulture))
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

            if (count == 2)
            {
                return formatter;
            }

            try
            {
                return string.Format(formatter, GetFormatterObjects(values, 2));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return formatter;
            }
        }
    }
}