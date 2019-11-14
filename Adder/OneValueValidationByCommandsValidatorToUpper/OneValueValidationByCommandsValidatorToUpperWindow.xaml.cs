// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsValidatorToUpperWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorToUpper
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorToUpper.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByCommandsValidatorToUpperWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueValidationByCommandsValidatorToUpperWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByCommandsValidatorToUpperViewModel();
        }
    }
}