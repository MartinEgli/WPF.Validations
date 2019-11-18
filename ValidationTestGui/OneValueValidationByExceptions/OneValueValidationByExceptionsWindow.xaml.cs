// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByExceptionsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByExceptions
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueValidationByExceptions.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueValidationByExceptionsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueValidationByExceptionsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueValidationByExceptionsViewModel();
        }
    }
}