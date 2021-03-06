// -----------------------------------------------------------------------
// <copyright file="TextBindingConverterBase.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Anori.Common.Strings;

    /// <summary>
    /// Key Binding Converter
    /// </summary>
    /// <typeparam name="TTextBindingConverter">The type of the text binding converter.</typeparam>
    /// <seealso cref="Anori.Common.WPF.Localizations.Converters.LocTextBindingExtensionConverterBase{TTextBindingConverter}" />
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal class
        TextBindingConverterBase<TTextBindingConverter> : LocTextBindingExtensionConverterBase<TTextBindingConverter>
        where TTextBindingConverter : IMultiValueConverter, new()
    {
        /// <summary>
        ///     Converts source values to a value for the binding target. The data binding engine calls this method when it
        ///     propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">
        ///     The array of values that the source bindings in the
        ///     <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value
        ///     <see cref="F:System.Windows.TargetProperty.UnsetValue" /> indicates that the source binding has no value to provide
        ///     for conversion.
        /// </param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value.If the method returns <see langword="null" />, the valid <see langword="null" /> value is used.A
        ///     return value of <see cref="T:System.Windows.TargetProperty" />.
        ///     <see cref="F:System.Windows.TargetProperty.UnsetValue" /> indicates that the converter did not produce a value, and
        ///     that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is available, or
        ///     else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding" />.
        ///     <see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or
        ///     use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
        /// </returns>
        protected override string Convert(object[] values, LocTextBindingExtension parameter, CultureInfo culture)
        {
            var count = values.Length;
            if (count < 1)
            {
                return null;
            }

            string formatter;

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(values[0] is string text))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            if (text.IsNullOrEmpty())
            {
                return null;
            }

            formatter = text;

            if (count == 1)
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