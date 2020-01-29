// -----------------------------------------------------------------------
// <copyright file="ValidationErrorContainerExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using System;

    using Anori.Common.Validations.ValidationMessageContainers;
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;
    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationErrorContainerExtensions class.
    /// </summary>
    public static class ValidationErrorContainerExtensions
    {
        /// <summary>
        ///     The default group name
        /// </summary>
        public const string DefaultGroupName = "*";

        /// <summary>
        ///     Updates the error.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     result
        ///     or
        ///     container
        /// </exception>
        public static bool UpdateError(
            [NotNull] this IValidationMessageContainer container,
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

            if (result is IValidationMessage message)
            {
                container.AddError(message);
            }
            else if (result is ILocalizationTextKeyAware localizationTextKey)
            {
                if (result.IsWarning)
                {
                    container.AddError(
                        new LocValidationWarning(
                            result.PropertyName,
                            result.RuleName,
                            result.Message,
                            localizationTextKey.TextKey));
                }
                else
                {
                    container.AddError(
                        new LocValidationError(
                            result.PropertyName,
                            result.RuleName,
                            result.Message,
                            localizationTextKey.TextKey));
                }
            }
            else
            {
                if (result.IsWarning)
                {
                    container.AddError(new ValidationWarning(result.PropertyName, result.RuleName, result.Message));
                }
                else
                {
                    container.AddError(new ValidationError(result.PropertyName, result.RuleName, result.Message));
                }
            }

            return false;
        }

        /// <summary>
        ///     Updates the error.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="result">The result.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     result
        ///     or
        ///     groupName
        ///     or
        ///     container
        /// </exception>
        public static bool UpdateError(
            [NotNull] this IValidationMessageContainer container,
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

            if (result.IsWarning)
            {
                container.AddError(new ValidationWarning(groupName, result.RuleName, result.Message));
            }
            else
            {
                container.AddError(new ValidationError(groupName, result.RuleName, result.Message));
            }

            return false;
        }
    }
}