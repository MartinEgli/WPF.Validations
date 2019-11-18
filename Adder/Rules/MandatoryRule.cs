// -----------------------------------------------------------------------
// <copyright file="MandatoryRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Validations.Validators;

    /// <summary>
    /// </summary>
    public class MandatoryRule : PropertyValidationRule<object>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MandatoryRule" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public MandatoryRule(string propertyName)
            : base("Mandatory", propertyName)
        {
        }

        /// <summary>
        ///     Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override PropertyValidationResult Validate(object value)
        {
            switch (value)
            {
                case null:
                    return new PropertyValidationResult(
                        false,
                        this.RuleName,
                        this.PropertyName,
                        this.PropertyName + " is Mandatory (Not null).",
                        true);

                case string s when string.IsNullOrEmpty(s):
                    return new PropertyValidationResult(
                        false,
                        this.RuleName,
                        this.PropertyName,
                        this.PropertyName + " is Mandatory (Not empty string).",
                        true);

                default:
                    return this.ValidResult;
            }
        }
    }
}