// -----------------------------------------------------------------------
// <copyright file="CalculatorViewWithErrorTemplate.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Views
{
    using System.Windows;

    using Adder;

    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    public partial class CalculatorViewWithErrorTemplate : ViewBase
    {
        public CalculatorViewWithErrorTemplate()
        {
            this.InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}