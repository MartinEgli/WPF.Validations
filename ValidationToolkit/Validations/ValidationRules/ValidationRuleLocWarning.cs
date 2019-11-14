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

    public class ValidationRuleLocWarning : ValidationRuleWarning, ILocalizationTextKeyAware

    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRuleWarning" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationRuleLocWarning([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase textKey)
            : base(message)
        {
            this.TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
        }

        public string TextKey { get; }
    }
}