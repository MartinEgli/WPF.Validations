// -----------------------------------------------------------------------
// <copyright file="IValidationError.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Interfaces
{
    using Anori.Common.Validations.Markers;

    /// <summary>
    ///     Validation Error Interface
    /// </summary>
    public interface IValidationError : IValidationMessage, IError
    {
    }
}