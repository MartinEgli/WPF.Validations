// -----------------------------------------------------------------------
// <copyright file="Validator.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;
    using System.ComponentModel;

    using Bfa.Common.Binders;
    using Bfa.Common.Validations;

    using JetBrains.Annotations;

    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    /// <summary>
    ///     Generic Validator class
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Bfa.Common.Validations.IValidationErrorsAware" />
    public class Validator<TModel> : IValidationErrorsAware
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
            : this(model, rules, new ValidationErrorContainer())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Validator{TModel}" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="rules">The rules.</param>
        /// <param name="validationErrors">The validation errors.</param>
        /// <exception cref="ArgumentNullException">
        ///     model
        ///     or
        ///     rules
        /// </exception>
        internal Validator(
            [NotNull] TModel model,
            [NotNull] ValidatorRules rules,
            [NotNull] IValidationErrorContainer validationErrors)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            this.model = model;
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
            this.ValidationErrors = validationErrors ?? throw new ArgumentNullException(nameof(validationErrors));

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
        public IValidationErrorContainer ValidationErrors { get; }

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
                              this.ValidationErrors);
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

            this.Rules.ValidateCancelProperty(e.PropertyName, args.CurrentObject, this.model, this.ValidationErrors);
        }

        /// <summary>
        ///     Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return this.Rules.ValidateModel(this.model, this.ValidationErrors);
        }
    }
}