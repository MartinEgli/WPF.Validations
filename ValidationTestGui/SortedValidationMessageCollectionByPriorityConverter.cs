// -----------------------------------------------------------------------
// <copyright file="SortedValidationMessageCollectionByPriorityConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    using Anori.Common.Collections;
    using Anori.Common.Validations.Markers;
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    /// </summary>
    /// <seealso cref="System.Windows.Markup.MarkupExtension" />
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class SortedValidationMessageCollectionByPriorityConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        ///     The instance
        /// </summary>
        private static readonly Lazy<IValueConverter> Instance =
            new Lazy<IValueConverter>(() => new SortedValidationMessageCollectionByPriorityConverter());

        /// <summary>
        ///     When implemented in a derived class, returns an object that is provided as the value of the target property for
        ///     this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>
        ///     The object value to set on the property where the extension is applied.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance.Value;
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ReadOnlyObservableCollection<IValidationMessage> list))
            {
                return value;
            }

            var sorted = new SortedObservableCollection<int, IValidationMessage>(
                message => ((message is IWarning) ? 1 : 0));
            ((INotifyCollectionChanged)list).CollectionChanged +=
                (sender, args) => this.OnCollectionChanged(args, sorted);

            //CollectionChangedEventManager.AddHler(
            //    list,
            //    (sender, args) => this.OnCollectionChanged(sender, args, sorted));

            foreach (var item in list)
            {
                sorted.Add(item);
            }

            return sorted;
        }

        /// <summary>
        ///     Called when [collection changed].
        /// </summary>
        /// <param name="args">The <see cref="NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
        /// <param name="sorted">The sorted.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args, IList<IValidationMessage> sorted)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (IValidationMessage item in args.NewItems)
                    {
                        sorted.Insert(0, item);
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:

                    foreach (IValidationMessage item in args.OldItems)
                    {
                        sorted.Remove(item);
                    }

                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (IValidationMessage item in args.OldItems)
                    {
                        sorted.Remove(item);
                    }

                    foreach (IValidationMessage item in args.NewItems)
                    {
                        sorted.Insert(0, item);
                    }

                    break;

                case NotifyCollectionChangedAction.Move:
                    break;

                case NotifyCollectionChangedAction.Reset:
                    sorted.Clear();
                    foreach (IValidationMessage item in args.NewItems)
                    {
                        sorted.Add(item);
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}