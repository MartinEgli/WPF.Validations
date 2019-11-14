// -----------------------------------------------------------------------
// <copyright file="LocalizedRegexRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    public class LocalizedRegexRule : RegexRule, ILocalizationTextKeyAware
    {
        public LocalizedRegexRule(
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            FullyQualifiedResourceKeyBase textKey)
            : base(ruleName, propertyName)
        {
            this.TextKey = textKey;
        }

        public string TextKey { get; }
    }
}