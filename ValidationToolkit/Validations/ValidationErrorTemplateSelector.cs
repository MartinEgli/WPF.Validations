// -----------------------------------------------------------------------
// <copyright file="ValidationErrorTemplateSelector.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ValidationToolkit.Common
{
    using System.Windows;
    using System.Windows.Controls;

    using Bfa.Common.Validations;

    using ValidationError = System.Windows.Controls.ValidationError;

    public class ValidationErrorTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        ///     Gets or sets the validation warning template.
        /// </summary>
        /// <value>
        ///     The validation warning template.
        /// </value>
        public DataTemplate ValidationWarningTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the default template.
        /// </summary>
        /// <value>
        ///     The default template.
        /// </value>
        public DataTemplate DefaultTemplate { get; set; }

        /// <summary>
        ///     When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate" /> based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>
        ///     Returns a <see cref="T:System.Windows.DataTemplate" /> or null. The default value is null.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ValidationError validationError)
            {
                if (validationError.ErrorContent is IValidationWarning)
                {
                    return this.ValidationWarningTemplate;
                }
            }

            if (this.DefaultTemplate != null)
            {
                return this.DefaultTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}