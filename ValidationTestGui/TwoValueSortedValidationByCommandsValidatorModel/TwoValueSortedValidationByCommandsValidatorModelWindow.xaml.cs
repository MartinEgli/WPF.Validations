// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel
{
    using System.Windows;

    using Anori.Common.Validations.Validators;
    using Anori.Common.WPF.Validations.ValidationTestGui.Rules;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.Models;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel.ViewModels;

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