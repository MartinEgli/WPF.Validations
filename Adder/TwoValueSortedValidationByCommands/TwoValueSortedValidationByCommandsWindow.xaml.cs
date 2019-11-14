// -----------------------------------------------------------------------
// <copyright file="TwoValueSortedValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommands
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueSortedValidationByCommandsWindow : Window
    {
        public TwoValueSortedValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TwoValueValidationByCommandsViewModel();
        }

        private void TwoValueSortedValidationByCommandsView_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}