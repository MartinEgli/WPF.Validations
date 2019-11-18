// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorAdorner
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorAdorner.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueSortedValidationByCommandsValidatorAdornerWindow : Window
    {
        public TwoValueSortedValidationByCommandsValidatorAdornerWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TwoValueSortedValidationByCommandsValidatorAdornerViewModel();
        }
    }
}