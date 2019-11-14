// -----------------------------------------------------------------------
// <copyright file="LocalizedValidationErrorContentTemplateSelector.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using Bfa.Common.Validations.Markers;
    using Bfa.Common.Validations.Validators.Interfaces;

    /// <summary>
    ///     ValidationErrorTemplateSelector class.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    public class LocalizedValidationErrorContentTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        ///     Gets or sets the validation warning template.
        /// </summary>
        /// <value>
        ///     The validation warning template.
        /// </value>
        public DataTemplate ValidationWarningTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the located validation warning template.
        /// </summary>
        /// <value>
        ///     The located validation warning template.
        /// </value>
        public DataTemplate LocatedValidationWarningTemplate { get; set; }

        /// <summary>
        ///     Gets or sets the located validation error template.
        /// </summary>
        /// <value>
        ///     The located validation error template.
        /// </value>
        public DataTemplate LocatedValidationErrorTemplate { get; set; }

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
            switch (item)
            {
                case ValidationError validationError when validationError.ErrorContent is IWarning:
                    {
                        if (validationError.ErrorContent is ILocalizationTextKeyAware)

                        {
                            return this.LocatedValidationWarningTemplate;
                        }

                        return this.ValidationWarningTemplate;
                    }
                case ValidationError validationError:
                    {
                        switch (validationError.Exception)
                        {
                            case WarningException _:
                                {
                                    if (validationError.Exception is ILocalizationTextKeyAware)

                                    {
                                        return this.LocatedValidationWarningTemplate;
                                    }

                                    return this.ValidationWarningTemplate;
                                }

                            case IWarning _:
                                {
                                    if (validationError.Exception is ILocalizationTextKeyAware)

                                    {
                                        return this.LocatedValidationWarningTemplate;
                                    }

                                    return this.ValidationWarningTemplate;
                                }
                        }

                        if (validationError.ErrorContent is ILocalizationTextKeyAware)

                        {
                            return this.LocatedValidationErrorTemplate;
                        }

                        if (validationError.Exception is ILocalizationTextKeyAware)

                        {
                            return this.LocatedValidationErrorTemplate;
                        }

                        return this.ValidationErrorTemplate;
                    }
                default:
                    return this.ValidationErrorTemplate ?? base.SelectTemplate(item, container);
            }
        }
    }
}