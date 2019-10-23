// -----------------------------------------------------------------------
// <copyright file="ValidatorBuilder.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;
    using System.ComponentModel;

    using Bfa.Common.Validations;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidatorBuilder class.
    /// </summary>
    public class ValidatorBuilder<TModel>
        where TModel : INotifyPropertyChanging, INotifyPropertyChanged

    {
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
        /// Adds the rule.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="rule">The rule.</param>
        /// <exception cref="ArgumentNullException">groupName</exception>
        public void AddRule(
            [NotNull] string propertyName,
            [NotNull] string groupName,
            [NotNull] PropertyValidationRule rule)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            this.AddRule(propertyName + ":" + groupName, rule);
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
        public void AddRule([NotNull] string propertyName, [NotNull] PropertyValidationRule rule)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            if (!this.rules.PropertyRules.TryGetValue(propertyName, out var validationRules))
            {
                validationRules = new PropertyValidationRuleCollection();
                this.rules.PropertyRules.Add(propertyName, validationRules);
            }

            validationRules.Add(rule);
        }
    }
}