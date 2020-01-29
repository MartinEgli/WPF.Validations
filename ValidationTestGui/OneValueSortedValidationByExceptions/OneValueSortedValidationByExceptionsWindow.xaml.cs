// -----------------------------------------------------------------------
// <copyright file="OneValueSortedValidationByExceptionsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions
{
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions.ViewModels;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedValidationByExceptionsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedValidationByExceptionsWindow()
        {
            this.InitializeComponent();
            this.DataContext = new OneValueSortedValidationByExceptionsViewModel();
        }
    }
}