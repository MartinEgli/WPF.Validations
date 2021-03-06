﻿// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedValidationByCommandsWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalisedValidationByCommands
{
    using System.Globalization;
    using System.Windows;

    using Anori.Common.WPF.Validations.ValidationTestGui.Localizations;
    using Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedValidationByCommands.ViewModels;
    using Anori.Pi.Infrastructure.Common.LocalizationProviders;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Interaction logic for ValidationByCommandsWindow.xaml
    /// </summary>
    public partial class OneValueSortedLocalizedValidationByCommandsWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="OneValueSortedLocalizedValidationByCommandsWindow" />
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