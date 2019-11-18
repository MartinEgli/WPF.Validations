// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel
{
    using System.Windows;

    using Bfa.Common.Validations.Validators;
    using Bfa.Common.WPF.Validations.ValidationTestGui.Rules;
    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.Models;
    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueSortedValidationByCommandsValidatorModelWindow : Window
    {
        public TwoValueSortedValidationByCommandsValidatorModelWindow()
        {
            this.InitializeComponent();
            var model = new TwoValueSortedValidationByCommandsValidatorModelModel();

            var builder = new ValidatorBuilder<TwoValueSortedValidationByCommandsValidatorModelModel>();
            builder.AddRule(new AreValuesEqualRule("ValueNotEqual"));
            builder.AddModelValidateByProperty("Value1");
            builder.AddModelValidateByProperty("Value2");
            var validator = builder.Build(model);

            this.DataContext = new TwoValueSortedValidationByCommandsValidatorModelViewModel(model, validator);
        }
    }
}