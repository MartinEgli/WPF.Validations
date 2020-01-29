// -----------------------------------------------------------------------
// <copyright file="OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.
    OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidator
{
    using System.Globalization;
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Anori.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidator.ViewModels;
    using Anori.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorWindow()
        {
            this.InitializeComponent();
            var locRepo = new LocalizationRepository();
            locRepo.AddText("Source1", "Group1", "NoSpaces", CultureInfo.GetCultureInfo("en-US"), "No spaces");
            locRepo.AddText(
                "Source1",
                "Group1",
                "MaxLength",
                CultureInfo.GetCultureInfo("en-US"),
                "Max Length is {MaxLength}");

            locRepo.AddText("Source1", "Group1", "NoSpaces", CultureInfo.GetCultureInfo("de-CH"), "Keine Leerzeichen");
            locRepo.AddText(
                "Source1",
                "Group1",
                "MaxLength",
                CultureInfo.GetCultureInfo("de-CH"),
                "Maximale Länge ist {MaxLength}");

            LocalizationRepositoryProvider.Instance.Repository = locRepo;
            LocalizeDictionary.Instance.DefaultProvider = LocalizationRepositoryProvider.Instance;

            this.DataContext = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorViewModel();
        }
    }
}