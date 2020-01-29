// -----------------------------------------------------------------------
// <copyright file="FQProviderKey.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations
{
    using System.Linq;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// FQProviderKey Class
    /// </summary>
    /// <seealso cref="WPFLocalizeExtension.Providers.FullyQualifiedResourceKeyBase" />
    // ReSharper disable once InconsistentNaming
    public class FQProviderKey : FullyQualifiedResourceKeyBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FQProviderKey" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="provider">The provider name.</param>
        public FQProviderKey(string key, string provider)
        {
            this.Key = key;
            this.Provider = provider;
        }

        /// <summary>
        ///     Gets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public string Key { get; }

        /// <summary>
        ///     Gets the provider name.
        /// </summary>
        /// <value>
        ///     The provider.
        /// </value>
        public string Provider { get; }

        /// <summary>
        ///     Converts the object to a string.
        /// </summary>
        /// <returns>The joined version of the assembly, dictionary and key.</returns>
        public override string ToString()
        {
            return string.Join(":", new[] { this.Provider, this.Key }.Where(x => !string.IsNullOrEmpty(x)).ToArray());
        }
    }
}