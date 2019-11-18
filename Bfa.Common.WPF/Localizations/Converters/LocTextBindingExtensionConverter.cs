// -----------------------------------------------------------------------
// <copyright file="LocTextBindingExtensionConverter.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations.Converters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
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
    internal abstract class LocTextBindingExtensionConverter : IMultiValueConverter
    {
        private readonly DependencyObject TargetObject;

        /// <summary>
        ///     The update look
        /// </summary>
        private readonly object updateLook = new object();

        private CultureInfo ForceCulture;

        private string FormatSegment0;

        private string FormatSegment1;

        private string FormatSegment2;

        private string FormatSegment3;

        private string FormatSegment4;

        private List<int> FormatSegmentBindingMap;

        private int FormatSegmentCount;

        private INotifyPropertyChanged NotifyPropertyChanged;

        protected LocTextBindingExtensionConverter([NotNull] DependencyObject targetObject)
        {
            this.TargetObject = targetObject ?? throw new ArgumentNullException(nameof(targetObject));
        }

        public MultiBindingExpression Expression { get; set; }

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

            return this.Convert(values, culture);
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

        ///// <summary>
        /////     Gets the formatter objects.
        ///// </summary>
        ///// <param name="values">The values.</param>
        ///// <param name="offset">The offset of starting point of the formatter objects.</param>
        ///// <returns>
        /////     The formatter objects
        ///// </returns>
        ///// <exception cref="ArgumentNullException">values is null.</exception>
        ///// <exception cref="ArgumentOutOfRangeException">
        /////     offset bigger or equal 0
        /////     or
        /////     offset >= length
        ///// </exception>
        //protected static object[] GetFormatterObjects([NotNull] object[] values, int offset)
        //{
        //    if (values == null)
        //    {
        //        throw new ArgumentNullException(nameof(values));
        //    }

        //    if (offset <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(offset));
        //    }

        //    if (offset >= values.Length)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(offset));
        //    }

        //    var b = new object[values.Length - offset];
        //    Array.Copy(values, offset, b, 0, b.Length);
        //    return b;
        //}

        /// <summary>
        ///     Gets the formatter objects.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>The object.</returns>
        /// <exception cref="ArgumentNullException">values are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     offset
        ///     or
        ///     offset
        /// </exception>
        protected object[] GetFormatterObjects([NotNull] object[] values, int offset)
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
            var s = new object[this.FormatSegmentCount];
            for (var i = 0; i < this.FormatSegmentCount; i++)
            {
                if (this.FormatSegmentBindingMap.Contains(i))
                {
                    s[i] = b[this.FormatSegmentBindingMap.IndexOf(i)];
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            s[i] = this.FormatSegment0;
                            break;

                        case 1:
                            s[i] = this.FormatSegment1;
                            break;

                        case 2:
                            s[i] = this.FormatSegment2;
                            break;

                        case 3:
                            s[i] = this.FormatSegment3;
                            break;

                        case 4:
                            s[i] = this.FormatSegment4;
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
        /// <param name="culture">The culture.</param>
        /// <returns>The formatted string.</returns>
        protected abstract string Convert(object[] values, CultureInfo culture);

        /// <summary>
        ///     Gets the formatter.
        /// </summary>
        /// <param name="fullyQualifiedKey">The Fully Qualified Key.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected virtual bool TryGetFormatter(string fullyQualifiedKey, out string formatter)
        {
            formatter = LocExtension.GetLocalizedValue<string>(fullyQualifiedKey, this.TargetObject);
            return !formatter.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Gets the formatter culture.
        /// </summary>
        /// <param name="fullyQualifiedKey">The fully qualified key.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected bool TryGetFormatterCulture(string fullyQualifiedKey, CultureInfo forceCulture, out string formatter)
        {
            formatter = LocExtension.GetLocalizedValue<string>(fullyQualifiedKey, forceCulture, this.TargetObject);
            return !formatter.IsNullOrWhiteSpace();
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
        protected static bool TryGetFullyQualifiedKey(
            string source,
            string group,
            string key,
            out string fullyQualifiedKey)
        {
            fullyQualifiedKey = LocalizationProviderHelpers.FullyQualifiedKey(source, group, key);
            return !fullyQualifiedKey.IsNullOrWhiteSpace();
        }

        /// <summary>
        ///     Updates the notify property changed.
        /// </summary>
        /// <param name="notifyPropertyChanged">The notify property changed.</param>
        private void UpdateNotifyPropertyChanged(INotifyPropertyChanged notifyPropertyChanged)
        {
            lock (this.updateLook)
            {
                if (!Equals(notifyPropertyChanged, this.NotifyPropertyChanged))
                {
                    if (this.NotifyPropertyChanged != null)
                    {
                        this.NotifyPropertyChanged.PropertyChanged -= this.UpdateTargetOnPropertyChanged;
                    }

                    this.NotifyPropertyChanged = notifyPropertyChanged;

                    if (this.NotifyPropertyChanged != null)
                    {
                        this.NotifyPropertyChanged.PropertyChanged += this.UpdateTargetOnPropertyChanged;
                    }
                }
            }
        }

        /// <summary>
        ///     Updates the target on property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void UpdateTargetOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.Expression == null)
            {
                return;
            }

            lock (this.updateLook)

            {
                this.Expression.UpdateTarget();
                //foreach (var bindingExpressionBindingExpression in this.Expression.BindingExpressions)
                //{
                //    bindingExpressionBindingExpression.Target.Dispatcher?.Invoke(
                //        () => bindingExpressionBindingExpression.UpdateTarget());
                //}
            }
        }

        /// <summary>
        ///     Formats the with notify property.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatted string.
        /// </returns>
        protected string FormatWithNotifyProperty(string formatter)
        {
            return this.NotifyPropertyChanged != null ? formatter.FormatWith(this.NotifyPropertyChanged) : formatter;
        }

        /// <summary>
        ///     Updates the notice property changed.
        /// </summary>
        /// <param name="value">The value.</param>
        protected void UpdateNoticePropertyChanged([CanBeNull] object value)
        {
            if (value == null)
            {
                this.UpdateNotifyPropertyChanged(null);
            }
            else if (value is INotifyPropertyChanged notifyPropertyChanged)
            {
                this.UpdateNotifyPropertyChanged(notifyPropertyChanged);
            }
        }
    }
}