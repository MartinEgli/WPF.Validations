// -----------------------------------------------------------------------
// <copyright file="MaxLengthRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System;

    using Anori.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// To upper rule
    /// </summary>
    /// <seealso cref="PropertyValidationRule{string}" />
    public class ToUpperRule : PropertyValidationRule<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToUpperRule"/> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        public ToUpperRule([NotNull] string ruleName, [NotNull] string propertyName)
            : base(ruleName, propertyName)
        {
        }

        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
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
        public override PropertyValidationResult Validate(string value) => this.ValidResult;
    }
}