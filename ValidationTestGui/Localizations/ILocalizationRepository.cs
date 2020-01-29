// -----------------------------------------------------------------------
// <copyright file="ILocalizationRepository.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Pi.Infrastructure.Common.LocalizationProviders
{
    using System.Collections.ObjectModel;
    using System.Globalization;

    public interface ILocalizationRepository
    {
        string GetText(string source, string group, string key, CultureInfo culture);

        ObservableCollection<CultureInfo> AvailableCultures { get; }
    }
}