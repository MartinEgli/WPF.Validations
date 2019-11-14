// -----------------------------------------------------------------------
// <copyright file="IValidationWarning.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Markers
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