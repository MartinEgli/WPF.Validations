// -----------------------------------------------------------------------
// <copyright file="ValidationLocWarningException.cs" company="Anori Soft">
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
    ///     The validation loc warning exception
    /// </summary>
    /// <seealso cref="Anori.Common.WPF.Exceptions.ValidationWarningException" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class ValidationLocWarningException : ValidationWarningException, ILocalizationTextKeyAware
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationLocWarningException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        public ValidationLocWarningException([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase key)
            : base(message)
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