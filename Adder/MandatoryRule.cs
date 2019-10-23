// -----------------------------------------------------------------------
// <copyright file="MandatoryRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Validations;

    /// <summary>
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.PropertyValidationRule{System.Double?}" />
    public class MandatoryRule : PropertyValidationRule<double?>
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
        public override PropertyValidationResult Validate(double? value)
        {
            if (!value.HasValue)
            {
                return new PropertyValidationResult(
                    false,
                    this.RuleName,
                    this.PropertyName,
                    this.PropertyName + " is mandatory.");
            }

            return this.ValidResult;
        }
    }
}