// -----------------------------------------------------------------------
// <copyright file="ValidationRuleMessage.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules
{
    using System;
    using System.Windows.Controls;

    using Anori.Common.WPF.Validations.ValidationRules.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The abstract ValidationMessageBase class.
    /// </summary>
    public abstract class ValidationRuleMessage : IValidationRuleMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleMessage" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        protected ValidationRuleMessage([NotNull] string message)
        {
            this.Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; }

        /// <summary>
        ///     To the content.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        protected virtual object ToContent() => this;

        /// <summary>
        ///     To the validation result.
        /// </summary>
        /// <returns></returns>
        public virtual ValidationResult ToValidationResult() => new ValidationResult(false, this.ToContent());

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.Message;

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is IValidationRuleMessage other))
            {
                return false;
            }

            return this.Equals(other);
        }

        /// <summary>
        ///     Equals the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public virtual bool Equals(IValidationRuleMessage other)
        {
            if (other == null)
            {
                return false;
            }

            return (this.Message == other.Message);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => this.Message.GetHashCode();
    }
}