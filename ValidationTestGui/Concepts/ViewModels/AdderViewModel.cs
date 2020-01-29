// -----------------------------------------------------------------------
// <copyright file="AdderViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Concepts.ViewModels
{
    using System.Threading;
    using System.Windows.Input;

    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;
    using Anori.Common.Validations.Validators;
    using Anori.Common.WPF.Validations.ValidationTestGui.Concepts.Models;

    /// <summary>
    ///     AdderViewModel class.
    /// </summary>
    /// <seealso cref="ViewModel" />
    public class AdderViewModel : ViewModel
    {
        /// <summary>
        ///     The identifier
        /// </summary>
        private static int id;

        /// <summary>
        ///     The model
        /// </summary>
        private readonly AdderModel model;

        /// <summary>
        ///     The validator
        /// </summary>
        private readonly Validator<AdderModel> validator;

        /// <summary>
        ///     The sum
        /// </summary>
        private double? sum;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdderViewModel" /> class.
        /// </summary>
        public AdderViewModel(AdderModel model, Validator<AdderModel> validator)
        {
            this.Id = Interlocked.Increment(ref id);
            this.model = model;
            this.validator = validator;
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public double? X
        {
            get => this.model.X;
            set
            {
                this.Sum = null;
                this.model.X = value;
                this.ValidateProperty("X");
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public double? Y
        {
            get => this.model.Y;
            set
            {
                this.Sum = null;
                this.model.Y = value;
                this.ValidateProperty("Y");
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the sum.
        /// </summary>
        /// <value>
        ///     The sum.
        /// </value>
        public double? Sum
        {
            get => this.sum;
            set
            {
                this.sum = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the calculate Command.
        /// </summary>
        /// <value>
        ///     The calculate Command.
        /// </value>
        public ICommand CalculateCommand { get; set; }

        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public override IValidationMessageContainer ValidationMessages => this.validator.ValidationMessages;

        /// <summary>
        ///     Determines whether this instance can calculate the specified z.
        /// </summary>
        /// <param name="z">The z.</param>
        /// <returns>
        ///     <c>true</c> if this instance can calculate the specified z; otherwise, <c>false</c>.
        /// </returns>
        public bool CanCalculate(object z) =>
            this.X.HasValue && this.Y.HasValue && this.ValidationMessages.ErrorCount == 0;

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void ValidateProperty(string propertyName)
        {
            // We don't use this when relying on ValidationRules or IDataErrorInfo.
        }
    }
}