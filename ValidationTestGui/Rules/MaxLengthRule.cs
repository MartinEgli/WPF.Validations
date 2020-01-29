// -----------------------------------------------------------------------
// <copyright file="MaxLengthRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using System;

    using Anori.Common.Validations.Validators;
    using Anori.Common.WPF.Validations.ValidationTestGui.Rules;

    using JetBrains.Annotations;

    /// <summary>
    /// The maximum length rule
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.Validators.PropertyValidationRule{System.String}" />
    /// <seealso cref="PropertyValidationRule{TProperty}" />
    public class MaxLengthRule : PropertyValidationRule<string>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxRangeRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public MaxLengthRule([NotNull] string ruleName, [NotNull] string propertyName, int maxLength)
            : base(ruleName, propertyName)
        {
            this.MaxLength = maxLength;
        }

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public int MaxLength { get; }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override PropertyValidationResult Validate(string value)
        {
            if (value == null)
            {
                return this.ValidResult;
            }

            var length = value.Length;
            if (length > this.MaxLength)
            {
                return new MaxLengthResult(
                    false,
                    this.RuleName,
                    this.PropertyName,
                    this.MaxLength,
                    this.PropertyName + " length is mor then " + this.MaxLength + ".");
            }

            return this.ValidResult;
        }
    }
}