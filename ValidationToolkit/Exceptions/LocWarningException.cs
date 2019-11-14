// -----------------------------------------------------------------------
// <copyright file="LocWarningException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Exceptions
{
    using System.ComponentModel;

    using Bfa.Common.Validations.Validators.Interfaces;

    using WPFLocalizeExtension.Providers;

    public class LocWarningException : WarningException, ILocalizationTextKeyAware
    {
        public LocWarningException(string message, FullyQualifiedResourceKeyBase key)
            : base(message)
        {
            this.TextKey = key;
        }

        public string TextKey { get; }
    }
}