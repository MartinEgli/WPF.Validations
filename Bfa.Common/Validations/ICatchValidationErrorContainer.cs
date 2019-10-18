// -----------------------------------------------------------------------
// <copyright file="ICatchValidationErrorContainer.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    /// <summary>
    /// </summary>
    public interface ICatchValidationErrorContainer
    {
        /// <summary>
        ///     Adds the catch validation error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        bool AddCatchValidationError(IValidationMessage error, bool isWarning = false);

        /// <summary>
        ///     Removes the catch validation error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        bool RemoveCatchValidationError(string propertyName, string errorId);
    }
}