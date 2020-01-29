// -----------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using Anori.Common.Binders;
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

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