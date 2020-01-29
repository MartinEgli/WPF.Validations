// -----------------------------------------------------------------------
// <copyright file="IValidationWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Markers
{
    /// <summary>
    /// Warning Interface
    /// </summary>
    public interface IWarning : IMarker

    {
    }

    /// <summary>
    ///  Marker Interface
    /// </summary>
    public interface IMarker
    {
    }

    public interface IError : IMarker

    {
    }
}