// -----------------------------------------------------------------------
// <copyright file="AdderViewModelIDataErrorInfo.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels
{
    using System.ComponentModel;

    using Bfa.Common.Validations;

    /// <summary>
    ///     AdderViewModelIDataErrorInfo class
    /// </summary>
    /// <seealso cref="AdderViewModel" />
    /// <seealso cref="System.ComponentModel.IDataErrorInfo" />
    public class AdderViewModelIDataErrorInfo : AdderViewModel, IDataErrorInfo
    {
        /// <summary>
        ///     The error message must be non negative
        /// </summary>
        public const string ErrorMessageMustBeNonNegative = " must be non-negative";

        /// <summary>
        ///     The error message mandatory
        /// </summary>
        public const string ErrorMessageMandatory = " is mandatory";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdderViewModelIDataErrorInfo" /> class.
        /// </summary>
        public AdderViewModelIDataErrorInfo(AdderModel model, Validator<AdderModel> validator)
            : base(model, validator)
        {
            this.ValidationErrors.ErrorsChanged += this.OnErrorsChanged;
        }

        /// <summary>
        ///     Gets the <see cref="System.String" /> with the specified property name.
        /// </summary>
        /// <value>
        ///     The <see cref="System.String" />.
        /// </value>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                Tracer.LogValidation("IDataErrorInfo.Item validating " + propertyName);
                switch (propertyName)
                {
                    case "X":
                        {
                            var errMsg = this.nvl(
                                this.ValidateNonNegativeInput(this.X, "X", ErrorMessageMustBeNonNegative),
                                this.ValidateMandatory(this.X, "X", ErrorMessageMandatory));

                            Tracer.LogUserDefinedValidation(
                                "IDataErrorInfo.Item[X] called. "
                                + this.ValidationErrors.GetValidationErrorMessagesAsString());
                            Tracer.LogUserDefinedValidation(
                                "IDataErrorInfo.Item[X] - returned error message is '" + errMsg + "'");

                            return errMsg;
                        }

                    case "Y":
                        {
                            var errMsg = this.nvl(
                                this.ValidateNonNegativeInput(this.Y, "Y", ErrorMessageMustBeNonNegative),
                                this.ValidateMandatory(this.Y, "Y", ErrorMessageMandatory));

                            Tracer.LogUserDefinedValidation(
                                "IDataErrorInfo.Item[X] called. "
                                + this.ValidationErrors.GetValidationErrorMessagesAsString());
                            Tracer.LogUserDefinedValidation(
                                "IDataErrorInfo.Item[X] - returned error message is '" + errMsg + "'");

                            return errMsg;
                        }
                }

                return "";
            }
        }

        // Never called by the framework.
        public string Error => "";

        /// <summary>
        ///     Validates the non negative input.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="ErrorMessage">The error message.</param>
        /// <returns></returns>
        private string ValidateNonNegativeInput(
            double? x,
            string fieldName, /*string ConstraintID,*/
            string ErrorMessage)
        {
            if (x.HasValue && x.Value < 0.0)
            {
                return ErrorMessage;
            }

            return "";
        }

        /// <summary>
        ///     Validates the mandatory.
        /// </summary>
        /// <param name="x">The X.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="ErrorMessage">The error message.</param>
        /// <returns></returns>
        private string ValidateMandatory(double? x, string fieldName, /*string ConstraintID,*/ string ErrorMessage)
        {
            if (x.HasValue)
            {
                return "";
            }

            return ErrorMessage;
        }

        /// <summary>
        ///     NVLs the specified s1.
        /// </summary>
        /// <param name="s1">The s1.</param>
        /// <param name="s2">The s2.</param>
        /// <returns></returns>
        private string nvl(string s1, string s2)
        {
            return string.IsNullOrEmpty(s1) ? s2 : s1;
        }

        /// <summary>
        ///     Called when [errors changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        public void OnErrorsChanged(object sender, ErrorsChangedEventArgs args)
        {
            this.Sum = null;
            this.OnPropertyChanged("CurrentValidationError");
            Tracer.LogUserDefinedValidation(
                "OnErrorsChanged called. " + this.ValidationErrors.GetValidationErrorMessagesAsString());
        }
    }
}