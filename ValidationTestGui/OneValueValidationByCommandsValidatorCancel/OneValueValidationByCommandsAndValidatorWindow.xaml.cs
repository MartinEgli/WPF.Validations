// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsAndValidatorWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorCancel
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorCancel.ViewModels;

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