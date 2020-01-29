// -----------------------------------------------------------------------
// <copyright file="ValidatorRules.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using System;
    using System.Collections.Generic;

    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;
    using Anori.Common.Validations.Validators.Interfaces;

    /// <summary>
    ///     ValidatorRules class.
    /// </summary>
    /// <seealso cref="IValidatorRules" />
    internal class ValidatorRules : IValidatorRules
    {
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
        ///     Gets the rule mapping.
        /// </summary>
        /// <value>
        ///     The rule mapping.
        /// </value>
        public List<string> RuleMapping { get; } = new List<string>();

        /// <summary>
        ///     Gets the rules.
        /// </summary>
        /// <propertyValue>
        ///     The rules.
        /// </propertyValue>
        public Dictionary<string, PropertyValidationRuleCollection> PropertyRules { get; } =
            new Dictionary<string, PropertyValidationRuleCollection>();

        public Watchers Watchers { get; } = new Watchers();

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
            ref object propertyValue,
            object model,
            IValidationMessageContainer container)
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

            if (!this.CancelPropertyRules.TryGetValue(propertyName, out var propertyValidationRuleCollection))
            {
                return true;
            }

            var isValid = true;
            foreach (var validationRule in propertyValidationRuleCollection)
            {
                var validationResult = validationRule.Validate(ref propertyValue, model);
                isValid &= container.UpdateError(validationResult);
            }

            return isValid;
        }

        /// <summary>
        ///     Validates the cancel property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     groupName
        /// </exception>
        public bool ValidateCancelProperty(
            string propertyName,
            string groupName,
            ref object propertyValue,
            object model,
            IValidationMessageContainer container)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            return this.ValidateCancelProperty(propertyName + ":" + groupName, ref propertyValue, model, container);
        }

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
        public bool ValidateModel(object model, IValidationMessageContainer container)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (!this.ModuleRules.TryGetValue("Default", out var modelValidationRuleCollection))
            {
                return true;
            }

            var isValid = true;

            foreach (var validationRule in modelValidationRuleCollection)
            {
                var result = validationRule.Validate(model);
                var target = validationRule.Target;
                if (target == null)
                {
                    isValid &= container.UpdateError(result);
                }
                else
                {
                    isValid &= container.UpdateError(result, target);
                }
            }

            return isValid;
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="model">The model.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     groupName
        /// </exception>
        public bool ValidateProperty(
            string propertyName,
            string groupName,
            ref object propertyValue,
            object model,
            IValidationMessageContainer container)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            return this.ValidateProperty(propertyName + ":" + groupName, ref propertyValue, model, container);
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
            ref object propertyValue,
            object model,
            IValidationMessageContainer container)
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
                var result = validationRule.Validate(ref propertyValue, model);
                isValid &= container.UpdateError(result);
            }

            return isValid;
        }
    }
}