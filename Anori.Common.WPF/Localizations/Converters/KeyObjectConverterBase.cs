// -----------------------------------------------------------------------
// <copyright file="KeyObjectConverterBase.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    ///     The Key Object Converter Class
    /// </summary>
    /// <typeparam name="TKeyObjectConverter">The type of the key object converter.</typeparam>
    /// <seealso cref="Anori.Common.WPF.Localizations.Converters.KeyBindingAndObjectConverterBase{TKeyObjectConverter}" />
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal class KeyObjectConverterBase<TKeyObjectConverter> : KeyBindingAndObjectConverterBase<TKeyObjectConverter>
        where TKeyObjectConverter : IMultiValueConverter, new()
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
            if (values.Length < 1)
            {
                return null;
            }

            var key = parameter.Key;

            if (!this.TryGetFullyQualifiedKey(key, parameter, out var fullyQualifiedKey))
            {
                return GetKeyAsString(key);
            }

            if (!this.TryGetFormatter(fullyQualifiedKey, parameter, out var formatter))
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