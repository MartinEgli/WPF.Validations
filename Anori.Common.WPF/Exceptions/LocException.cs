// -----------------------------------------------------------------------
// <copyright file="LocException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Exceptions
{
    using System;

    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     The loc exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocException : Exception, ILocalizationTextKeyAware
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LocException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        public LocException([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase key)
            : base(message)
        {
            this.TextKey = key ?? throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="ArgumentNullException">key</exception>
        public LocException(
            [NotNull] string message,
            [NotNull] FullyQualifiedResourceKeyBase key,
            Exception innerException)
            : base(message, innerException)
        {
            this.TextKey = key ?? throw new ArgumentNullException(nameof(key));
        }

        /// <summary>
        ///     Gets the text key.
        /// </summary>
        /// <value>
        ///     The text key.
        /// </value>
        public string TextKey { get; }
    }
}