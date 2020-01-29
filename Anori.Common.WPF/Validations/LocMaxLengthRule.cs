// -----------------------------------------------------------------------
// <copyright file="LocMaxLengthRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations
{
    using System.Windows.Controls;

    using Anori.Common.WPF.Localizations;
    using Anori.Common.WPF.Validations.ValidationRules;

    /// <summary>
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ValidationRule" />
    public class LocMaxLengthRule : ValidationRule
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the maximum length.
        /// </summary>
        /// <value>
        ///     The maximum length.
        /// </value>
        public int MaxLength { get; set; }

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

            if ((value is string str) && str.Length > this.MaxLength)
            {
                return new LocMaxLengthWarning(
                    this.Name + " length is more than " + this.MaxLength + ".",
                    new LanguageKey("MaxLength", "Group1", "Source1"),
                    this.MaxLength).ToValidationResult();
            }

            return ValidationResult.ValidResult;
        }
    }
}