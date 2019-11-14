// -----------------------------------------------------------------------
// <copyright file="LocException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Exceptions
{
    using System;

    using Bfa.Common.Validations.Validators.Interfaces;

    using WPFLocalizeExtension.Providers;

    public class LocException : Exception, ILocalizationTextKeyAware
    {
        public LocException(string message, FullyQualifiedResourceKeyBase key)
            : base(message)
        {
            this.TextKey = key;
        }

        public LocException(string message, FullyQualifiedResourceKeyBase key, Exception innerException)
            : base(message, innerException)
        {
            this.TextKey = key;
        }

        public string TextKey { get; }
    }
}