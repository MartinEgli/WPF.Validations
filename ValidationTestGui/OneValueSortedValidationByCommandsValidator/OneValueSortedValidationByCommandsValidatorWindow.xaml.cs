// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsAndValidatorWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommandsValidator
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommandsValidator.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedValidationByCommandsValidatorWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedValidationByCommandsValidatorWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueSortedValidationByCommandsValidatorViewModel();
        }
    }
}