// -----------------------------------------------------------------------
// <copyright file="MaxLengthRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;

    using Bfa.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    /// <seealso cref="PropertyValidationRule{TProperty}" />
    public class ToUpperRule : PropertyValidationRule<string>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxRangeRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public ToUpperRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName, propertyName)
        {
        }

        public override PropertyValidationResult Validate(ref object value, object model)
        {
            value = ((string)value).ToUpper();
            return base.Validate(ref value, model);
        }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override PropertyValidationResult Validate(string value)
        {
            return this.ValidResult;
        }
    }
}