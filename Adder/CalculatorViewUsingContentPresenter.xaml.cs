// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingContentPresenter.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    /// <summary>
    /// </summary>
    /// <seealso cref="ViewBase" />
    public partial class CalculatorViewUsingContentPresenter : ViewBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CalculatorViewUsingContentPresenter" /> class.
        /// </summary>
        public CalculatorViewUsingContentPresenter()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}