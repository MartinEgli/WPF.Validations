// -----------------------------------------------------------------------
// <copyright file="ValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommands
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class TwoValueValidationByCommandsWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoValueValidationByCommandsWindow"/> class.
        /// </summary>
        public TwoValueValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new TwoValueValidationByCommandsViewModel();
        }
    }
}