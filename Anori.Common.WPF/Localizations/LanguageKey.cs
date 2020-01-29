// -----------------------------------------------------------------------
// <copyright file="LanguageKey.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations
{
    using System.Linq;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     FQPiLanguageKey Class
    /// </summary>
    /// <seealso cref="WPFLocalizeExtension.Providers.FullyQualifiedResourceKeyBase" />
    /// ReSharper disable once InconsistentNaming
    public class LanguageKey : FullyQualifiedResourceKeyBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LanguageKey" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="group">The group.</param>
        /// <param name="source">The source.</param>
        public LanguageKey(string key, string group, string source)
        {
            this.Key = key;
            this.Group = group;
            this.Source = source;
        }

        /// <summary>
        ///     Gets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public string Key { get; }

        /// <summary>
        ///     Gets the group name.
        /// </summary>
        /// <value>
        ///     The group.
        /// </value>
        public string Group { get; }

        /// <summary>
        ///     Gets the source name.
        /// </summary>
        /// <value>
        ///     The source.
        /// </value>
        public string Source { get; }

        /// <summary>
        ///     Converts the object to a string.
        /// </summary>
        /// <returns>
        ///     The joined version of the assembly, dictionary and key.
        /// </returns>
        public override string ToString() =>
            string.Join(
                ":",
                new[] { this.Source, this.Group, this.Key }.Where(x => !string.IsNullOrEmpty(x)).ToArray());
    }
}