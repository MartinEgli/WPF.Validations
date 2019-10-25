// -----------------------------------------------------------------------
// <copyright file="ValidatorBuilder.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using System;
    using System.ComponentModel;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidatorBuilder class.
    /// </summary>
    public class ValidatorBuilder<TModel>
        where TModel : INotifyPropertyChanging, INotifyPropertyChanged

    {
        /// <summary>
        ///     The default group name
        /// </summary>
        public const string DefaultGroupName = "Default";

        /// <summary>
        ///     The rules
        /// </summary>
        private readonly ValidatorRules rules = new ValidatorRules();

        /// <summary>
        ///     Builds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Validator<TModel> Build([NotNull] TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Validator<TModel>(model, this.rules);
        }

        /// <summary>
        ///     Adds the rule.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="rule">The rule.</param>
        /// <param name="isCancel">if set to <c>true</c> [is cancel].</param>
        /// <exception cref="ArgumentNullException">groupName</exception>
        public void AddRule(
            [NotNull] string propertyName,
            [NotNull] string groupName,
            [NotNull] PropertyValidationRule rule,
            bool isCancel = false)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            this.AddRule(propertyName + ":" + groupName, rule, isCancel);
        }

        /// <summary>
        ///     Adds the rule.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="rule">The rule.</param>
        /// <exception cref="ArgumentNullException">
        ///     groupName
        ///     or
        ///     rule
        /// </exception>
        public void AddRule([NotNull] string groupName, [NotNull] ModelValidationRule rule)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            if (!this.rules.ModuleRules.TryGetValue(groupName, out var validationRules))
            {
                validationRules = new ModelValidationRuleCollection();

                this.rules.ModuleRules.Add(groupName, validationRules);
            }

            validationRules.Add(rule);
        }

        /// <summary>
        ///     Adds the rule.
        /// </summary>
        /// <param name="rule">The rule.</param>
        public void AddRule([NotNull] ModelValidationRule rule)
        {
            this.AddRule(DefaultGroupName, rule);
        }

        /// <summary>
        ///     Adds the rule.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="rule">The rule.</param>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     rule
        /// </exception>
        public void AddRule([NotNull] string propertyName, [NotNull] PropertyValidationRule rule, bool isCancel = false)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            if (isCancel)
            {
                if (!this.rules.CancelPropertyRules.TryGetValue(propertyName, out var validationRules))
                {
                    validationRules = new PropertyValidationRuleCollection();

                    this.rules.CancelPropertyRules.Add(propertyName, validationRules);
                }

                validationRules.Add(rule);
            }
            else
            {
                if (!this.rules.PropertyRules.TryGetValue(propertyName, out var validationRules))
                {
                    validationRules = new PropertyValidationRuleCollection();

                    this.rules.PropertyRules.Add(propertyName, validationRules);
                }

                validationRules.Add(rule);
            }
        }
    }
}