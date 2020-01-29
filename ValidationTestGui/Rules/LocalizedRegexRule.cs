// -----------------------------------------------------------------------
// <copyright file="LocalizedRegexRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
{
    using System;

    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// The localized regex rule
    /// </summary>
    /// <seealso cref="Anori.Common.WPF.Validations.ValidationTestGui.Rules.RegexRule" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocalizedRegexRule : RegexRule, ILocalizationTextKeyAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedRegexRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="textKey">The text key.</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public LocalizedRegexRule(
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            [NotNull] FullyQualifiedResourceKeyBase textKey)
            : base(ruleName, propertyName)
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