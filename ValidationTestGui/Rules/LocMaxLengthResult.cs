// -----------------------------------------------------------------------
// <copyright file="LocMaxLengthResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System;

    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    /// The loc maximum length result
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.Rules.MaxLengthResult" />
    /// <seealso cref="Bfa.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocMaxLengthResult : MaxLengthResult, ILocalizationTextKeyAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocMaxLengthResult"/> class.
        /// </summary>
        /// <param name="isValid">if set to <c>true</c> [is valid].</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="textKey">The text key.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="message">The message.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        public LocMaxLengthResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            [NotNull] string textKey,
            int maxLength,
            [NotNull] string message,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, maxLength, message, isWarning)
        {
            this.TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
        }

        /// <summary>
        /// Gets the text key.
        /// </summary>
        /// <value>
        /// The text key.
        /// </value>
        public string TextKey { get; }
    }
}