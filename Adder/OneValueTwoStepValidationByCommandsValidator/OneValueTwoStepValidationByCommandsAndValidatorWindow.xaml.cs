// -----------------------------------------------------------------------
// <copyright file="OneValueTwoStepValidationByCommandsValidatorWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueTwoStepValidationByCommandsValidator
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueTwoStepValidationByCommandsValidator.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueTwoStepValidationByCommandsValidatorWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueTwoStepValidationByCommandsValidatorWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueTwoStepValidationByCommandsValidatorViewModel();
        }
    }
}