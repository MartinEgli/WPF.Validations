// -----------------------------------------------------------------------
// <copyright file="LocalizedValidationMessagesTemplateSelector.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System.Windows;
    using System.Windows.Controls;

    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;
    using Bfa.Common.Validations.Validators.Interfaces;

    /// <summary>
    /// The localized validation messages template selector
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    public class LocalizedValidationMessagesTemplateSelector : DataTemplateSelector
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
        public DataTemplate ValidationErrorTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the located validation warning template.
        /// </summary>
        /// <value>
        ///     The located validation warning template.
        /// </value>
        public DataTemplate LocalizedValidationWarningTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the located validation error template.
        /// </summary>
        /// <value>
        ///     The located validation error template.
        /// </value>
        public DataTemplate LocalizedValidationErrorTemplate { get; set; }

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
            switch (item)
            {
                case IValidationWarning warning when warning is ILocalizationTextKeyAware:
                    return this.LocalizedValidationWarningTemplate;

                case IValidationWarning _:
                    return this.ValidationWarningTemplate;

                case ILocalizationTextKeyAware _:
                    return this.LocalizedValidationErrorTemplate;

                default:
                    return this.ValidationErrorTemplate;
            }
        }
    }
}