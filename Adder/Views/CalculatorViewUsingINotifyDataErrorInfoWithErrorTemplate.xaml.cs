// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingINotifyDataErrorInfoWithErrorTemplate.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Views
{
    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    public partial class CalculatorViewUsingINotifyDataErrorInfoWithErrorTemplate : ViewBase
    {
        public CalculatorViewUsingINotifyDataErrorInfoWithErrorTemplate()
        {
            this.InitializeComponent();
        }

        public void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModelINotifyDataErrorInfo));
        }
    }
}