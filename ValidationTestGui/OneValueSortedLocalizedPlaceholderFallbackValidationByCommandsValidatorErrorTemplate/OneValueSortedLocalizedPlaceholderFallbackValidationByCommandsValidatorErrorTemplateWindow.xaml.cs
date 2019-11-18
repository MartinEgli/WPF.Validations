// -----------------------------------------------------------------------
// <copyright file="OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplateWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.
    OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplate
{
    using System.Globalization;
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Bfa.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplate.ViewModels;
    using Bfa.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplateWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplateWindow()
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

            this.DataContext =
                new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsValidatorErrorTemplateViewModel();
        }
    }
}