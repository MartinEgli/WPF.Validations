// -----------------------------------------------------------------------
// <copyright file="KeyObjectAndCultureBindingConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;

    /// <summary>
    ///     The KeyObjectAndCultureBindingConverter  class
    /// </summary>
    /// <seealso cref="KeyObjectConverterBase{KeyObjectAndCultureBindingConverter}" />
    internal class KeyObjectAndCultureBindingConverter : KeyObjectConverterBase<KeyObjectAndCultureBindingConverter>
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
            if (values.Length < 2)
            {
                return null;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(values[1] is CultureInfo forceCulture))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            var key = parameter.Key;

            if (!this.TryGetFullyQualifiedKey(key, parameter, out var fullyQualifiedKey))
            {
                return GetKeyAsString(key);
            }

            if (!this.TryGetFormatterCulture(fullyQualifiedKey, forceCulture, parameter, out var formatter))
            {
                return GetKeyAsString(key);
            }

            UpdateNoticePropertyChanged(values[0], parameter);

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