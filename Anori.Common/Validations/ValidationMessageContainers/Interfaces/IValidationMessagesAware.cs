// -----------------------------------------------------------------------
// <copyright file="IValidationMessagesAware.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Interfaces
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