// -----------------------------------------------------------------------
// <copyright file="ValidationErrorContainerExtensions.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationErrorContainerExtensions class.
    /// </summary>
    public static class ValidationErrorContainerExtensions
    {
        /// <summary>
        /// Updates the error.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// result
        /// or
        /// container
        /// </exception>
        public static bool UpdateError(
            [NotNull] this IValidationErrorContainer container,
            [NotNull] PropertyValidationResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (result.IsValid)
            {
                container.RemoveError(result.PropertyName, result.RuleName);
                return true;
            }

            container.AddError(new ValidationError(result.PropertyName, result.RuleName, result.Message));
            return false;
        }

        /// <summary>
        /// The default group name
        /// </summary>
        public const string DefaultGroupName = "*";

        /// <summary>
        /// Updates the error.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="result">The result.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// result
        /// or
        /// groupName
        /// or
        /// container
        /// </exception>
        public static bool UpdateError(
            [NotNull] this IValidationErrorContainer container,
            [NotNull] ModelValidationResult result,
            [NotNull] string groupName = DefaultGroupName)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (result.IsValid)
            {
                container.RemoveError(groupName, result.RuleName);
                return true;
            }

            container.AddError(new ValidationError(groupName, result.RuleName, result.Message));
            return false;
        }
    }
}