// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndObjectAndCultureBindingConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;

    /// <summary>
    ///     The Key Binding Object And Culture Converter Class
    /// </summary>
    /// <seealso cref="KeyBindingAndObjectConverterBase{KeyBindingObjectAndCultureConverter}" />
    internal class
        KeyBindingAndObjectAndCultureBindingConverter : KeyBindingAndObjectConverterBase<
            KeyBindingAndObjectAndCultureBindingConverter>
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
            if (count < 3)
            {
                return null;
            }

            if (!TryGetKey(values[0], out var key))
            {
                return null;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(values[2] is CultureInfo forceCulture))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            if (!this.TryGetFullyQualifiedKey(key, parameter, out var fullyQualifiedKey))
            {
                return null;
            }

            if (!this.TryGetFormatterCulture(fullyQualifiedKey, forceCulture, parameter, out var formatter))
            {
                return GetKeyAsString(key);
            }

            UpdateNoticePropertyChanged(values[1], parameter);

            try
            {
                return FormatWithNotifyProperty(formatter, parameter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return formatter;
            }
        }
    }
}