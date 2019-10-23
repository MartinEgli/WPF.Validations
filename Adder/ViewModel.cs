// -----------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Binders;
    using Bfa.Common.Validations;

    /// <summary>
    ///     ViewModel Class
    /// </summary>
    /// <seealso cref="IValidationErrorsAware" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModel : Bindable, IValidationErrorsAware
    {
        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public abstract IValidationErrorContainer ValidationErrors { get; }
    }
}