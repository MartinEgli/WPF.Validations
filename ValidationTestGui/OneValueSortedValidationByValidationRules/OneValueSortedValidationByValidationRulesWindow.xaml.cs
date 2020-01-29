// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByValidationRules
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByValidationRules.ViewModels;

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