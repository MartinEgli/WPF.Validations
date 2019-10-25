// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System.Windows;

    using Bfa.Common.Binders;
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    using ValidationToolkit;

    public partial class App : Application
    {
        private void AdderStartup(object sender, StartupEventArgs e)
        {
            this.MainWindow = new MainWindow();
            this.MainWindow.DataContext = new MainViewModel();
            this.MainWindow.Show();
        }
    }

    public class MainViewModel : Bindable
    {
        private AdderViewModel adderViewModel1;

        private AdderViewModel adderViewModel2;

        private AdderViewModelIDataErrorInfo adderViewModelIDataErrorInfo1;

        private AdderViewModelIDataErrorInfo adderViewModelIDataErrorInfo2;

        private AdderViewModelINotifyDataErrorInfo adderViewModelINotifyDataErrorInfo1;

        private AdderViewModelINotifyDataErrorInfo adderViewModelINotifyDataErrorInfo2;

        public MainViewModel()
        {
            this.ValidatorBuilder = CreateValidatorBuilder();

            this.AdderViewModel1 = this.CreateAdderViewModel();
            this.AdderViewModel2 = this.CreateAdderViewModel();
            this.AdderViewModelIDataErrorInfo1 = this.CreateAdderViewModelIDataErrorInfo();
            this.AdderViewModelIDataErrorInfo2 = this.CreateAdderViewModelIDataErrorInfo();
            this.AdderViewModelINotifyDataErrorInfo1 = this.CreateAdderViewModelINotifyDataErrorInfo();
            this.AdderViewModelINotifyDataErrorInfo2 = this.CreateAdderViewModelINotifyDataErrorInfo();
        }

        public ValidatorBuilder<AdderModel> ValidatorBuilder { get; set; }

        public AdderViewModel AdderViewModel2
        {
            get => this.adderViewModel2;
            set => this.SetProperty(ref this.adderViewModel2, value);
        }

        public AdderViewModelIDataErrorInfo AdderViewModelIDataErrorInfo1
        {
            get => this.adderViewModelIDataErrorInfo1;
            set => this.SetProperty(ref this.adderViewModelIDataErrorInfo1, value);
        }

        public AdderViewModelIDataErrorInfo AdderViewModelIDataErrorInfo2
        {
            get => this.adderViewModelIDataErrorInfo2;
            set => this.SetProperty(ref this.adderViewModelIDataErrorInfo2, value);
        }

        public AdderViewModelINotifyDataErrorInfo AdderViewModelINotifyDataErrorInfo1
        {
            get => this.adderViewModelINotifyDataErrorInfo1;
            set => this.SetProperty(ref this.adderViewModelINotifyDataErrorInfo1, value);
        }

        public AdderViewModelINotifyDataErrorInfo AdderViewModelINotifyDataErrorInfo2
        {
            get => this.adderViewModelINotifyDataErrorInfo2;
            set => this.SetProperty(ref this.adderViewModelINotifyDataErrorInfo2, value);
        }

        public AdderViewModel AdderViewModel1
        {
            get => this.adderViewModel1;
            set => this.SetProperty(ref this.adderViewModel1, value);
        }

        private AdderViewModel CreateAdderViewModel()
        {
            var model = new AdderModel();
            var validator = this.ValidatorBuilder.Build(model);
            var viewModel = new AdderViewModel(model, validator);

            // Setup command processing.
            viewModel.CalculateCommand = new RelayCommand(
                z =>
                    {
                        try
                        {
                            // Shouldn't get to here if the controls do not have valid values.
                            var x = viewModel.X.Value;
                            var y = viewModel.Y.Value;
                            viewModel.Sum = CalculationService.Add(x, y);
                        }
                        catch
                        {
                        }
                    },
                viewModel.CanCalculate);
            return viewModel;
        }

        private AdderViewModelIDataErrorInfo CreateAdderViewModelIDataErrorInfo()
        {
            var model = new AdderModel();
            var validator = this.ValidatorBuilder.Build(model);
            var viewModel = new AdderViewModelIDataErrorInfo(model, validator);

            // Setup command processing.
            viewModel.CalculateCommand = new RelayCommand(
                z =>
                    {
                        try
                        {
                            // Shouldn't get to here if the controls do not have valid values.
                            var x = viewModel.X.Value;
                            var y = viewModel.Y.Value;
                            viewModel.Sum = CalculationService.Add(x, y);
                        }
                        catch
                        {
                        }
                    },
                viewModel.CanCalculate);
            return viewModel;
        }

        private static ValidatorBuilder<AdderModel> CreateValidatorBuilder()
        {
            var validatorBuilder = new ValidatorBuilder<AdderModel>();

            validatorBuilder.AddRule(nameof(AdderModel.X), new MandatoryRule(nameof(AdderModel.X)));
            validatorBuilder.AddRule(
                nameof(AdderModel.X),
                new MaxRangeRule("MaxRange", nameof(AdderModel.X)) { Max = 50 });
            return validatorBuilder;
        }

        private AdderViewModelINotifyDataErrorInfo CreateAdderViewModelINotifyDataErrorInfo()
        {
            var model = new AdderModel();
            var validator = this.ValidatorBuilder.Build(model);

            var viewModel = new AdderViewModelINotifyDataErrorInfo(model, validator);

            // Setup command processing.
            viewModel.CalculateCommand = new RelayCommand(
                z =>
                    {
                        try
                        {
                            // Shouldn't get to here if the controls do not have valid values.
                            var x = viewModel.X.Value;
                            var y = viewModel.Y.Value;
                            viewModel.Sum = CalculationService.Add(x, y);
                        }
                        catch
                        {
                        }
                    },
                viewModel.CanCalculate);
            return viewModel;
        }
    }
}