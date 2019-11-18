// -----------------------------------------------------------------------
// <copyright file="ValueModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels
{
    using Bfa.Common.Binders;

    /// <summary>
    ///     The value model
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    public class ValueModel : Bindable
    {
        /// <summary>
        ///     The value
        /// </summary>
        private double value;

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public double Value
        {
            get => this.value;
            set => this.SetProperty(ref this.value, value);
        }
    }
}