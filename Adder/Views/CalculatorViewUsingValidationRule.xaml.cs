// -----------------------------------------------------------------------
// <copyright file="CalculatorViewUsingValidationRule.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Views
{
    using Bfa.Common.WPF.Validations.ValidationTestGui.ViewModels;

    /// <summary>
    ///     CalculatorViewUsingValidationRule class.
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationTestGui.ViewBase" />
    public partial class CalculatorViewUsingValidationRule : ViewBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CalculatorViewUsingValidationRule" /> class.
        /// </summary>
        public CalculatorViewUsingValidationRule()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Called when [load].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        public void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Controller.RegisterView(this, typeof(AdderViewModel));
        }
    }
}