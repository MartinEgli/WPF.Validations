// -----------------------------------------------------------------------
// <copyright file="Validator.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using System;
    using System.ComponentModel;

    using Anori.Common.Binders;
    using Anori.Common.Validations.ValidationMessageContainers;
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    /// <summary>
    ///     Generic Validator class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="IValidationMessagesAware" />
    public class Validator<TModel> : Validator
        where TModel : INotifyPropertyChanging, INotifyPropertyChanged
    {
        /// <summary>
        ///     The model
        /// </summary>
        private readonly TModel model;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Validator{TModel}" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="rules">The rules.</param>
        internal Validator([NotNull] TModel model, [NotNull] ValidatorRules rules)
            : this(model, rules, new ValidationMessageContainer())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Validator{TModel}" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="rules">The rules.</param>
        /// <param name="validationMessages">The validation errors.</param>
        /// <exception cref="ArgumentNullException">
        ///     model
        ///     or
        ///     rules
        /// </exception>
        internal Validator(
            [NotNull] TModel model,
            [NotNull] ValidatorRules rules,
            [NotNull] IValidationMessageContainer validationMessages)
            : base(validationMessages)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            this.model = model;
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
            rules.Watchers.RegisterValidator(this);

            model.PropertyChanging += this.OnPropertyChanging;
            model.PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        ///     Gets the rules.
        /// </summary>
        /// <value>
        ///     The rules.
        /// </value>
        internal ValidatorRules Rules { get; }

        /// <summary>
        ///     Called when [property changing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangingEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (!(e is PropertyChangingCancelObjectEventArgs args))
            {
                return;
            }

            var value = args.NewObject;
            args.Cancel = !this.Rules.ValidateCancelProperty(
                              e.PropertyName,
                              ref value,
                              this.model,
                              this.ValidationMessages);

            args.NewObject = value;
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(e is Anori.Common.Binders.PropertyChangedEventArgs args))
            {
                return;
            }

            var value = args.CurrentObject;

            this.Rules.ValidateProperty(e.PropertyName, ref value, this.model, this.ValidationMessages);

            if (this.Rules.RuleMapping.Contains(e.PropertyName))
            {
                this.Validate();
            }
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return this.Rules.ValidateModel(this.model, this.ValidationMessages);
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">propertyName</exception>
        public bool ValidateProperty([NotNull] string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            var type = this.model.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            if (null == propertyInfo)
            {
                return false;
            }

            var value = propertyInfo.GetValue(this, null);
            var isValid = this.Rules.ValidateCancelProperty(
                propertyName,
                ref value,
                this.model,
                this.ValidationMessages);
            isValid &= this.Rules.ValidateProperty(propertyName, ref value, this.model, this.ValidationMessages);
            if (this.Rules.RuleMapping.Contains(propertyName))
            {
                this.Validate();
            }

            return isValid;
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     groupName
        /// </exception>
        public bool ValidateProperty([NotNull] string propertyName, [NotNull] string groupName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            var type = this.model.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            if (null == propertyInfo)
            {
                return false;
            }

            var value = propertyInfo.GetValue(this.model, null);
            var isValid = this.Rules.ValidateCancelProperty(
                propertyName,
                groupName,
                ref value,
                this.model,
                this.ValidationMessages);
            isValid &= this.Rules.ValidateProperty(
                propertyName,
                groupName,
                ref value,
                this.model,
                this.ValidationMessages);
            if (this.Rules.RuleMapping.Contains(propertyName + ":" + groupName))
            {
                this.Validate();
            }

            return isValid;
        }
    }

    /// <summary>
    ///     The validator
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.Validators.Validator" />
    public abstract class Validator : IValidationMessagesAware
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Validator" /> class.
        /// </summary>
        /// <param name="validationMessages">The validation messages.</param>
        /// <exception cref="ArgumentNullException">validationMessages</exception>
        protected Validator(IValidationMessageContainer validationMessages)
        {
            this.ValidationMessages = validationMessages ?? throw new ArgumentNullException(nameof(validationMessages));
        }

        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public IValidationMessageContainer ValidationMessages { get; }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        public abstract bool Validate();
    }
}