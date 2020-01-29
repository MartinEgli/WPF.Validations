// -----------------------------------------------------------------------
// <copyright file="ValidationRuleValid.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules
{
    using System.Windows.Controls;

    using Anori.Common.WPF.Validations.ValidationRules.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The ValidationWarning class.
    /// </summary>
    /// <seealso cref="ValidationRuleMessage" />
    /// <seealso cref="IValidationRuleValid" />
    public class ValidationRuleValid : ValidationRuleMessage, IValidationRuleValid
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleValid" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ValidationRuleValid([NotNull] string message)
            : base(message)
        {
        }

        /// <summary>
        ///     To the validation result.
        /// </summary>
        /// <returns></returns>
        public override ValidationResult ToValidationResult() => new ValidationResult(true, this.ToContent());

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.Message;
    }
}