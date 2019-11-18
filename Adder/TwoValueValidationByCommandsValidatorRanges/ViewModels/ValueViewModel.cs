// -----------------------------------------------------------------------
// <copyright file="ValueViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;

    /// <summary>
    ///     The value view model
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.Rules.IMinMaxValue" />
    public class ValueViewModel : Binders.Bindable, INotifyDataErrorInfo, IDisposable, IMinMaxValue
    {
        /// <summary>
        ///     The ranges model
        /// </summary>
        private readonly RangesModel rangesModel;

        /// <summary>
        ///     The value model
        /// </summary>
        private readonly ValueModel valueModel;

        /// <summary>
        ///     The validator
        /// </summary>
        private Validator<ValueViewModel> validator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValueViewModel" /> class.
        /// </summary>
        /// <param name="valueModel">The value model.</param>
        /// <param name="rangesModel">The ranges model.</param>
        public ValueViewModel(ValueModel valueModel, RangesModel rangesModel)
        {
            this.valueModel = valueModel;
            this.rangesModel = rangesModel;

            valueModel.PropertyChanged += this.OnValueModelPropertyChanged;
            rangesModel.PropertyChanged += this.OnRangesModelPropertyChanged;
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public double Min => this.rangesModel.Min;

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public double Value
        {
            get => this.valueModel.Value;
            set => this.valueModel.Value = value;
        }

        /// <summary>
        ///     Gets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public double Max => this.rangesModel.Max;

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <value>
        ///     The validator.
        /// </value>
        public Validator<ValueViewModel> Validator
        {
            get => this.validator;
            set
            {
                if (this.validator == value)
                {
                    return;
                }

                if (this.validator != null)
                {
                    this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;
                }

                this.validator = value;
                if (this.validator != null)
                {
                    this.Validator.ValidationMessages.ErrorsChanged += this.ValidationMessagesOnErrorsChanged;
                }
            }
        }

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.Validator.ValidationMessages.HasErrors;

        /// <summary>
        ///     Called when [ranges model property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnRangesModelPropertyChanged(object sender, PropertyChangedEventArgs e) =>
            this.OnPropertyChanged(e.PropertyName);

        /// <summary>
        ///     Called when [value model property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnValueModelPropertyChanged(object sender, PropertyChangedEventArgs e) =>
            this.OnPropertyChanged(e.PropertyName);

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
        public IEnumerable GetErrors(string propertyName) =>
            this.Validator.ValidationMessages.GetPropertyErrors(propertyName);

        /// <summary>
        ///     Raises the <see cref="E:ErrorsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) => this.ErrorsChanged?.Invoke(this, e);

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() =>
            this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;

        /// <summary>
        ///     Validations the messages on errors changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e) =>
            this.OnErrorsChanged(e);
    }
}