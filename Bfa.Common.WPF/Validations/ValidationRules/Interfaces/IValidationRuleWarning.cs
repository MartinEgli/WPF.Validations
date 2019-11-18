// -----------------------------------------------------------------------
// <copyright file="IValidationRuleWarning.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules.Interfaces
{
    using Bfa.Common.Validations.Markers;

    /// <summary>
    ///     Validation Warning Interface
    /// </summary>
    /// <seealso cref="IValidationRuleMessage" />
    public interface IValidationRuleWarning : IValidationRuleMessage, IWarning
    {
    }
}