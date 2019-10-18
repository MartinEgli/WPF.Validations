// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingContentPresenter.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System.Windows;

    using Adder;

    using ValidationToolkit;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ValidationToolkit.ViewBase" />
    public partial class CalculatorViewUsingContentPresenter : ViewBase
    {
        public CalculatorViewUsingContentPresenter()
        {
            this.InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}