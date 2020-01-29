// -----------------------------------------------------------------------
// <copyright file="TraceValidationRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations
{
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Controls;

    /// <summary>
    ///     The debug rule has only one purpose - to report that when it is called.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class TraceValidationRule : ValidationRule
    {
        /// <summary>
        ///     Gets or sets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        public string PropertyName { get; set; }

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
            Debug.WriteLine(
                new StringBuilder().Append("TraceValidationRule for '")
                    .Append(this.PropertyName)
                    .Append("' called. ValidationStep='")
                    .Append(this.ValidationStep.ToString())
                    .Append("'")
                    .ToString());

            return ValidationResult.ValidResult; // Don't stop the validation process by reporting an error.
        }
    }
}