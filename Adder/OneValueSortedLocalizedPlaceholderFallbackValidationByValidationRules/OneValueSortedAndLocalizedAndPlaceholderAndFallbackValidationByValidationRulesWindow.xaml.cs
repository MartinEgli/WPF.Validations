// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedAndPlaceholderAndFallbackValidationByValidationRulesWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.
    OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRules
{
    using System.Globalization;
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Bfa.Common.WPF.Validations.ValidationTestGui.
        OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRules.ViewModels;
    using Bfa.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRulesWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRulesWindow()
        {
            this.InitializeComponent();

            var locRepo = new LocalizationRepository();
            locRepo.AddText("Source1", "Group1", "Matory", CultureInfo.GetCultureInfo("de-CH"), "Notwendig");
            locRepo.AddText("Source1", "Group1", "Matory", CultureInfo.GetCultureInfo("en-US"), "Matory");
            locRepo.AddText("Source1", "Group1", "Regex", CultureInfo.GetCultureInfo("de-CH"), "Regex");
            locRepo.AddText("Source1", "Group1", "Regex", CultureInfo.GetCultureInfo("en-US"), "Regex");
            locRepo.AddText(
                "Source1",
                "Group1",
                "MaxLength",
                CultureInfo.GetCultureInfo("de-CH"),
                "Max Länge ist {MaxLength}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "MaxLength",
                CultureInfo.GetCultureInfo("en-US"),
                "MaxLength is {MaxLength}");
            LocalizationRepositoryProvider.Instance.Repository = locRepo;
            LocalizeDictionary.Instance.DefaultProvider = LocalizationRepositoryProvider.Instance;

            this.DataContext = new OneValueSortedLocalizedPlaceholderFallbackValidationByValidationRulesViewModel();
        }
    }
}