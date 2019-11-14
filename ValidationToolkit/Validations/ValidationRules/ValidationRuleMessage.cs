// -----------------------------------------------------------------------
// <copyright file="ValidationRuleMessage.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules
{
    using System;
    using System.Windows.Controls;

    using Bfa.Common.Binders;
    using Bfa.Common.WPF.Validations.ValidationRules.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The abstract ValidationMessageBase class.
    /// </summary>
    public abstract class ValidationRuleMessage : Bindable, IValidationRuleMessage
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
        [NotNull]
        public string Message { get; }

        /// <summary>
        ///     To the content.
        /// </summary>
        /// <returns></returns>
        protected virtual object ToContent()
        {
            return this;
        }

        /// <summary>
        ///     To the validation result.
        /// </summary>
        /// <returns></returns>
        public virtual ValidationResult ToValidationResult()
        {
            return new ValidationResult(false, this.ToContent());
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [NotNull]
        public override string ToString()
        {
            return this.Message;
        }

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
        ///     Equalses the specified other.
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
        public override int GetHashCode()
        {
            return this.Message.GetHashCode();
        }
    }
}