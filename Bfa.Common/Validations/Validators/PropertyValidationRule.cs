// -----------------------------------------------------------------------
// <copyright file="PropertyValidationRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationRule class.
    /// </summary>
    /// <seealso cref="ValidationRule" />
    public abstract class PropertyValidationRule : ValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValidationRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        protected PropertyValidationRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName)
        {
            this.PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            this.ValidResult = PropertyValidationResult.ValidResult(this.RuleName, this.PropertyName);
        }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        [NotNull]
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the valid result.
        /// </summary>
        /// <value>
        ///     The valid result.
        /// </value>
        [NotNull]
        protected PropertyValidationResult ValidResult { get; }

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [NotNull]
        public abstract PropertyValidationResult Validate([CanBeNull] object value, [NotNull] object model);

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public virtual PropertyValidationResult Validate([CanBeNull] ref object value, [NotNull] object model)
        {
            return this.Validate(value, model);
        }
    }
}