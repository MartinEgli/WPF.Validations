// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsAndValidatorWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorCancel
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorCancel.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByCommandsValidatorCancelWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueValidationByCommandsValidatorCancelWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByCommandsValidatorCancelViewModel();
        }
    }
}