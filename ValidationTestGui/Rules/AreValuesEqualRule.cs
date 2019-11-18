// -----------------------------------------------------------------------
// <copyright file="AreValuesEqualRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    using Bfa.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    ///     AreValuesEqualRule
    /// </summary>
    /// <seealso
    ///     cref="ModelValidationRule{IComparerTwoValues}" />
    public class AreValuesEqualRule : ModelValidationRule<IComparerTwoValues>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AreValuesEqualRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        public AreValuesEqualRule([NotNull] string ruleName)
            : base(ruleName)
        {
        }

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override ModelValidationResult Validate(IComparerTwoValues model)
        {
            if (model.Value1 == model.Value2)
            {
                return this.ValidResult;
            }

            return new ModelValidationResult(false, this.RuleName, "Values are not equals");
        }
    }
}