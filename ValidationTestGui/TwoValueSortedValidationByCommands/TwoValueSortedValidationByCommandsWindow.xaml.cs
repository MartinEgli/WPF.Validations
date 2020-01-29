// -----------------------------------------------------------------------
// <copyright file="TwoValueSortedValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommands
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueSortedValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TwoValueSortedValidationByCommandsWindow" /> class.
        /// </summary>
        public TwoValueSortedValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TwoValueSortedValidationByCommandsViewModel();
        }
    }
}