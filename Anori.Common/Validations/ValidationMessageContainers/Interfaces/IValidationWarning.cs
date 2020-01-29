// -----------------------------------------------------------------------
// <copyright file="IValidationWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Interfaces
{
    using Anori.Common.Validations.Markers;

    /// <summary>
    /// Validation Warning Interface
    /// </summary>
    public interface IValidationWarning : IValidationMessage , IWarning

    {
    }
}