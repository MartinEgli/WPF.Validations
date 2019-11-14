// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsValidatorWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidator
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidator.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByCommandsValidatorWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueValidationByCommandsValidatorWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByCommandsValidatorViewModel();
        }
    }
}