// -----------------------------------------------------------------------
// <copyright file="LocPropertyValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// The loc property validation result
    /// </summary>
    /// <seealso cref="Bfa.Common.Validations.Validators.PropertyValidationResult" />
    /// <seealso cref="Bfa.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocPropertyValidationResult : PropertyValidationResult, ILocalizationTextKeyAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocPropertyValidationResult"/> class.
        /// </summary>
        /// <param name="isValid">if set to <c>true</c> [is valid].</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        public LocPropertyValidationResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            [NotNull] string message,
            [NotNull] FullyQualifiedResourceKeyBase textKey,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, message, isWarning)
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