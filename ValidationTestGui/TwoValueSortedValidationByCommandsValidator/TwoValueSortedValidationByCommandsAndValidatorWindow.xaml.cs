// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidator
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidator.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueSortedValidationByCommandsValidatorWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoValueSortedValidationByCommandsValidatorWindow"/> class.
        /// </summary>
        public TwoValueSortedValidationByCommandsValidatorWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TwoValueSortedValidationByCommandsValidatorViewModel();
        }
    }
}