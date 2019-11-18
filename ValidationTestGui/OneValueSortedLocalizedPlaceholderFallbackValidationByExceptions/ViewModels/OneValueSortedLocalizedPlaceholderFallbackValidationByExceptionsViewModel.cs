// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedAndPlaceholderAndFallbackValidationByExceptionsViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedPlaceholderFallbackValidationByExceptions.
    ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Exceptions;
    using Bfa.Common.WPF.Localizations;

    /// <summary>
    /// The one value sorted localized placeholder fallback validation by exceptions view model
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel : Binders.Bindable,
                                                                                             INotifyDataErrorInfo,
                                                                                             IDisposable
    {
        /// <summary>
        ///     The value1
        /// </summary>
        private string value1;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel" /> class.
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel()
        {
            this.Validator =
                new ValidatorBuilder<OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel>().Build(
                    this);
            this.Validator.ValidationMessages.ErrorsChanged += this.ValidationMessagesOnErrorsChanged;
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <value>
        ///     The validator.
        /// </value>
        public Validator<OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel> Validator { get; }

        /// <summary>
        ///     Gets or sets the value1.
        /// </summary>
        /// <value>
        ///     The value1.
        /// </value>
        public string Value1
        {
            get => this.value1;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ValidationLocWarningException(
                        "Not Null Exception!",
                        new LanguageKey("NotNull", "Group1", "Source1"));
                }

                if (value.ToLower() == "warning")
                {
                    throw new ValidationLocWarningException(
                        "Validation Warning Exception!",
                        new LanguageKey("Warning", "Group1", "Source1"));
                }

                if (value.ToLower() == "error")
                {
                    throw new LocException(
                        "Validation Error Exception!",
                        new LanguageKey("Error", "Group1", "Source1"));
                }

                this.SetProperty(ref this.value1, value);
            }
        }

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.Validator.ValidationMessages.HasErrors;

        /// <summary>
        ///     Validations the messages on errors changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e) => this.OnErrorsChanged(e);

        /// <summary>
        ///     Gets the validation errors for a specified property or for the entire entity.
        /// </summary>
        /// <param name="propertyName">
        ///     The name of the property to retrieve validation errors for; or <see langword="null" /> or
        ///     <see cref="F:System.String.Empty" />, to retrieve entity-level errors.
        /// </param>
        /// <returns>
        ///     The validation errors for the property or entity.
        /// </returns>
        public IEnumerable GetErrors(string propertyName) => this.Validator.ValidationMessages.GetPropertyErrors(propertyName);

        /// <summary>
        ///     Raises the <see cref="E:ErrorsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) => this.ErrorsChanged?.Invoke(this, e);

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;
    }
}