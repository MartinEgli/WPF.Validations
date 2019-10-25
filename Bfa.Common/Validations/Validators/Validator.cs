// -----------------------------------------------------------------------
// <copyright file="Validator.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using System;
    using System.ComponentModel;

    using Bfa.Common.Binders;
    using Bfa.Common.Validations.ValidationMessageContainers;
    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    /// <summary>
    ///     Generic Validator class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="IValidationMessagesAware" />
    public class Validator<TModel> : IValidationMessagesAware
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
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            this.model = model;
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
            this.ValidationMessages = validationMessages ?? throw new ArgumentNullException(nameof(validationMessages));

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
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public IValidationMessageContainer ValidationMessages { get; }

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

            args.Cancel = !this.Rules.ValidateCancelProperty(
                              e.PropertyName,
                              args.NewObject,
                              this.model,
                              this.ValidationMessages);
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(e is Bfa.Common.Binders.PropertyChangedEventArgs args))
            {
                return;
            }

            this.Rules.ValidateProperty(e.PropertyName, args.CurrentObject, this.model, this.ValidationMessages);
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
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
            var isValid = this.Rules.ValidateCancelProperty(propertyName, value, this.model, this.ValidationMessages);
            isValid &= this.Rules.ValidateProperty(propertyName, value, this.model, this.ValidationMessages);
            return isValid;
        }
    }
}