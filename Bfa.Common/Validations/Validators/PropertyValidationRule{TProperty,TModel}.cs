// -----------------------------------------------------------------------
// <copyright file="PropertyValidationRule{TProperty,TModel}.cs" company="bfa solutions ltd">
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
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="PropertyValidationRule" />
    public abstract class PropertyValidationRule<TProperty, TModel> : PropertyValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValidationRule{TProperty, TModel}" /> class.
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
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [NotNull]
        public abstract PropertyValidationResult Validate([CanBeNull] TProperty value, [NotNull] TModel model);

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override PropertyValidationResult Validate(object value, object context)
        {
            return this.Validate((TProperty)value, (TModel)context);
        }
    }
}