// -----------------------------------------------------------------------
// <copyright file="LocModelValidationResult.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System;

    using Anori.Common.Validations.Validators;
    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    /// The loc model validation result
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.Validators.ModelValidationResult" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocModelValidationResult : ModelValidationResult, ILocalizationTextKeyAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocModelValidationResult" /> class.
        /// </summary>
        /// <param name="isValid">if set to <c>true</c> [is valid].</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public LocModelValidationResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string message,
            [NotNull] string textKey,
            bool isWarning = false)
            : base(isValid, ruleName, message, isWarning)
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