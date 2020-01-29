// -----------------------------------------------------------------------
// <copyright file="KeyConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Extensions;

    /// <summary>
    ///     Key Converter
    /// </summary>
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal class KeyConverter : IMultiValueConverter
    {
        /// <summary>
        ///     Converts source values to a value for the binding target. The data binding engine calls this method when it
        ///     propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">
        ///     The array of values that the source bindings in the
        ///     <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value
        ///     <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to
        ///     provide for conversion.
        /// </param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value.If the method returns <see langword="null" />, the valid <see langword="null" /> value is used.A
        ///     return value of <see cref="T:System.Windows.DependencyProperty" />.
        ///     <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the converter did not produce a value,
        ///     and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is
        ///     available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding" />.
        ///     <see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or
        ///     use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     values
        ///     or
        ///     parameter
        ///     or
        ///     parameter
        ///     or
        ///     parameter
        /// </exception>
        public object Convert(
            [NotNull] object[] values,
            Type targetType,
            [NotNull] object parameter,
            CultureInfo culture)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(parameter is LocTextBindingExtension locTextBindingExtension))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            if (locTextBindingExtension.Formatter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            var formatter = LocExtension.GetLocalizedValue<string>(
                locTextBindingExtension.Key,
                locTextBindingExtension.TargetObject);

            if (locTextBindingExtension.UseDefaultIsEmpty)
            {
                if (string.IsNullOrEmpty(formatter))
                {
                    return locTextBindingExtension.Text;
                }
            }

            if (values.Length == 0)
            {
                return formatter;
            }

            try
            {
                return string.Format(formatter, values);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return formatter;
            }
        }

        /// <summary>
        ///     Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">
        ///     The array of types to convert to. The array length indicates the number and types of values
        ///     that are suggested for the method to return.
        /// </param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     An array of values that have been converted from the target value back to the source values.
        /// </returns>
        /// <exception cref="NotImplementedException">Not implemented.</exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}