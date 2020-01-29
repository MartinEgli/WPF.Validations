// -----------------------------------------------------------------------
// <copyright file="OneValueValidationByExceptionsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByExceptions
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByExceptions.ViewModels;

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