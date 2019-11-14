// -----------------------------------------------------------------------
// <copyright file="ILocalizationTextKeyAware.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators.Interfaces
{
    using JetBrains.Annotations;

    public interface ILocalizationTextKeyAware
    {
        [NotNull]
        string TextKey { get; }
    }
}