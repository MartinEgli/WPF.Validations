// -----------------------------------------------------------------------
// <copyright file="LocalizationProviderHelpers.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations
{
    using System;
    using System.Reflection;
    using System.Text;

    using Bfa.Common.Strings;

    using JetBrains.Annotations;

    /// <summary>
    ///     LocalizationProviderHelpers Class
    /// </summary>
    /// ReSharper disable StyleCop.SA1630
    public static class LocalizationProviderHelpers
    {
        /// <summary>
        ///     Returns the <see cref="AssemblyName" /> of the passed assembly instance
        /// </summary>
        /// <param name="assembly">The Assembly where to get the name from</param>
        /// <returns>
        ///     The Assembly name
        /// </returns>
        /// <exception cref="System.ArgumentNullException">assembly</exception>
        /// <exception cref="System.NullReferenceException">assembly.FullName is null</exception>
        public static string GetAssemblyName(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (assembly.FullName == null)
            {
                throw new NullReferenceException("assembly.FullName is null");
            }

            return assembly.FullName.Split(',')[0];
        }

        /// <summary>
        ///     Parses the key.
        /// </summary>
        /// <param name="inKey">The key to parse.</param>
        /// <param name="outSource">The found or default assembly.</param>
        /// <param name="outGroup">The found or default dictionary.</param>
        /// <param name="outKey">The found or default key.</param>
        /// <returns>
        ///     Is parsed.
        /// </returns>
        public static bool ParseKey(string inKey, out string outSource, out string outGroup, out string outKey)
        {
            // Reset everything to null.
            outSource = null;
            outGroup = null;
            outKey = null;

            if (inKey.IsNullOrWhiteSpace())
            {
                return false;
            }

            var split = inKey.Trim().Split(":".ToCharArray());
            switch (split.Length)
            {
                // assembly:dict:key
                case 3:
                    outSource = !split[0].IsNullOrEmpty() ? split[0] : null;
                    outGroup = !split[1].IsNullOrEmpty() ? split[1] : null;
                    outKey = split[2];

                    break;

                // dict:key
                case 2:
                    outGroup = !split[0].IsNullOrEmpty() ? split[0] : null;
                    outKey = split[1];

                    break;

                // key
                case 1:
                    outKey = split[0];

                    break;

                // default:
                // return false;
            }

            return true;
        }

        /// <summary>
        ///     Parses the provider.
        /// </summary>
        /// <param name="inKey">The in key.</param>
        /// <param name="outProvider">The out provider.</param>
        /// <param name="outKey">The out key.</param>
        /// <returns>Is parsed.</returns>
        public static bool ParseProvider(string inKey, out string outProvider, out string outKey)
        {
            // Reset everything to null.
            outProvider = null;
            outKey = null;

            if (inKey.IsNullOrWhiteSpace())
            {
                return false;
            }

            var split = inKey.Trim().Split(":".ToCharArray(), 2);
            switch (split.Length)
            {
                // provider:key
                case 2:
                    outProvider = !split[0].IsNullOrEmpty() ? split[0] : null;
                    outKey = split[1];

                    break;

                // key
                case 1:
                    outKey = split[0];

                    break;

                default:
                    return false;
            }

            return true;
        }

        /// <summary>
        ///     Gets the fully qualified key.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     The Fully Qualified Key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">key</exception>
        [NotNull]
        public static string FullyQualifiedKey(
            [CanBeNull] string source,
            [CanBeNull] string group,
            [NotNull] string key)
        {
            var stringBuilder = new StringBuilder();
            if (!source.IsNullOrWhiteSpace())
            {
                stringBuilder.Append(source).Append(":");
            }

            if (!group.IsNullOrWhiteSpace())
            {
                stringBuilder.Append(group).Append(":");
            }

            return stringBuilder.Append(key).ToString();
        }
    }
}