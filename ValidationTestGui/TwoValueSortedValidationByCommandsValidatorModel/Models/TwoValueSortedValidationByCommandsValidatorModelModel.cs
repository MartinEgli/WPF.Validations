// -----------------------------------------------------------------------
// <copyright file="TwoValueSortedValidationByCommandsAndValidatorViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.Models
{
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;

    /// <summary>
    ///     The two value sorted validation by commands validator view model
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.Rules.IComparerTwoValues" />
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class TwoValueSortedValidationByCommandsValidatorModelModel : Binders.Bindable, IComparerTwoValues
    {
        /// <summary>
        ///     The value1
        /// </summary>
        private string value1;

        /// <summary>
        ///     The value2
        /// </summary>
        private string value2;

        /// <summary>
        ///     Gets or sets the value1.
        /// </summary>
        /// <value>
        ///     The value1.
        /// </value>
        public string Value1
        {
            get => this.value1;
            set => this.SetProperty(ref this.value1, value);
        }

        /// <summary>
        ///     Gets or sets the value2.
        /// </summary>
        /// <value>
        ///     The value2.
        /// </value>
        public string Value2
        {
            get => this.value2;
            set => this.SetProperty(ref this.value2, value);
        }
    }
}