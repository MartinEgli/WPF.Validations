// -----------------------------------------------------------------------
// <copyright file="OneValueSortedValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalisedValidationByCommands;
    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedLocalisedValidationByCommands.OneValueSortedValidationByCommandsWindow" /> class.
        /// </summary>
        public OneValueSortedValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueSortedValidationByCommandsViewModel();
        }
    }
}