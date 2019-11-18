// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndTextBindingAndObjectConverterBase.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;

    using Bfa.Common.FormatWith;
    using Bfa.Common.Strings;

    using JetBrains.Annotations;

    /// <summary>
    ///     Key Binding Converter
    /// </summary>
    /// <seealso cref="LocTextBindingExtensionConverterBase{TKeyBindingAndTextBindingConverter}" />
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal abstract class KeyBindingAndTextBindingAndObjectConverterBase : LocTextBindingExtensionConverter
    {
        [CanBeNull]
        private readonly string group;

        [CanBeNull]
        private readonly string source;

        private readonly bool useTextAsFallback;

        public KeyBindingAndTextBindingAndObjectConverterBase(
            [NotNull] DependencyObject targetObject,
            [CanBeNull] string source,
            [CanBeNull] string group,
            bool useTextAsFallback)
            : base(targetObject)
        {
            this.source = source;
            this.group = group;
            this.useTextAsFallback = useTextAsFallback;
        }

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
        protected override string Convert(object[] values, CultureInfo culture)
        {
            var count = values.Length;
            if (count != 3)
            {
                return null;
            }

            string formatter;

            if (TryGetKey(values[0], out var key))
            {
                if (!TryGetFullyQualifiedKey(this.source, this.group, key, out var fullyQualifiedKey))
                {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
                    if (!(values[1] is string text))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
                    {
                        return GetKeyAsString(key);
                    }

                    if (!this.useTextAsFallback || text.IsNullOrEmpty())
                    {
                        return GetKeyAsString(key);
                    }

                    formatter = text;
                }

                if (!this.TryGetFormatter(fullyQualifiedKey, out formatter))
                {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
                    if (!(values[1] is string text))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
                    {
                        return GetKeyAsString(key);
                    }

                    if (!this.useTextAsFallback || text.IsNullOrEmpty())
                    {
                        return GetKeyAsString(key);
                    }

                    formatter = text;
                }
            }
            else
            {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
                if (!(values[1] is string text))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
                {
                    return null;
                }

                if (!this.useTextAsFallback || text.IsNullOrEmpty())
                {
                    return null;
                }

                formatter = text;
            }

            var obj = values[2];
            if (obj is INotifyPropertyChanged notifyProperty)
            {
                this.UpdateNoticePropertyChanged(notifyProperty);

                try
                {
                    return this.FormatWithNotifyProperty(formatter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return formatter;
                }
            }

            try
            {
                return formatter.FormatWith(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return formatter;
            }
        }
    }
}