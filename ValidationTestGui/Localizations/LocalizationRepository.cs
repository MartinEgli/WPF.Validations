// -----------------------------------------------------------------------
// <copyright file="LocalizationRepository.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Pi.Infrastructure.Common.LocalizationProviders
{
    using Anori.Common.WPF.Localizations;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    public class LocalizationRepository : ILocalizationRepository
    {
        private readonly Dictionary<CultureInfo, Dictionary<string, string>> textRepository =
            new Dictionary<CultureInfo, Dictionary<string, string>>();

        public ObservableCollection<CultureInfo> AvailableCultures { get; } = new ObservableCollection<CultureInfo>();

        /// <summary>
        ///     Adds the text.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="text">The text.</param>
        public void AddText(string source, string group, string key, CultureInfo culture, string text)
        {
            if (!(this.textRepository.TryGetValue(culture, out var repo)))
            {
                repo = new Dictionary<string, string>();
                this.textRepository.Add(culture, repo);
                this.AvailableCultures.Add(culture);
            }

            var k = LocalizationProviderHelpers.FullyQualifiedKey(source, group, key);
            if (!(repo.TryGetValue(k, out _)))
            {
                repo.Add(k, text);
            }
        }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public string GetText(string source, string group, string key, CultureInfo culture)
        {
            var text = "";

            var k = LocalizationProviderHelpers.FullyQualifiedKey(source, group, key);
            if (!this.textRepository.TryGetValue(culture, out var repo))
            {
                return text;
            }

            if (repo.TryGetValue(k, out var t))
            {
                text = t;
            }

            return text;
        }
    }
}