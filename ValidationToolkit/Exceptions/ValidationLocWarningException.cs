// -----------------------------------------------------------------------
// <copyright file="ValidationLocWarningException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Exceptions
{
    using Bfa.Common.Validations.Validators.Interfaces;
    using Bfa.Common.WPF.Validations.ValidationRules;

    using WPFLocalizeExtension.Providers;

    public class ValidationLocWarningException : ValidationWarningException, ILocalizationTextKeyAware
    {
        public ValidationLocWarningException(string message, FullyQualifiedResourceKeyBase key)
            : base(message)
        {
            this.TextKey = key;
        }

        public string TextKey { get; }
    }
}