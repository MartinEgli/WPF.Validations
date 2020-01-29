// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui
{
    using Anori.Common.WPF.Validations.ValidationTestGui.Concepts;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalisedValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedFallbackValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedPlaceholderFallbackValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsBindingElementName;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplate;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidator;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplate;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedPlaceholderFallbackValidationByExceptions;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRules;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByCommandsValidator;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByExceptions;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedValidationByValidationRules;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueTwoStepValidationByCommandsValidator;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidator;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorCancel;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByCommandsValidatorToUpper;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByExceptions;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueValidationByValidationRules;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidator;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorAdorner;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommandsValidatorModel;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommands;
    using Anori.Common.WPF.Validations.ValidationTestGui.TwoValueValidationByCommandsValidatorRanges;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ConceptsClick(object sender, RoutedEventArgs e)
        {
            var window = new ConceptsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRulesWindowClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRulesWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationFallbackByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedFallbackValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationPlaceholderFallbackByCommandsBindingElementNameClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsBindingElementNameWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationPlaceholderFallbackByCommandsClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationPlaceholderFallbackByCommandsErrorTemplateClick(
            object sender,
            RoutedEventArgs e)
        {
            var window = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplateWindow();
            window.ShowDialog();
        }

        private void OneValueSortedLocalizedValidationPlaceholderFallbackByCommandsValidatorErrorTemplateClick(
            object sender,
            RoutedEventArgs e)
        {
            var window =
                new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplateWindow();
            window.ShowDialog();
        }

        private void OneValueSortedValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedValidationByCommandsValidatorClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedValidationByCommandsValidatorWindow();
            window.ShowDialog();
        }

        private void OneValueSortedValidationByExceptionsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedValidationByExceptionsWindow();
            window.ShowDialog();
        }

        private void OneValueSortedValidationByValidationRulesClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueSortedValidationByValidationRulesWindow();
            window.ShowDialog();
        }

        private void OneValueTwoStepValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueTwoStepValidationByCommandsValidatorWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByCommandsValidatorCancelClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByCommandsValidatorCancelWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByCommandsValidatorClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByCommandsValidatorWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByCommandsValidatorToUpperClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByCommandsValidatorToUpperWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByExceptionsClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByExceptionsWindow();
            window.ShowDialog();
        }

        private void OneValueValidationByValidationRulesClick(object sender, RoutedEventArgs e)
        {
            var window = new OneValueValidationByValidationRulesWindow();
            window.ShowDialog();
        }

        private void TwoValueSortedValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueSortedValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void TwoValueSortedValidationByCommandsValidatorAdornerClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueSortedValidationByCommandsValidatorAdornerWindow();
            window.ShowDialog();
        }

        private void TwoValueSortedValidationByCommandsValidatorClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueSortedValidationByCommandsValidatorWindow();
            window.ShowDialog();
        }

        private void TwoValueSortedValidationByCommandsValidatorModelClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueSortedValidationByCommandsValidatorModelWindow();
            window.ShowDialog();
        }

        private void TwoValueValidationByCommandsClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueValidationByCommandsWindow();
            window.ShowDialog();
        }

        private void TwoValueValidationByCommandsValidatorRangesClick(object sender, RoutedEventArgs e)
        {
            var window = new TwoValueValidationByCommandsValidatorRangesWindow();
            window.ShowDialog();
        }
    }
}