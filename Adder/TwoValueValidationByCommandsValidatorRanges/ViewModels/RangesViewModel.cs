// -----------------------------------------------------------------------
// <copyright file="RangesViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels
{
    using Bfa.Common.Binders;
    using Bfa.Common.Collections;
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;

    using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;

    /// <summary>
    ///     The ranges view model
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    public class RangesViewModel : Bindable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RangesViewModel" /> class.
        /// </summary>
        public RangesViewModel()
        {
            this.RangesModel = new RangesModel { Min = 2, Max = 8 };

            this.Values = new ObservableCollection<ValueViewModel>();

            var builder = new ValidatorBuilder<ValueViewModel>();
            builder.AddRule(new MinMaxRangeModelRule("MinMaxRange") { Target = "Value" });
            builder.AddModelValidateByProperty("Value");
            builder.AddWatcher(this.RangesModel, "Max");
            builder.AddWatcher(this.RangesModel, "Min");

            var model1 = new ValueModel { Value = 5 };
            var viewModel1 = new ValueViewModel(model1, this.RangesModel);
            var validator1 = builder.Build(viewModel1);
            viewModel1.Validator = validator1;
            this.Values.Add(viewModel1);

            var model2 = new ValueModel { Value = 6 };
            var viewModel2 = new ValueViewModel(model2, this.RangesModel);
            var validator2 = builder.Build(viewModel2);
            viewModel2.Validator = validator2;

            this.Values.Add(viewModel2);

            this.RangesModel.PropertyChanged += this.RangesModelOnPropertyChanged;
        }

        /// <summary>
        ///     Gets the ranges model.
        /// </summary>
        /// <value>
        ///     The ranges model.
        /// </value>
        public RangesModel RangesModel { get; }

        /// <summary>
        ///     Gets the values.
        /// </summary>
        /// <value>
        ///     The values.
        /// </value>
        public ObservableCollection<ValueViewModel> Values { get; }

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        public double Max
        {
            get => this.RangesModel.Max;
            set => this.SetProperty(v => this.RangesModel.Max = v, this.RangesModel.Max, value);
        }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        public double Min
        {
            get => this.RangesModel.Min;
            set => this.RangesModel.Min = value;
        }

        /// <summary>
        ///     Ranges the model on property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void RangesModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        /// <summary>
        ///     Models the on property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }
    }
}