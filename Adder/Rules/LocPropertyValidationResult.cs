// -----------------------------------------------------------------------
// <copyright file="LocPropertyValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    public class LocPropertyValidationResult : PropertyValidationResult, ILocalizationTextKeyAware
    {
        public LocPropertyValidationResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            [NotNull] string message,
            FullyQualifiedResourceKeyBase textKey,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, message, isWarning)
        {
            this.TextKey = textKey;
        }

        public string TextKey { get; }
    }
}