// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndObjectConverterBase.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Data;

    using Bfa.Common.FormatWith;

    using JetBrains.Annotations;

    /// <summary>
    ///     Key Binding And Object Converter Class
    /// </summary>
    /// <typeparam name="TKeyBindingAndObjectConverterBase">The type of the key binding and object converter base.</typeparam>
    /// <seealso cref="LocTextBindingExtensionConverterBase{TKeyBindingAndObjectConverterBase}" />
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal class
        KeyBindingAndObjectConverterBase<TKeyBindingAndObjectConverterBase> : LocTextBindingExtensionConverterBase<
            TKeyBindingAndObjectConverterBase>
        where TKeyBindingAndObjectConverterBase : IMultiValueConverter, new()
    {
        /// <summary>
        ///     Formats the with notify property.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        protected static string FormatWithNotifyProperty(string formatter, LocTextBindingExtension parameter)
        {
            return parameter.NotifyPropertyChanged != null
                       ? formatter.FormatWith(parameter.NotifyPropertyChanged)
                       : formatter;
        }

        /// <summary>
        ///     Updates the notice property changed.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameter">The parameter.</param>
        protected static void UpdateNoticePropertyChanged([CanBeNull] object value, LocTextBindingExtension parameter)
        {
            if (value == null)
            {
                parameter.UpdateNotifyPropertyChanged(null);
            }
            else if (value is INotifyPropertyChanged notifyPropertyChanged)
            {
                parameter.UpdateNotifyPropertyChanged(notifyPropertyChanged);
            }
        }

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
            if (!TryGetKey(values[0], out var key))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            if (!this.TryGetFullyQualifiedKey(key, parameter, out var fullyQualifiedKey))
            {
                return null;
            }

            if (!this.TryGetFormatter(fullyQualifiedKey, parameter, out var formatter))
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