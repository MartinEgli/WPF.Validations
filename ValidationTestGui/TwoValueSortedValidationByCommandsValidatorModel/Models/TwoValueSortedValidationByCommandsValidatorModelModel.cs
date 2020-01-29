// -----------------------------------------------------------------------
// <copyright file="TwoValueSortedValidationByCommandsAndValidatorViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.Models
{
    using Anori.Common.WPF.Validations.ValidationTestGui.Rules;

    /// <summary>
    ///     The two value sorted validation by commands validator view model
    /// </summary>
    /// <seealso cref="Anori.Common.WPF.Validations.ValidationTestGui.Rules.IComparerTwoValues" />
    /// <seealso cref="Anori.Common.Binders.Bindable" />
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