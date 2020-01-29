// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedAndPlaceholderAndFallbackValidationByExceptionsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedPlaceholderFallbackValidationByExceptions
{
    using System.Globalization;
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedPlaceholderFallbackValidationByExceptions.
        ViewModels;
    using Anori.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        /// </summary>
        public OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsWindow()
        {
            this.InitializeComponent();

            var locRepo = new LocalizationRepository();
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error",
                CultureInfo.GetCultureInfo("de-CH"),
                "Fehler 1 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Error",
                CultureInfo.GetCultureInfo("en-US"),
                "Error 1 Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "NotNull",
                CultureInfo.GetCultureInfo("de-CH"),
                "Nicht null Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "NotNull",
                CultureInfo.GetCultureInfo("en-US"),
                "Not null Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Warning",
                CultureInfo.GetCultureInfo("de-CH"),
                "Warnung Message: {Message}");
            locRepo.AddText(
                "Source1",
                "Group1",
                "Warning",
                CultureInfo.GetCultureInfo("en-US"),
                "Warning Message: {Message}");
            LocalizationRepositoryProvider.Instance.Repository = locRepo;
            LocalizeDictionary.Instance.DefaultProvider = LocalizationRepositoryProvider.Instance;
            this.DataContext = new OneValueSortedLocalizedPlaceholderFallbackValidationByExceptionsViewModel();
        }
    }
}