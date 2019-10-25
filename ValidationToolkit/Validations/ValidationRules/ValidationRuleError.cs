// -----------------------------------------------------------------------
// <copyright file="ValidationRuleError.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules
{
    using Bfa.Common.WPF.Validations.ValidationRules.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The ValidationWarning class.
    /// </summary>
    /// <seealso cref="ValidationRuleMessage" />
    /// <seealso cref="IValidationRuleError" />
    public class ValidationRuleError : ValidationRuleMessage, IValidationRuleError
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleError" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationRuleError([NotNull] string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Message;
        }
    }
}