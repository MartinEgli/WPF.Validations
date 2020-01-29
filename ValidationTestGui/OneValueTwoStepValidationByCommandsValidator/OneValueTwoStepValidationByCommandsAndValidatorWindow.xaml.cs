// -----------------------------------------------------------------------
// <copyright file="OneValueTwoStepValidationByCommandsValidatorWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueTwoStepValidationByCommandsValidator
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueTwoStepValidationByCommandsValidator.ViewModels;

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