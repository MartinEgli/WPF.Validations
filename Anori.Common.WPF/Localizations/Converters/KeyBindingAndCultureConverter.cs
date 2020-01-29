// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndCultureConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    /// <summary>
    /// Key Binding Converter
    /// </summary>
    /// <seealso cref="KeyBindingConverterBase{KeyBindingAndCultureConverter}" />
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    internal class KeyBindingAndCultureConverter : KeyBindingConverterBase<KeyBindingAndCultureConverter>
    {
        /// <summary>
        /// Gets the formatter.
        /// </summary>
        /// <param name="fullyQualifiedKey">The Fully Qualified Key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        /// The formatter
        /// </returns>
        protected override bool TryGetFormatter(string fullyQualifiedKey, LocTextBindingExtension parameter, out string formatter) =>
            this.TryGetFormatterCulture(fullyQualifiedKey, parameter, out formatter);
    }
}