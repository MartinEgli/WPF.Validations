// -----------------------------------------------------------------------
// <copyright file="ValidationErrorsToSolidBrushConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Windows.Media;

    using Anori.Common.Validations.Markers;

    public class ValidationErrorsToSolidBrushConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        ///     The brush
        /// </summary>
        private readonly SolidColorBrush brush;

        /// <summary>
        ///     The notify collection changed
        /// </summary>
        private INotifyCollectionChanged notifyCollectionChanged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationErrorsToSolidBrushConverter" /> class.
        /// </summary>
        public ValidationErrorsToSolidBrushConverter(Color errorColor, Color warningColor)
        {
            this.ErrorColor = errorColor;
            this.WarningColor = warningColor;
            this.brush = new SolidColorBrush();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationErrorsToSolidBrushConverter" /> class.
        /// </summary>
        public ValidationErrorsToSolidBrushConverter()
        {
            this.brush = new SolidColorBrush();
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="ValidationErrorsToSolidBrushConverter" /> class.
        /// </summary>
        ~ValidationErrorsToSolidBrushConverter()
        {
            var collectionChanged = this.notifyCollectionChanged;
            if (collectionChanged != null)
            {
                collectionChanged.CollectionChanged -= this.OnCollectionChanged;
            }
        }

        /// <summary>
        ///     Gets or sets the color of the error.
        /// </summary>
        /// <value>
        ///     The color of the error.
        /// </value>
        public Color ErrorColor { get; set; } = Colors.Red;

        /// <summary>
        ///     Gets or sets the color of the warning.
        /// </summary>
        /// <value>
        ///     The color of the warning.
        /// </value>
        public Color WarningColor { get; set; } = Colors.Orange;

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
            return new ValidationErrorsToSolidBrushConverter(this.ErrorColor, this.WarningColor);
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is System.Collections.ObjectModel.ReadOnlyObservableCollection<ValidationError> list))
            {
                this.brush.Color = this.ErrorColor;
                return this.brush;
            }

            this.notifyCollectionChanged = list;
            this.notifyCollectionChanged.CollectionChanged += this.OnCollectionChanged;

            if (list.Any(i => i.ErrorContent is IError))
            {
                this.brush.Color = this.ErrorColor;
                return this.brush;
            }

            if (list.Any(i => i.ErrorContent is IWarning))
            {
                this.brush.Color = this.WarningColor;
                return this.brush;
            }

            if (list.Any(i => i.Exception != null && (i.Exception is IWarning || i.Exception is WarningException)))
            {
                this.brush.Color = this.WarningColor;
                return this.brush;
            }

            if (list.Any(i => i.Exception != null))
            {
                this.brush.Color = this.ErrorColor;
                return this.brush;
            }

            this.brush.Color = this.ErrorColor;
            return this.brush;
        }

        /// <summary>
        ///     Called when [collection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!(sender is System.Collections.ObjectModel.ReadOnlyObservableCollection<ValidationError> list))
            {
                this.brush.Color = this.ErrorColor;
            }
            else if (list.Any(i => i.ErrorContent is IError))
            {
                this.brush.Color = this.ErrorColor;
            }
            else if (list.Any(i => i.ErrorContent is IWarning))
            {
                this.brush.Color = this.WarningColor;
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
        ///     A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}