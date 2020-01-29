// -----------------------------------------------------------------------
// <copyright file="ValidationRuleLocWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules
{
    using System;

    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// The validation rule loc warning
    /// </summary>
    /// <seealso cref="Anori.Common.WPF.Validations.ValidationRules.ValidationRuleWarning" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
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