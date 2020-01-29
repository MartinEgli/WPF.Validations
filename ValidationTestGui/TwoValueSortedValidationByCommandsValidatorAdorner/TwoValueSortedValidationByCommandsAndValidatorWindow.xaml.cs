// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorAdorner
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorAdorner.ViewModels;

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