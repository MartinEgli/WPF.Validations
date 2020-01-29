// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndTextBindingAndCultureConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    /// <summary>
    ///     The Key Binding And Text Binding And Culture Converter Class
    /// </summary>
    /// <seealso cref="KeyBindingAndTextBindingConverterBase{KeyBindingAndTextBindingConverter}" />
    internal class
        KeyBindingAndTextBindingAndCultureConverter : KeyBindingAndTextBindingConverterBase<
            KeyBindingAndTextBindingAndCultureConverter>
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
            out string formatter) =>
            this.TryGetFormatterCulture(fullyQualifiedKey, parameter, out formatter);
    }
}