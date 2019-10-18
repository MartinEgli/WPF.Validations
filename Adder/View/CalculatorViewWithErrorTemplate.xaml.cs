using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ValidationToolkit;

namespace Adder
{
    public partial class CalculatorViewWithErrorTemplate : ValidationToolkit.ViewBase
    {
        public CalculatorViewWithErrorTemplate()
        {
            InitializeComponent();
        }

        public  void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}