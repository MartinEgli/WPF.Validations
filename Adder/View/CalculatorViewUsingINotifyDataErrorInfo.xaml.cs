using System;
using System.Windows.Input;
using System.Windows.Media;
using ValidationToolkit;

namespace Adder
{
    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModel;

    public partial class CalculatorViewUsingINotifyDataErrorInfo : ViewBase
    {
        public CalculatorViewUsingINotifyDataErrorInfo()
        {
            InitializeComponent();
        }

        public void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModelINotifyDataErrorInfo));
        }
    }
}