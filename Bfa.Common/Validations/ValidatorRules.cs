// -----------------------------------------------------------------------
// <copyright file="ValidatorRules.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;
    using System.Collections.Generic;

    using Bfa.Common.WPF.Validations.ValidationTestGui;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidatorRules class.
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.IValidatorRules" />
    internal class ValidatorRules : IValidatorRules
    {
        /// <summary>
        ///     Gets the rules.
        /// </summary>
        /// <propertyValue>
        ///     The rules.
        /// </propertyValue>
        public Dictionary<string, PropertyValidationRuleCollection> PropertyRules { get; } =
            new Dictionary<string, PropertyValidationRuleCollection>();

        /// <summary>
        ///     Gets the property cancel rules.
        /// </summary>
        /// <value>
        ///     The property cancel rules.
        /// </value>
        public Dictionary<string, PropertyValidationRuleCollection> CancelPropertyRules { get; } =
            new Dictionary<string, PropertyValidationRuleCollection>();

        /// <summary>
        ///     Gets the module rules.
        /// </summary>
        /// <propertyValue>
        ///     The module rules.
        /// </propertyValue>
        public Dictionary<string, ModelValidationRuleCollection> ModuleRules { get; } =
            new Dictionary<string, ModelValidationRuleCollection>();

        /// <summary>
        ///     Validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <exception cref="ArgumentNullException">
        ///     model
        ///     or
        ///     container
        /// </exception>
        public bool ValidateModel(object model, IValidationErrorContainer container)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (!this.ModuleRules.TryGetValue("*", out var modelValidationRuleCollection))
            {
                return true;
            }

            var isValid = true;

            foreach (var validationRule in modelValidationRuleCollection)
            {
                var result = validationRule.Validate(model);
                isValid &= container.UpdateError(result);
            }

            return isValid;
        }

        /// <summary>
        ///     Validates the propertyName.
        /// </summary>
        /// <param name="propertyName">The propertyName.</param>
        /// <param name="propertyValue">The propertyValue.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     model
        ///     or
        ///     container
        /// </exception>
        public bool ValidateCancelProperty(
            string propertyName,
            object propertyValue,
            object model,
            [NotNull] IValidationErrorContainer container)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (!this.PropertyRules.TryGetValue(propertyName, out var propertyValidationRuleCollection))
            {
                return true;
            }

            var isValid = true;
            foreach (var validationRule in propertyValidationRuleCollection)
            {
                var validationResult = validationRule.Validate(propertyValue, model);
                isValid &= container.UpdateError(validationResult);
            }

            return isValid;
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     model
        ///     or
        ///     container
        /// </exception>
        public bool ValidateProperty(
            string propertyName,
            object propertyValue,
            object model,
            IValidationErrorContainer container)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (!this.PropertyRules.TryGetValue(propertyName, out var propertyValidationRuleCollection))
            {
                return true;
            }

            var isValid = true;
            foreach (var validationRule in propertyValidationRuleCollection)
            {
                var result = validationRule.Validate(propertyValue, model);
                isValid &= container.UpdateError(result);
            }

            return isValid;
        }
    }
}