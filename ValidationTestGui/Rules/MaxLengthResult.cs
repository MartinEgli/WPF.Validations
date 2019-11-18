// -----------------------------------------------------------------------
// <copyright file="MaxLengthResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System.Text;

    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;
    using Bfa.Common.Validations.Validators;

    using JetBrains.Annotations;

    /// <summary>
    /// The maximum length result
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.Validators.PropertyValidationResult" />
    /// <seealso cref="Bfa.Common.Validations.ValidationMessageContainers.Interfaces.IValidationMessage" />
    public class MaxLengthResult : PropertyValidationResult, IValidationMessage
    {
        public MaxLengthResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            int maxLength,
            [NotNull] string message,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, message, isWarning)
        {
            this.MaxLength = maxLength;
        }

        /// <summary>
        /// Gets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public int MaxLength { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id => this.RuleName;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description =>
            new StringBuilder().Append("Property Name='")
                .Append(this.PropertyName)
                .Append("', Id='")
                .Append(this.Id)
                .Append("', Message='")
                .Append(this.Message)
                .Append("'")
                .ToString();
    }
}