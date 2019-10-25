// -----------------------------------------------------------------------
// <copyright file="ValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     Validation Result class.
    /// </summary>
    public abstract class ValidationResult
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        protected ValidationResult(bool isValid, [NotNull] string ruleName, [NotNull] string message, bool isWarning)
        {
            this.IsWarning = isWarning;
            this.IsValid = isValid;
            this.RuleName = ruleName ?? throw new ArgumentNullException(nameof(ruleName));
            this.Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Gets a value indicating whether this instance is warning.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is warning; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarning { get; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string RuleName { get; }

        /// <summary>
        ///     Whether or not the ValidationRule that was checked is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        ///     Compares the parameters for value equality
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        /// <returns>true if the values are equal</returns>
        public static bool operator ==(ValidationResult left, ValidationResult right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Compares the parameters for value inequality
        /// </summary>
        /// <param name="left">left operand</param>
        /// <param name="right">right operand</param>
        /// <returns>true if the values are not equal</returns>
        public static bool operator !=(ValidationResult left, ValidationResult right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     By-value comparison of ValidationResult
        /// </summary>
        /// <remarks>
        ///     This method is also used indirectly from the operator overrides.
        /// </remarks>
        /// <param name="obj">ValidationResult to be compared against this ValidationRule</param>
        /// <returns>true if obj is ValidationResult and has the same values</returns>
        public override bool Equals(object obj)
        {
            // A cheaper alternative to Object.ReferenceEquals() is used here for better perf
            if (obj == this)
            {
                return true;
            }

            var vr = obj as ValidationResult;
            if (vr != null)
            {
                return (this.IsValid == vr.IsValid) && (this.RuleName == vr.RuleName);
            }

            return false;
        }

        /// <summary>
        ///     Hash function for ValidationResult
        /// </summary>
        /// <returns>hash code for the current ValidationResult</returns>
        public override int GetHashCode()
        {
            return this.IsValid.GetHashCode() ^ this.RuleName.GetHashCode();
        }
    }
}