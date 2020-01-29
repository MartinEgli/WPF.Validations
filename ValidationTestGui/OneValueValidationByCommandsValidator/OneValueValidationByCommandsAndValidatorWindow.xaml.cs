// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsValidatorWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidator
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidator.ViewModels;

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