// -----------------------------------------------------------------------
// <copyright file="OneValueSortedValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedValidationByCommandsWindow" /> class.
        /// </summary>
        public OneValueSortedValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueSortedValidationByCommandsViewModel();
        }
    }
}