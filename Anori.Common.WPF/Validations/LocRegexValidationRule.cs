// -----------------------------------------------------------------------
// <copyright file="RegexValidationRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    using Anori.Common.WPF.Validations.ValidationRules;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     A <see cref="System.Windows.Controls.ValidationRule" />-derived class which
    ///     supports the use of regular expressions for validation.
    /// </summary>
    public class LocRegexValidationRule : ValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LocRegexValidationRule" /> class.
        /// </summary>
        public LocRegexValidationRule()
        {
        }

        /// <summary>
        ///     Creates a RegexValidationRule with the specified regular expression.
        /// </summary>
        /// <param name="regexPattern">The regular expression used by the new instance.</param>
        public LocRegexValidationRule([NotNull] string regexPattern)
        {
            this.RegexPattern = regexPattern ?? throw new ArgumentNullException(nameof(regexPattern));
        }

        /// <summary>
        ///     Creates a RegexValidationRule with the specified regular expression
        ///     and error message.
        /// </summary>
        /// <param name="regexPattern">The regular expression used by the new instance.</param>
        /// <param name="errorMessage">The error message used when validation fails.</param>
        public LocRegexValidationRule(string regexPattern, [NotNull] string errorMessage)
            : this(regexPattern)
        {
            this.ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));
        }

        /// <summary>
        ///     Creates a RegexValidationRule with the specified regular expression,
        ///     error message, and RegexOptions.
        /// </summary>
        /// <param name="regexPattern">The regular expression used by the new instance.</param>
        /// <param name="errorMessage">The error message used when validation fails.</param>
        /// <param name="regexOptions">The RegexOptions used by the new instance.</param>
        public LocRegexValidationRule(string regexPattern, string errorMessage, RegexOptions regexOptions)
            : this(regexPattern)
        {
            this.ErrorMessage = errorMessage;
            this.RegexOptions = regexOptions;
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets/sets the error message to be used when validation fails.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets/sets the RegexOptions to be used during validation.
        ///     This property's default value is 'None'.
        /// </summary>
        public RegexOptions RegexOptions { get; set; } = RegexOptions.None;

        /// <summary>
        ///     Gets/sets the regular expression used during validation.
        /// </summary>
        public string RegexPattern { get; set; }

        /// <summary>
        ///     Validates the 'value' argument using the regular
        ///     expression and RegexOptions associated with this object.
        /// </summary>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = ValidationResult.ValidResult;

            // If there is no regular expression to evaluate,
            // then the data is considered to be valid.
            if (string.IsNullOrEmpty(this.RegexPattern))
            {
                return result;
            }

            // Cast the input value to a string (null becomes empty string).
            var text = value as string ?? string.Empty;

            // If the string does not match the regex, return a value
            // which indicates failure and provide an error mesasge.
            if (!Regex.IsMatch(text, this.RegexPattern, this.RegexOptions))
            {
                result = new ValidationRuleLocError(this.ErrorMessage, this.TextKey).ToValidationResult();
            }

            return result;
        }

        public string TextKey { get; set; }
    }
}