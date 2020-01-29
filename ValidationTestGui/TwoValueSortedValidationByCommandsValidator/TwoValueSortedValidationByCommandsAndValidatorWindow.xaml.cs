// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidator
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidator.ViewModels;

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