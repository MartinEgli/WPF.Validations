// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedValidationByCommandsWindow.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalisedValidationByCommands
{
    using System.Globalization;
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Bfa.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedValidationByCommands.ViewModels;
    using Bfa.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedLocalizedFallbackValidationByCommands.OneValueSortedLocalisedValidationByCommandsWindow" />
        ///     class.
        /// </summary>
        public OneValueSortedLocalizedValidationByCommandsWindow()
        {
            this.InitializeComponent();
            var locRepo = new LocalizationRepository();
            locRepo.AddText("Source1", "Group1", "Error1", CultureInfo.GetCultureInfo("de-CH"), "Fehler 1");
            locRepo.AddText("Source1", "Group1", "Error1", CultureInfo.GetCultureInfo("en-US"), "Error 1");
            locRepo.AddText("Source1", "Group1", "Error2", CultureInfo.GetCultureInfo("de-CH"), "Fehler 2");
            locRepo.AddText("Source1", "Group1", "Error2", CultureInfo.GetCultureInfo("en-US"), "Error 2");
            locRepo.AddText("Source1", "Group1", "Warning1", CultureInfo.GetCultureInfo("de-CH"), "Warnung 1");
            locRepo.AddText("Source1", "Group1", "Warning1", CultureInfo.GetCultureInfo("en-US"), "Warning 1");
            LocalizationRepositoryProvider.Instance.Repository = locRepo;
            LocalizeDictionary.Instance.DefaultProvider = LocalizationRepositoryProvider.Instance;
            this.DataContext = new OneValueSortedLocalizedValidationByCommandsViewModel();
        }
    }
}