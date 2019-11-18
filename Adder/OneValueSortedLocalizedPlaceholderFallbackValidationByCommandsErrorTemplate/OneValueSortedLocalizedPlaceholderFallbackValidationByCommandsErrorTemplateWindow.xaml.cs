// -----------------------------------------------------------------------
// <copyright file="OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplateWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.
    OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplate
{
    using System.Globalization;
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Bfa.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplate.ViewModels;
    using Bfa.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for OneValueSortedLocalizedFallbackValidationByCommands.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplateWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplateWindow" />
        ///     class.
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsErrorTemplateWindow()
        {
            this.InitializeComponent();
            var locRepo = new LocalizationRepository();
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error1",
                CultureInfo.GetCultureInfo("de-CH"),
                "Fehler 1 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error1",
                CultureInfo.GetCultureInfo("en-US"),
                "Error 1 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error2",
                CultureInfo.GetCultureInfo("de-CH"),
                "Fehler 2 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error2",
                CultureInfo.GetCultureInfo("en-US"),
                "Error 2 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Warning1",
                CultureInfo.GetCultureInfo("de-CH"),
                "Warnung 1 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Warning1",
                CultureInfo.GetCultureInfo("en-US"),
                "Warning 1 Message: {Message}");
            LocalizationRepositoryProvider.Instance.Repository = locRepo;
            LocalizeDictionary.Instance.DefaultProvider = LocalizationRepositoryProvider.Instance;
            this.DataContext = new OneValueSortedLocalizedPlaceholderFallbackValidationByCommandsViewModel();
        }
    }
}