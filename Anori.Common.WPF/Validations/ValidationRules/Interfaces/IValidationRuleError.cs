// -----------------------------------------------------------------------
// <copyright file="IValidationRuleError.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules.Interfaces
{
    using Anori.Common.Validations.Markers;

    /// <summary>
    ///     Validation Error Interface
    /// </summary>
    /// <seealso cref="IValidationRuleMessage" />
    public interface IValidationRuleError : IValidationRuleMessage, IError
    {
    }
}