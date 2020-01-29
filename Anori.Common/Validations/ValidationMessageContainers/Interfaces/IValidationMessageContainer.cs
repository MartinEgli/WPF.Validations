// -----------------------------------------------------------------------
// <copyright file="IValidationMessageContainer.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Interfaces
{
    using System;
    using System.ComponentModel;

    using Anori.Common.Collections;
    using Anori.Common.Validations.ValidationMessageContainers.Internals;

    /// <summary>
    ///     Validation Error Container Interface
    /// </summary>
    public interface IValidationMessageContainer : ICatchValidationErrorContainer
    {
        /// <summary>
        ///     Occurs when [errors changed].
        /// </summary>
        event EventHandler<MessageChangedEventArgs> MessageChanged;

        /// <summary>
        ///     Occurs when [errors changed].
        /// </summary>
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets the <see cref="ReadOnlyObservableCollection{T}" /> with the specified name.
        /// </summary>
        /// <value>
        ///     The <see cref="ReadOnlyObservableCollection{IValidationMessage}" />.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ReadOnlyObservableCollection<IValidationMessage> this[string name] { get; }

        /// <summary>
        ///     Gets the error count.
        /// </summary>
        /// <value>
        ///     The error count.
        /// </value>
        int ErrorCount { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance has errors.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </value>
        bool HasErrors { get; }

        /// <summary>
        ///     Gets the current validation error.
        /// </summary>
        /// <value>
        ///     The current validation error.
        /// </value>
        IValidationMessage CurrentValidationError { get; }

        /// <summary>
        ///     Gets the errors.
        /// </summary>
        /// <value>
        ///     The errors.
        /// </value>
        ReadOnlyObservableCollection<IValidationMessage> Errors { get; }

        /// <summary>
        ///     Adds the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        bool AddError(IValidationMessage error, bool isWarning = false);

        /// <summary>
        ///     Removes the error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        bool RemoveError(string propertyName, string errorId);

        /// <summary>
        ///     Gets the property errors.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        System.Collections.IEnumerable GetPropertyErrors(string propertyName);

        /// <summary>
        ///     Gets the validation error messages as string.
        /// </summary>
        /// <returns></returns>
        string GetValidationErrorMessagesAsString();
    }
}