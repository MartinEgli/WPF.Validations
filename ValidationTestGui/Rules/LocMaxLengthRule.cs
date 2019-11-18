﻿// -----------------------------------------------------------------------
// <copyright file="LocMaxLengthRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Localizations;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;

    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    /// <seealso cref="PropertyValidationRule{TProperty}" />
    public class LocMaxLengthRule : PropertyValidationRule<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocMaxLengthRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="maxLength">The maximum length.</param>
        public LocMaxLengthRule([NotNull] string ruleName, [NotNull] string propertyName, int maxLength)
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
                return new LocMaxLengthResult(
                    false,
                    this.RuleName,
                    this.PropertyName,
                    new LanguageKey("MaxLength", "Group1", "Source1").ToString(),
                    this.MaxLength,
                    this.PropertyName + " length is mor then " + this.MaxLength + ".");
            }

            return this.ValidResult;
        }
    }
}