// -----------------------------------------------------------------------
// <copyright file="NumberRangeRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System;
    using System.Windows.Controls;

    using Bfa.Common.WPF.Validations.ValidationRules;

    /// <summary>
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class IntegerRangeRule : ValidationRule
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public int Min { get; set; } = int.MinValue;

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public int Max { get; set; } = short.MaxValue;

        /// <summary>
        ///     When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>
        ///     A <see cref="T:System.Windows.Controls.ValidationResult" /> object.
        /// </returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return ValidationResult.ValidResult;
            }

            if (this.Name.Length == 0)
            {
                this.Name = "Field";
            }

            try
            {
                if (((string)value).Length > 0)
                {
                    var val = int.Parse((string)value);
                    if (val > this.Max)
                    {
                        return new ValidationRuleWarning(this.Name + " must be <= " + this.Max + ".")
                            .ToValidationResult();
                    }

                    if (val < this.Min)
                    {
                        return new ValidationResult(false, this.Name + " must be >= " + this.Min + ".");
                    }
                }
            }
            catch (Exception)
            {
                // Try to match the system generated error message so it does not look out of place.
                return new ValidationResult(false, this.Name + " is not in a correct numeric format.");
            }

            return ValidationResult.ValidResult;
        }
    }
}