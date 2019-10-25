// -----------------------------------------------------------------------
// <copyright file="IValidatorRules.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators.Interfaces
{
    using System.Collections.Generic;

    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     IValidatorRules class.
    /// </summary>
    internal interface IValidatorRules
    {
        /// <summary>
        ///     Gets the property rules.
        /// </summary>
        /// <value>
        ///     The property rules.
        /// </value>
        [NotNull]
        Dictionary<string, PropertyValidationRuleCollection> PropertyRules { get; }

        /// <summary>
        ///     Gets the cancel property rules.
        /// </summary>
        /// <value>
        ///     The cancel property rules.
        /// </value>
        [NotNull]
        Dictionary<string, PropertyValidationRuleCollection> CancelPropertyRules { get; }

        /// <summary>
        ///     Gets the module rules.
        /// </summary>
        /// <value>
        ///     The module rules.
        /// </value>
        [NotNull]
        Dictionary<string, ModelValidationRuleCollection> ModuleRules { get; }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        bool ValidateProperty(
            [NotNull] string propertyName,
            [CanBeNull] object propertyValue,
            [NotNull] object model,
            [NotNull] IValidationMessageContainer container);

        /// <summary>
        ///     Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        bool ValidateModel([NotNull] object model, [NotNull] IValidationMessageContainer container);

        /// <summary>
        ///     Validates the cancel property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        bool ValidateCancelProperty(
            [NotNull] string propertyName,
            [CanBeNull] object propertyValue,
            [NotNull] object model,
            [NotNull] IValidationMessageContainer container);
    }
}