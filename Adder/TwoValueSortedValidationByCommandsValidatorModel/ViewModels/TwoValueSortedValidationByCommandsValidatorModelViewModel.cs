// -----------------------------------------------------------------------
// <copyright file="TwoValueSortedValidationByCommandsAndValidatorViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;
    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.Models;

    using JetBrains.Annotations;

    /// <summary>
    /// The two value sorted validation by commands validator view model
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.Rules.IComparerTwoValues" />
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class TwoValueSortedValidationByCommandsValidatorModelViewModel : Binders.Bindable,
                                                                             INotifyDataErrorInfo,
                                                                             IDisposable,
                                                                             IComparerTwoValues
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TwoValueSortedValidationByCommandsValidatorModelViewModel" /> class.
        /// </summary>
        public TwoValueSortedValidationByCommandsValidatorModelViewModel(
            [NotNull] TwoValueSortedValidationByCommandsValidatorModelModel model,
            [NotNull] Validator<TwoValueSortedValidationByCommandsValidatorModelModel> validator)
        {
            this.Validator = validator ?? throw new ArgumentNullException(nameof(validator));
            validator.ValidationMessages.ErrorsChanged += this.ValidationMessagesOnErrorsChanged;

            this.Model = model ?? throw new ArgumentNullException(nameof(model));
            model.PropertyChanged += this.OnModelPropertyChanged;
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.Validator.ValidationMessages.HasErrors;

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public TwoValueSortedValidationByCommandsValidatorModelModel Model { get; }

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <value>
        ///     The validator.
        /// </value>
        [NotNull]
        public Validator<TwoValueSortedValidationByCommandsValidatorModelModel> Validator { get; }

        /// <summary>
        ///     Gets or sets the value1.
        /// </summary>
        /// <value>
        ///     The value1.
        /// </value>
        public string Value1
        {
            get => this.Model.Value1;
            set => this.Model.Value1 = value;
        }

        /// <summary>
        ///     Gets or sets the value2.
        /// </summary>
        /// <value>
        ///     The value2.
        /// </value>
        public string Value2
        {
            get => this.Model.Value2;
            set => this.Model.Value2 = value;
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => this.Model.PropertyChanged -= this.OnModelPropertyChanged;

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
        ///     Called when [model property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e) =>
            this.OnPropertyChanged(e.PropertyName);

        /// <summary>
        ///     Validations the messages on errors changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e) => this.OnErrorsChanged(e);
    }
}