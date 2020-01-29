// -----------------------------------------------------------------------
// <copyright file="MinMaxRangeRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using System;

    using Anori.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// The minimum maximum range rule
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.Validators.PropertyValidationRule{double?}" />
    public class MinMaxRangeRule : PropertyValidationRule<double?>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MinMaxRangeRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public MinMaxRangeRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName, propertyName)
        {
        }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public double? Min { get; set; }

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public double? Max { get; set; }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override PropertyValidationResult Validate(double? value)
        {
            if (!value.HasValue)
            {
                return this.ValidResult;
            }

            try
            {
                var val = value.Value;
                if (this.Max.HasValue && val > this.Max.Value)
                {
                    return new PropertyValidationResult(
                        false,
                        this.RuleName,
                        this.PropertyName,
                        this.PropertyName + " must be <= " + this.Max + ".");
                }

                if (this.Min.HasValue && val < this.Min.Value)
                {
                    return new PropertyValidationResult(
                        false,
                        this.RuleName,
                        this.PropertyName,
                        this.PropertyName + " must be >= " + this.Min + ".");
                }
            }
            catch (Exception)
            {
                // Try to match the system generated error message so it does not look out of place.
                return new PropertyValidationResult(
                    false,
                    this.RuleName,
                    this.PropertyName,
                    this.PropertyName + " is not in a correct numeric format.");
            }

            return new PropertyValidationResult(true, this.RuleName, this.PropertyName, "Is Valid!");
        }
    }
}