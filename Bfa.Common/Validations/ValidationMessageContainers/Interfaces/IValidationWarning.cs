// -----------------------------------------------------------------------
// <copyright file="IValidationWarning.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers.Interfaces
{
    using Bfa.Common.Validations.Markers;

    /// <summary>
    /// Validation Warning Interface
    /// </summary>
    public interface IValidationWarning : IValidationMessage , IWarning

    {
    }
}