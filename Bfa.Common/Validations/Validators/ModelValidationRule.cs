// -----------------------------------------------------------------------
// <copyright file="ModelValidationRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationRule class.
    /// </summary>
    /// <seealso cref="ValidationRule" />
    public abstract class ModelValidationRule : ValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyValidationRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        protected ModelValidationRule([NotNull] string ruleName)
            : base(ruleName)
        {
        }

        /// <summary>
        ///     Gets the valid result.
        /// </summary>
        /// <value>
        ///     The valid result.
        /// </value>
        [NotNull]
        protected ModelValidationResult ValidResult => ModelValidationResult.ValidResult(this.RuleName);

        /// <summary>
        ///     Gets or sets the target.
        /// </summary>
        /// <value>
        ///     The target.
        /// </value>
        public string Target { get; set; }

        /// <summary>
        ///     Validates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [NotNull]
        public abstract ModelValidationResult Validate([NotNull] object model);
    }
}