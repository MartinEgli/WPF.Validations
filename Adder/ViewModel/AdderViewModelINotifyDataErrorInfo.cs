// -----------------------------------------------------------------------
// <copyright file="AdderViewModelINotifyDataErrorInfo.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.ViewModel
{
    using System;
    using System.ComponentModel;

    using Adder;

    using Bfa.Common.Validations;


    /// <summary>
    ///  Adder View Model INotifyDataErrorInfo class.
    /// </summary>
    /// <seealso cref="Adder.AdderViewModel" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    public class AdderViewModelINotifyDataErrorInfo : AdderViewModel, INotifyDataErrorInfo
    {
        /// <summary>
        ///     The constraint mandatory
        /// </summary>
        public const string ConstraintMandatory = "IsMandatory";

        /// <summary>
        ///     The constraint must be non negative
        /// </summary>
        public const string ConstraintMustBeNonNegative = "NonNegative";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdderViewModelINotifyDataErrorInfo" /> class.
        /// </summary>
        public AdderViewModelINotifyDataErrorInfo()
        {
            this.ValidationErrors.ErrorsChanged += this.OnErrorsChanged;
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add => this.ValidationErrors.NotifyDataErrorInfoErrorsChanged += value;
            remove => this.ValidationErrors.NotifyDataErrorInfoErrorsChanged -= value;
        }

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.ValidationErrors.HasErrors;

        /// <summary>
        ///     Validates the non negative.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        private void ValidateNonNegative(double? x, string fieldName)
        {
            if (x.HasValue && x.Value < 0.0)
            {
                this.ValidationErrors.AddError(
                    new ValidationError(fieldName, ConstraintMustBeNonNegative, fieldName + ": must be non-negative"));
            }
            else
            {
                this.ValidationErrors.RemoveError(fieldName, ConstraintMustBeNonNegative);
            }
        }

        /// <summary>
        ///     Validates the mandatory.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        private void ValidateMandatory(double? x, string fieldName)
        {
            if (!x.HasValue)
            {
                this.ValidationErrors.AddError(
                    new ValidationWarning(fieldName, ConstraintMandatory, fieldName + ": is mandatory"));
            }
            else
            {
                this.ValidationErrors.RemoveError(fieldName, ConstraintMandatory);
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        private void Validate()
        {
            if (this.X.HasValue && this.Y.HasValue && this.X.Value > this.Y.Value)
            {
                this.ValidationErrors.AddError(new ValidationWarning("Validation", "Bigger", "X > Y"));
            }
            else
            {
                this.ValidationErrors.RemoveError("Validation", "Bigger");
            }
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public override void ValidateProperty(string propertyName)
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
        /// <param name="args">The <see cref="ErrorsChangedEventArgs" /> instance containing the event data.</param>
        public void OnErrorsChanged(object sender, ErrorsChangedEventArgs args)
        {
            this.Sum = null;
            var propertyName = args.PropertyName;
            Tracer.LogUserDefinedValidation(
                "OnErrorsChanged called. " + this.ValidationErrors.GetValidationErrorMessagesAsString());
            this.NotifyPropertyChanged("CurrentValidationError");
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
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            return this.ValidationErrors.GetPropertyErrors(propertyName);
        }
    }
}