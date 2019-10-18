// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingValidationRuleWithErrorTemplate.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Views
{
    using System.Windows;

    using Adder;

    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    public partial class CalculatorViewUsingValidationRuleWithErrorTemplate : ViewBase
    {
        public CalculatorViewUsingValidationRuleWithErrorTemplate()
        {
            this.InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}