// -----------------------------------------------------------------------
// <copyright file="KeyBindingAndTextBindingAndObjectConverter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Converters
{
    using System.Windows;

    using JetBrains.Annotations;

    internal class KeyBindingAndTextBindingAndObjectConverter : KeyBindingAndTextBindingAndObjectConverterBase
    {
        public KeyBindingAndTextBindingAndObjectConverter(
            [NotNull] DependencyObject targetObject,
            [CanBeNull] string source,
            [CanBeNull] string group,
            bool useTextAsFallback)
            : base(targetObject, source, group, useTextAsFallback)
        {
        }

        /// <summary>
        ///     Gets the formatter.
        /// </summary>
        /// <param name="fullyQualifiedKey">The Fully Qualified Key.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>
        ///     The formatter
        /// </returns>
        protected override bool TryGetFormatter(string fullyQualifiedKey, out string formatter) =>
            base.TryGetFormatter(fullyQualifiedKey, out formatter);
    }
}