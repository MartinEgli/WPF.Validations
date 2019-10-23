// -----------------------------------------------------------------------
// <copyright file="AdderViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels
{
    using System.Windows.Input;

    using Bfa.Common.Validations;

    /// <summary>
    ///     AdderViewModel class.
    /// </summary>
    /// <seealso cref="ViewModel" />
    public class AdderViewModel : ViewModel
    {
        /// <summary>
        ///     The model
        /// </summary>
        private readonly AdderModel model;

        /// <summary>
        ///     The validator
        /// </summary>
        private readonly Validator<AdderModel> validator;

        /// <summary>
        ///     The calculate command
        /// </summary>
        private ICommand calculateCommand; // This will be setup to point to a RelayCommand object.

        /// <summary>
        ///     The sum
        /// </summary>
        private double? sum;

        /// <summary>
        ///     The y
        /// </summary>
        private double? y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdderViewModel" /> class.
        /// </summary>
        public AdderViewModel(AdderModel model, Validator<AdderModel> validator)
        {
            this.model = model;
            this.validator = validator;
            this.Y = null;
        }

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
            get => this.y;
            set
            {
                this.Sum = null;
                this.y = value;
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
        ///     Gets the calculate command.
        /// </summary>
        /// <value>
        ///     The calculate command.
        /// </value>
        public ICommand CalculateCommand
        {
            get => this.calculateCommand;
            set => this.calculateCommand = value;
        }

        /// <summary>
        ///     Gets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public override IValidationErrorContainer ValidationErrors => this.validator.ValidationErrors;

        /// <summary>
        ///     Determines whether this instance can calculate the specified z.
        /// </summary>
        /// <param name="z">The z.</param>
        /// <returns>
        ///     <c>true</c> if this instance can calculate the specified z; otherwise, <c>false</c>.
        /// </returns>
        public bool CanCalculate(object z)
        {
            return this.X.HasValue && this.Y.HasValue && this.ValidationErrors.ErrorCount == 0;
        }

        /// <summary>
        ///     Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void ValidateProperty(string propertyName)
        {
            // We don't use this when relying on ValidationRules or IDataErrorInfo.
        }
    }
}