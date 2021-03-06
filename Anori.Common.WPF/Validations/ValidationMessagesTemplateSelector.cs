// -----------------------------------------------------------------------
// <copyright file="ValidationMessagesTemplateSelector.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations
{
    using System.Windows;
    using System.Windows.Controls;

    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    ///     ValidationErrorTemplateSelector class.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    public class ValidationMessagesTemplateSelector : DataTemplateSelector
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
            if (item is IValidationWarning)
            {
                return this.ValidationWarningTemplate;
            }

            return this.DefaultTemplate ?? base.SelectTemplate(item, container);
        }
    }
}