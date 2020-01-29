// -----------------------------------------------------------------------
// <copyright file="KeyObjectAndCultureConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    /// <summary>
    ///     The KeyObjectAndCultureConverter class
    /// </summary>
    /// <seealso cref="KeyObjectConverterBase{KeyObjectAndCultureConverter}" />
    internal class KeyObjectAndCultureConverter : KeyObjectConverterBase<KeyObjectAndCultureConverter>
    {
        /// <summary>
        ///     Gets the formatter.
        /// </summary>
        /// <param name="fullyQualifiedKey">The Fully Qualified Key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected override bool TryGetFormatter(
            string fullyQualifiedKey,
            LocTextBindingExtension parameter,
            out string formatter)
        {
            return this.TryGetFormatterCulture(fullyQualifiedKey, parameter, out formatter);
        }
    }
}