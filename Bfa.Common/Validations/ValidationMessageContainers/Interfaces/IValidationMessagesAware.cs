// -----------------------------------------------------------------------
// <copyright file="IValidationMessagesAware.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers.Interfaces
{
    /// <summary>
    /// Validation Errors Aware interface.
    /// </summary>
    public interface IValidationMessagesAware
    {
        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        IValidationMessageContainer ValidationMessages { get; }
    }
}