// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByValidationRules
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByValidationRules.ViewModels;

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