// -----------------------------------------------------------------------
// <copyright file="OneValueSortedValidationByExceptionsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions.ViewModels;

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