// -----------------------------------------------------------------------
// <copyright file="OneValueSortedValidationByExceptionsViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Exceptions;

    /// <summary>
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class OneValueSortedValidationByExceptionsViewModel : Binders.Bindable, INotifyDataErrorInfo, IDisposable
    {
        /// <summary>
        ///     The value1
        /// </summary>
        private string value1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OneValueSortedValidationByExceptionsViewModel" /> class.
        /// </summary>
        public OneValueSortedValidationByExceptionsViewModel()
        {
            this.Validator = new ValidatorBuilder<OneValueSortedValidationByExceptionsViewModel>().Build(this);
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
        public Validator<OneValueSortedValidationByExceptionsViewModel> Validator { get; }

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
                    throw new WarningException("Not Null Exception!");
                }

                if (value.ToLower() == "warning")
                {
                    throw new ValidationWarningException("Validation Warning Exception!");
                }

                if (value.ToLower() == "error")
                {
                    throw new Exception("Validation Error Exception!");
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
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            this.OnErrorsChanged(e);
        }

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
        public IEnumerable GetErrors(string propertyName)
        {
            return this.Validator.ValidationMessages.GetPropertyErrors(propertyName);
        }

        /// <summary>
        ///     Raises the <see cref="E:ErrorsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            this.ErrorsChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;
        }
    }
}