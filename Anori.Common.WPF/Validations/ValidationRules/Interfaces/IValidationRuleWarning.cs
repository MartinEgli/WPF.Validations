// -----------------------------------------------------------------------
// <copyright file="IValidationRuleWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationRules.Interfaces
{
    using Anori.Common.Validations.Markers;

    /// <summary>
    ///     Validation Warning Interface
    /// </summary>
    /// <seealso cref="IValidationRuleMessage" />
    public interface IValidationRuleWarning : IValidationRuleMessage, IWarning
    {
    }
}