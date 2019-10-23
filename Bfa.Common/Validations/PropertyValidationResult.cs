﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     Property Validation Result class.
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.ValidationResult" />
    public class PropertyValidationResult : ValidationResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValidationResult" /> class.
        /// </summary>
        /// <param name="isValid">if set to <c>true</c> [is valid].</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">propertyName</exception>
        public PropertyValidationResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            [NotNull] string message)
            : base(isValid, ruleName, message)
        {
            this.PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        /// <summary>
        ///     Returns a valid ValidationResult
        /// </summary>
        /// <value>
        ///     The valid result.
        /// </value>
        internal static PropertyValidationResult ValidResult([NotNull] string ruleName,
                                                           [NotNull] string propertyName)
        {
            if (ruleName == null)
            {
                throw new ArgumentNullException(nameof(ruleName));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return new PropertyValidationResult(true, ruleName, propertyName, "Result is valid.");
        }

        /// <summary>
        ///     Gets the ruleName of the property.
        /// </summary>
        /// <value>
        ///     The ruleName of the property.
        /// </value>
        public string PropertyName { get; }
    }
}