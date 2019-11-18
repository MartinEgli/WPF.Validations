// -----------------------------------------------------------------------
// <copyright file="ValidationRuleLocWarning.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules
{
    using System;

    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// The validation rule loc warning
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationRules.ValidationRuleWarning" />
    /// <seealso cref="Bfa.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class ValidationRuleLocWarning : ValidationRuleWarning, ILocalizationTextKeyAware

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleWarning" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public ValidationRuleLocWarning([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase textKey)
            : base(message)
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