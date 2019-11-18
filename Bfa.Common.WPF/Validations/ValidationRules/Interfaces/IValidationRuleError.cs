// -----------------------------------------------------------------------
// <copyright file="IValidationRuleError.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules.Interfaces
{
    using Bfa.Common.Validations.Markers;

    /// <summary>
    ///     Validation Error Interface
    /// </summary>
    /// <seealso cref="IValidationRuleMessage" />
    public interface IValidationRuleError : IValidationRuleMessage, IError
    {
    }
}