// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommands
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands;
    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedValidationByCommands.OneValueValidationByCommandsWindow" /> class.
        /// </summary>
        public OneValueValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByCommandsViewModel();
        }
    }
}