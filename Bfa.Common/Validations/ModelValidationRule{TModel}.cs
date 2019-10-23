﻿// -----------------------------------------------------------------------
// <copyright file="ModelValidationRule{TModel}.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Generic ValidationRule class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Bfa.Common.Validations.PropertyValidationRule" />
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