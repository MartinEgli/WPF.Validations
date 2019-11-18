// -----------------------------------------------------------------------
// <copyright file="AdderViewModelINotifyDataErrorInfo.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels
{
    using Bfa.Common.Validations.ValidationMessageContainers;
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Concepts.Models;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Concepts.ViewModels;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;

    /// <summary>
    ///     Adder View Model INotifyDataErrorInfo class.
    /// </summary>
    /// <seealso cref="AdderViewModel" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    public class AdderViewModelINotifyDataErrorInfo : AdderViewModel, INotifyDataErrorInfo
    {
        /// <summary>
        ///     The constraint Mandatory
        /// </summary>
        public const string ConstraintMandatory = "IsMandatory";

        /// <summary>
        ///     The constraint must be non negative
        /// </summary>
        public const string ConstraintMustBeNonNegative = "NonNegative";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdderViewModelINotifyDataErrorInfo" /> class.
        /// </summary>
        public AdderViewModelINotifyDataErrorInfo(AdderModel model, Validator<AdderModel> validator)
            : base(model, validator)
        {
            this.ValidationMessages.MessageChanged += this.OnErrorsChanged;
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add => this.ValidationMessages.ErrorsChanged += value;
            remove => this.ValidationMessages.ErrorsChanged -= value;
        }

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.ValidationMessages.HasErrors;

        /// <summary>
        ///     Validates the non negative.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        private void ValidateNonNegative(double? x, string fieldName)
        {
            if (x.HasValue && x.Value < 0.0)
            {
                this.ValidationMessages.AddError(
                    new ValidationError(fieldName, ConstraintMustBeNonNegative, fieldName + ": must be non-negative"));
            }
            else
            {
                this.ValidationMessages.RemoveError(fieldName, ConstraintMustBeNonNegative);
            }
        }

        /// <summary>
        ///     Validates the Mandatory.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        private void ValidateMandatory(double? x, string fieldName)
        {
            if (!x.HasValue)
            {
                this.ValidationMessages.AddError(
                    new ValidationWarning(fieldName, ConstraintMandatory, fieldName + ": is Mandatory"));
            }
            else
            {
                this.ValidationMessages.RemoveError(fieldName, ConstraintMandatory);
            }
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        private void Validate()
        {
            if (this.X.HasValue && this.Y.HasValue && this.X.Value > this.Y.Value)
            {
                this.ValidationMessages.AddError(new ValidationWarning("Validation", "Bigger", "X > Y"));
            }
            else
            {
                this.ValidationMessages.RemoveError("Validation", "Bigger");
            }
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected override void ValidateProperty(string propertyName)
        {
            Tracer.LogValidation("INotifyDataErrorInfo.ValidateProperty called. Validating " + propertyName);
            switch (propertyName)
            {
                case "X":
                    {
                        this.ValidateNonNegative(this.X, "X");
                        this.ValidateMandatory(this.X, "X");
                    }
                    break;

                case "Y":
                    {
                        this.ValidateNonNegative(this.Y, "Y");
                        this.ValidateMandatory(this.Y, "Y");
                    }
                    break;
            }

            this.Validate();
            if (string.IsNullOrEmpty(propertyName))
            {
                Tracer.LogValidation("No cross-property validation errors.");
            }
        }

        /// <summary>
        ///     Called when [errors changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="MessageChangedEventArgs" /> instance containing the event data.</param>
        public void OnErrorsChanged(object sender, MessageChangedEventArgs args)
        {
            this.Sum = null;
            var propertyName = args.PropertyName;
            Tracer.LogUserDefinedValidation(
                "OnErrorsChanged called. " + this.ValidationMessages.GetValidationErrorMessagesAsString());
            this.OnPropertyChanged("CurrentValidationError");
        }

        /// <summary>
        ///     Gets the validation errors for a specified property or for the entire entity.
        /// </summary>
        /// <param name="propertyName">
        ///     The name of the property to retrieve validation errors for; or null or
        ///     <see cref="F:System.String.Empty" />, to retrieve entity-level errors.
        /// </param>
        /// <returns>
        ///     The validation errors for the property or entity.
        /// </returns>
        public System.Collections.IEnumerable GetErrors([NotNull] string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return this.ValidationMessages.GetPropertyErrors(propertyName);
        }
    }
}