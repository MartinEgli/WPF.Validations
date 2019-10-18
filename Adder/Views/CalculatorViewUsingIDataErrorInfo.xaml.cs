// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingIDataErrorInfo.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Views
{
    using Adder;

    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    public partial class CalculatorViewUsingIDataErrorInfo : ViewBase
    {
        public CalculatorViewUsingIDataErrorInfo()
        {
            this.InitializeComponent();
        }

        public void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModelIDataErrorInfo));
        }
    }
}