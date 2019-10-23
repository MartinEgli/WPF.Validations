// -----------------------------------------------------------------------
// <copyright file="ModelValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    /// ModelValidationResult class
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.ValidationResult" />
    public class ModelValidationResult : ValidationResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModelValidationResult" /> class.
        /// </summary>
        /// <param name="isValid">if set to <c>true</c> [is valid].</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">propertyName</exception>
        public ModelValidationResult(bool isValid, [NotNull] string ruleName, [NotNull] string message)
            : base(isValid, ruleName, message)
        {
        }

        /// <summary>
        ///     Returns a valid ValidationResult
        /// </summary>
        /// <value>
        ///     The valid result.
        /// </value>
        public static ModelValidationResult ValidResult([NotNull] string ruleName)
        {
            if (ruleName == null)
            {
                throw new ArgumentNullException(nameof(ruleName));
            }

            return new ModelValidationResult(true, ruleName, "Result is valid.");
        }
    }
}