// -----------------------------------------------------------------------
// <copyright file="MinMaxRangeModelRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
{
    using Anori.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// The minimum maximum range model rule
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.Validators.ModelValidationRule{Anori.Common.WPF.Validations.ValidationTestGui.Rules.IMinMaxValue}" />
    public class MinMaxRangeModelRule : ModelValidationRule<IMinMaxValue>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AreValuesEqualRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        public MinMaxRangeModelRule([NotNull] string ruleName)
            : base(ruleName)
        {
        }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override ModelValidationResult Validate(IMinMaxValue model)
        {
            if (model.Min > model.Value)
            {
                return new ModelValidationResult(false, this.RuleName, "Values is less then " + model.Min);
            }

            if (model.Max < model.Value)
            {
                return new ModelValidationResult(false, this.RuleName, "Values is grater then " + model.Max);
            }

            return this.ValidResult;
        }
    }
}