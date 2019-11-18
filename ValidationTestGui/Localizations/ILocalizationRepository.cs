// -----------------------------------------------------------------------
// <copyright file="ILocalizationRepository.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Pi.Infrastructure.Common.LocalizationProviders
{
    using System.Collections.ObjectModel;
    using System.Globalization;

    public interface ILocalizationRepository
    {
        string GetText(string source, string group, string key, CultureInfo culture);

        ObservableCollection<CultureInfo> AvailableCultures { get; }
    }
}