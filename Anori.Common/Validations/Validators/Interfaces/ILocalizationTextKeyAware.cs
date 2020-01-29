// -----------------------------------------------------------------------
// <copyright file="ILocalizationTextKeyAware.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators.Interfaces
{
    using JetBrains.Annotations;

    public interface ILocalizationTextKeyAware
    {
        [NotNull]
        string TextKey { get; }
    }
}