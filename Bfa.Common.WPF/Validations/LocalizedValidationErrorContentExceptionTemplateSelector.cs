// -----------------------------------------------------------------------
// <copyright file="LocatedValidationErrorTemplateSelector.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using Bfa.Common.Validations.Markers;
    using Bfa.Common.Validations.Validators.Interfaces;

    /// <summary>
    /// ValidationErrorTemplateSelector class.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    public class LocalizedValidationErrorContentExceptionTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        ///     Gets or sets the validation warning template.
        /// </summary>
        /// <value>
        ///     The validation warning template.
        /// </value>
        public DataTemplate ValidationWarningTemplate { get; set; }

        /// <summary>
        /// Gets or sets the located validation warning template.
        /// </summary>
        /// <value>
        /// The located validation warning template.
        /// </value>
        public DataTemplate LocatedValidationWarningTemplate { get; set; }

        /// <summary>
        /// Gets or sets the located validation error template.
        /// </summary>
        /// <value>
        /// The located validation error template.
        /// </value>
        public DataTemplate LocatedValidationErrorTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the default template.
        /// </summary>
        /// <value>
        ///     The default template.
        /// </value>
        public DataTemplate ValidationErrorExceptionTemplate { get; set; }

        /// <summary>
        /// Gets or sets the validation warning exception template.
        /// </summary>
        /// <value>
        /// The validation warning exception template.
        /// </value>
        public DataTemplate ValidationWarningExceptionTemplate { get; set; }

        /// <summary>
        /// Gets or sets the located validation warning exception template.
        /// </summary>
        /// <value>
        /// The located validation warning exception template.
        /// </value>
        public DataTemplate LocatedValidationWarningExceptionTemplate { get; set; }

        /// <summary>
        /// Gets or sets the located validation error exception template.
        /// </summary>
        /// <value>
        /// The located validation error exception template.
        /// </value>
        public DataTemplate LocatedValidationErrorExceptionTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the default template.
        /// </summary>
        /// <value>
        ///     The default template.
        /// </value>
        public DataTemplate ValidationErrorTemplate { get; set; }

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
                if (validationError.ErrorContent is IWarning)
                {
                    if (validationError.ErrorContent is ILocalizationTextKeyAware)

                    {
                        return this.LocatedValidationWarningTemplate;
                    }

                    return this.ValidationWarningTemplate;
                }

                switch (validationError.Exception)
                {
                    case WarningException _:
                        {
                            if (validationError.Exception is ILocalizationTextKeyAware)

                            {
                                return this.LocatedValidationWarningExceptionTemplate;
                            }

                            return this.ValidationWarningExceptionTemplate;
                        }

                    case IWarning _:
                        {
                            if (validationError.Exception is ILocalizationTextKeyAware)

                            {
                                return this.LocatedValidationWarningExceptionTemplate;
                            }

                            return this.ValidationWarningExceptionTemplate;
                        }
                    case Exception _:
                        {
                            if (validationError.Exception is ILocalizationTextKeyAware)

                            {
                                return this.LocatedValidationErrorExceptionTemplate;
                            }

                            return this.ValidationErrorExceptionTemplate;
                        }
                }

                if (validationError.ErrorContent is ILocalizationTextKeyAware)

                {
                    return this.LocatedValidationErrorTemplate;
                }

                if (validationError.Exception is ILocalizationTextKeyAware)

                {
                    return this.LocatedValidationErrorExceptionTemplate;
                }

                return this.ValidationErrorTemplate;
            }

            return this.ValidationErrorTemplate ?? base.SelectTemplate(item, container);
        }
    }
}