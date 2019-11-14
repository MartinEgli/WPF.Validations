// -----------------------------------------------------------------------
// <copyright file="IValidationError.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers.Interfaces
{
    using Bfa.Common.Validations.Markers;

    /// <summary>
    ///     Validation Error Interface
    /// </summary>
    public interface IValidationError : IValidationMessage, IError
    {
    }
}