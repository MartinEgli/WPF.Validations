// -----------------------------------------------------------------------
// <copyright file="ValueModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels
{
    using Anori.Common.Binders;

    /// <summary>
    ///     The value model
    /// </summary>
    /// <seealso cref="Anori.Common.Binders.Bindable" />
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