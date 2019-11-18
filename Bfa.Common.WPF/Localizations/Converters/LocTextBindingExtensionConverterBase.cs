// -----------------------------------------------------------------------
// <copyright file="LocTextBindingExtensionConverterBase.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Bfa.Common.Numerics;
    using Bfa.Common.Strings;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Extensions;
    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     Base class for  LocTextBindingExtension converters
    /// </summary>
    /// <typeparam name="TConverter">The type of the converter.</typeparam>
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal abstract class LocTextBindingExtensionConverterBase<TConverter> : IMultiValueConverter
        where TConverter : IMultiValueConverter, new()
    {
        /// <summary>
        ///     The key binding converter
        /// </summary>
        private static readonly Lazy<TConverter> Converter = new Lazy<TConverter>(() => new TConverter());

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static TConverter Instance => Converter.Value;

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
        /// <param name="targetType">The type of the binding target property.</param>
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
        /// <exception cref="ArgumentNullException">values</exception>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var count = values.Length;
            if (count < 1)
            {
                return null;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(parameter is LocTextBindingExtension p))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return null;
            }

            return this.Convert(values, p, culture);
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

        /// <summary>
        ///     Gets the formatter objects.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="offset">The offset of starting point of the formatter objects.</param>
        /// <returns>
        ///     The formatter objects
        /// </returns>
        /// <exception cref="ArgumentNullException">values is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     offset bigger or equal 0
        ///     or
        ///     offset >= length
        /// </exception>
        protected static object[] GetFormatterObjects([NotNull] object[] values, int offset)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (offset <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (offset >= values.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            var b = new object[values.Length - offset];
            Array.Copy(values, offset, b, 0, b.Length);
            return b;
        }

        /// <summary>
        ///     Gets the formatter objects.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>The object.</returns>
        /// <exception cref="ArgumentNullException">values are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     offset
        ///     or
        ///     offset
        /// </exception>
        protected static object[] GetFormatterObjects(
            [NotNull] object[] values,
            LocTextBindingExtension parameter,
            int offset)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (offset <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (offset > values.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            var b = new object[values.Length - offset];
            Array.Copy(values, offset, b, 0, b.Length);
            var s = new object[parameter.FormatSegmentCount];
            for (var i = 0; i < parameter.FormatSegmentCount; i++)
            {
                if (parameter.FormatSegmentBindingMap.Contains(i))
                {
                    s[i] = b[parameter.FormatSegmentBindingMap.IndexOf(i)];
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            s[i] = parameter.FormatSegment0;
                            break;

                        case 1:
                            s[i] = parameter.FormatSegment1;
                            break;

                        case 2:
                            s[i] = parameter.FormatSegment2;
                            break;

                        case 3:
                            s[i] = parameter.FormatSegment3;
                            break;

                        case 4:
                            s[i] = parameter.FormatSegment4;
                            break;
                    }
                }
            }

            return s;
        }

        /// <summary>
        ///     Gets the key as string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Teh Key as String.</returns>
        protected static string GetKeyAsString(string key) => "Key: " + key;

        /// <summary>
        ///     Tries the get key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     Is key.
        /// </returns>
        protected static bool TryGetKey(object value, out string key)
        {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(value is string s))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                if (!value.IsInteger())
                {
                    if (value is FullyQualifiedResourceKeyBase fqk)
                    {
                        key = fqk.ToString();
                        return !key.IsNullOrWhiteSpace();
                    }

                    key = string.Empty;
                    return false;
                }

                s = value.ToString();
            }

            key = s;
            return !key.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Converts the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The formatted string.</returns>
        protected abstract string Convert(
            object[] values,
            [NotNull] LocTextBindingExtension parameter,
            CultureInfo culture);

        /// <summary>
        ///     Gets the formatter.
        /// </summary>
        /// <param name="fullyQualifiedKey">The Fully Qualified Key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected virtual bool TryGetFormatter(
            string fullyQualifiedKey,
            LocTextBindingExtension parameter,
            out string formatter)
        {
            formatter = LocExtension.GetLocalizedValue<string>(fullyQualifiedKey, parameter.TargetObject);
            return !formatter.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Gets the formatter culture.
        /// </summary>
        /// <param name="fullyQualifiedKey">The fully qualified key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected bool TryGetFormatterCulture(
            string fullyQualifiedKey,
            LocTextBindingExtension parameter,
            out string formatter)
        {
            formatter = LocExtension.GetLocalizedValue<string>(
                fullyQualifiedKey,
                parameter.ForceCulture,
                parameter.TargetObject);
            return !formatter.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Gets the formatter culture.
        /// </summary>
        /// <param name="fullyQualifiedKey">The fully qualified key.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     Is formatter string.
        /// </returns>
        protected bool TryGetFormatterCulture(
            string fullyQualifiedKey,
            CultureInfo culture,
            LocTextBindingExtension parameter,
            out string formatter)
        {
            formatter = LocExtension.GetLocalizedValue<string>(fullyQualifiedKey, culture, parameter.TargetObject);
            return !formatter.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Gets the fully qualified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="fullyQualifiedKey">The fully qualified key.</param>
        /// <returns>
        ///     The Fully Qualified Key.
        /// </returns>
        protected virtual bool TryGetFullyQualifiedKey(
            string key,
            LocTextBindingExtension parameter,
            out string fullyQualifiedKey)
        {
            fullyQualifiedKey = LocalizationProviderHelpers.FullyQualifiedKey(parameter.Source, parameter.Group, key);
            return !fullyQualifiedKey.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Tries the get fully qualified key.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="fullyQualifiedKey">The fully qualified key.</param>
        /// <returns>
        ///     The Fully Qualified Key.
        /// </returns>
        protected virtual bool TryGetFullyQualifiedKey(
            string source,
            string group,
            string key,
            out string fullyQualifiedKey)
        {
            fullyQualifiedKey = LocalizationProviderHelpers.FullyQualifiedKey(source, group, key);
            return !fullyQualifiedKey.IsNullOrWhiteSpace();
        }
    }
}