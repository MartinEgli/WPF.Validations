// -----------------------------------------------------------------------
// <copyright file="RegexRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System.Text.RegularExpressions;

    using Anori.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// The regex rule
    /// </summary>
    /// <seealso cref="PropertyValidationRule{string}" />
    public class RegexRule : PropertyValidationRule<string>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MandatoryRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public RegexRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName, propertyName)
        {
        }

        /// <summary>
        ///     Gets or sets the regex options.
        /// </summary>
        /// <value>
        ///     The regex options.
        /// </value>
        public RegexOptions RegexOptions { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>
        ///     The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets or sets the regex pattern.
        /// </summary>
        /// <value>
        ///     The regex pattern.
        /// </value>
        public string RegexPattern { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is warning.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is warning; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarning { get; set; }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override PropertyValidationResult Validate(string value)
        {
            if (string.IsNullOrEmpty(this.RegexPattern))
            {
                return this.ValidResult;
            }

            var text = value ?? string.Empty;

            if (!Regex.IsMatch(text, this.RegexPattern, this.RegexOptions))
            {
                return new PropertyValidationResult(
                    false,
                    this.RuleName,
                    this.PropertyName,
                    this.ErrorMessage,
                    this.IsWarning);
            }

            return this.ValidResult;
        }
    }
}