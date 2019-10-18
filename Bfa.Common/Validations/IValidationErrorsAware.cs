// -----------------------------------------------------------------------
// <copyright file="IValidationErrorsAware.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ValidationToolkit
{
    using Bfa.Common.Validations;

    public interface IValidationErrorsAware
    {
        IValidationErrorContainer ValidationErrors { get; }
    }
}