// -----------------------------------------------------------------------
// <copyright file="LocModelValidationResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    public class LocModelValidationResult : ModelValidationResult, ILocalizationTextKeyAware
    {
        public LocModelValidationResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string message,
            bool isWarning = false)
            : base(isValid, ruleName, message, isWarning)
        {
        }

        public string TextKey { get; }
    }
}