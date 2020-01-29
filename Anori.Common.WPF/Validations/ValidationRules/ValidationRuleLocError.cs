// -----------------------------------------------------------------------
// <copyright file="ValidationRuleLocError.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules
{
    using System;

    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    public class ValidationRuleLocError : ValidationRuleError, ILocalizationTextKeyAware

    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleWarning" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationRuleLocError([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase textKey)
            : base(message)
        {
            this.TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleLocError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public ValidationRuleLocError([NotNull] string message, [NotNull] string textKey)
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