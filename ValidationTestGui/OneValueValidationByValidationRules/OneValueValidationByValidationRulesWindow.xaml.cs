// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByValidationRules
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByValidationRules.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByValidationRulesWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueValidationByValidationRulesWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByValidationRulesViewModel();
        }
    }
}