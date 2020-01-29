// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsValidatorToUpperWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorToUpper
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorToUpper.ViewModels;

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