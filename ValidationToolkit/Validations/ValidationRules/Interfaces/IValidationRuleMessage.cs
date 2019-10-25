// -----------------------------------------------------------------------
// <copyright file="IValidationMessage.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules.Interfaces
{
    using System.Windows.Controls;

    /// <summary>
    /// Validation Message Interface
    /// </summary>
    public interface IValidationRuleMessage
    {
        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        string Message { get; }

        /// <summary>
        /// To the validation result.
        /// </summary>
        /// <returns></returns>
        ValidationResult ToValidationResult();

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}