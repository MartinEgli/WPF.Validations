// -----------------------------------------------------------------------
// <copyright file="IValidationErrorsAware.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    /// <summary>
    /// Validation Errors Aware interface.
    /// </summary>
    public interface IValidationErrorsAware
    {
        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        IValidationErrorContainer ValidationErrors { get; }
    }
}