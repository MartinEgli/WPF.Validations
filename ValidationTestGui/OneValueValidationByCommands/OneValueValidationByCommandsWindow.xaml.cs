// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommands
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommands.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueValidationByCommandsWindow" /> class.
        /// </summary>
        public OneValueValidationByCommandsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByCommandsViewModel();
        }
    }
}