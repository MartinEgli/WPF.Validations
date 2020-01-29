// -----------------------------------------------------------------------
// <copyright file="RangesModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels
{
    using Anori.Common.Binders;

    /// <summary>
    ///     The ranges model
    /// </summary>
    /// <seealso cref="Anori.Common.Binders.Bindable" />
    public class RangesModel : Bindable
    {
        /// <summary>
        ///     The maximum
        /// </summary>
        private double max;

        /// <summary>
        ///     The minimum
        /// </summary>
        private double min;

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public double Max
        {
            get => this.max;
            set => this.SetProperty(ref this.max, value);
        }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public double Min
        {
            get => this.min;
            set => this.SetProperty(ref this.min, value);
        }
    }
}