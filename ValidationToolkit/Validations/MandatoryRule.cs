// -----------------------------------------------------------------------
// <copyright file="MandatoryRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System.Windows.Controls;

    /// <summary>
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class MandatoryRule : ValidationRule
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

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
            if (this.Name == null)
            {
                this.Name = string.Empty;
            }

            if (this.Name.Length == 0)
            {
                this.Name = "Field";
            }

            if (!(value is string str))
            {
                return new ValidationResult(false, this.Name + " is mandatory.");
            }

            if (!string.IsNullOrEmpty(str))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, this.Name + " is mandatory.");
        }
    }
}