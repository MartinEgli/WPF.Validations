// -----------------------------------------------------------------------
// <copyright file="ValidationRuleWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules
{
    using Anori.Common.WPF.Validations.ValidationRules.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The ValidationWarning class.
    /// </summary>
    /// <seealso cref="ValidationRuleMessage" />
    /// <seealso cref="IValidationRuleWarning" />
    public class ValidationRuleWarning : ValidationRuleMessage, IValidationRuleWarning
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleWarning" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationRuleWarning([NotNull] string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.Message;
    }
}