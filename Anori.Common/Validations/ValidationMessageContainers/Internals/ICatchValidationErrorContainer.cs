// -----------------------------------------------------------------------
// <copyright file="ICatchValidationErrorContainer.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Internals
{
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    ///     ICatchValidationErrorContainer class.
    /// </summary>
    public interface ICatchValidationErrorContainer
    {
        /// <summary>
        ///     Adds the catch validation error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        bool AddCatchValidationError(IValidationMessage message, bool isWarning = false);

        /// <summary>
        ///     Removes the catch validation error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        bool RemoveCatchValidationError(string propertyName, string errorId);
    }
}