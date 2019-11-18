// -----------------------------------------------------------------------
// <copyright file="TwoValueValidationByCommandsValidatorRangesWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges.ViewModels;

    /// <summary>
    ///     Interaction logic for TwoValueValidationByCommandsValidatorRangesWindow.xaml
    /// </summary>
    public partial class TwoValueValidationByCommandsValidatorRangesWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TwoValueValidationByCommandsValidatorRangesWindow" /> class.
        /// </summary>
        public TwoValueValidationByCommandsValidatorRangesWindow()
        {
            this.InitializeComponent();
            this.DataContext = new RangesViewModel();
        }
    }
}