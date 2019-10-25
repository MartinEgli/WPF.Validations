// -----------------------------------------------------------------------
// <copyright file="PropertyValidationRule{TProperty}.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Generic ValidationRule class.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <seealso cref="ValidationRule" />
    /// <seealso cref="PropertyValidationRule" />
    public abstract class PropertyValidationRule<TProperty> : PropertyValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValidationRule{TProperty}" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        protected PropertyValidationRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName, propertyName)
        {
        }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public abstract PropertyValidationResult Validate([CanBeNull] TProperty value);

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override PropertyValidationResult Validate(object value, object model)
        {
            return this.Validate((TProperty)value);
        }
    }
}