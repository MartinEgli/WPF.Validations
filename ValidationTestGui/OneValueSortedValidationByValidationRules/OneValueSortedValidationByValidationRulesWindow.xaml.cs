// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByValidationRules
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByValidationRules.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedValidationByValidationRulesWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedValidationByValidationRulesWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueSortedValidationByValidationRulesViewModel();
        }
    }
}