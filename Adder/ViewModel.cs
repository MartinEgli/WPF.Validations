// -----------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Binders;
    using Bfa.Common.Validations;
    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    ///     ViewModel Class
    /// </summary>
    /// <seealso cref="IValidationMessagesAware" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModel : Bindable, IValidationMessagesAware
    {
        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public abstract IValidationMessageContainer ValidationMessages { get; }
    }
}