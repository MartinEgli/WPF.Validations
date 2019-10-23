// -----------------------------------------------------------------------
// <copyright file="MaxRangeRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;

    using Bfa.Common.Validations;

    using JetBrains.Annotations;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.PropertyValidationRule{System.Double?}" />
    public class MaxRangeRule : PropertyValidationRule<double?>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxRangeRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public MaxRangeRule([NotNull] string ruleName, [NotNull] string propertyName)
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