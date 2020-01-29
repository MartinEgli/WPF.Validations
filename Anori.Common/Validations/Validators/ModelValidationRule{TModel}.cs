// -----------------------------------------------------------------------
// <copyright file="ModelValidationRule{TModel}.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Generic ValidationRule class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="PropertyValidationRule" />
    public abstract class ModelValidationRule<TModel> : ModelValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModelValidationRule{TModel}" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        protected ModelValidationRule([NotNull] string ruleName)
            : base(ruleName)
        {
        }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [NotNull]
        public abstract ModelValidationResult Validate([NotNull] TModel model);

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override ModelValidationResult Validate(object model)
        {
            return this.Validate((TModel)model);
        }
    }
}