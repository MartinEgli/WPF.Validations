// -----------------------------------------------------------------------
// <copyright file="AdderModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Concepts.Models
{
    using Bfa.Common.Binders;

    public class AdderModel : Bindable
    {
        /// <summary>
        ///     The x
        /// </summary>
        private double? x;

        /// <summary>
        ///     The y
        /// </summary>
        private double? y;

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public double? X
        {
            get => this.x;
            set => this.SetProperty(ref this.x, value);
        }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public double? Y
        {
            get => this.y;
            set => this.SetProperty(ref this.y, value);
        }
    }
}