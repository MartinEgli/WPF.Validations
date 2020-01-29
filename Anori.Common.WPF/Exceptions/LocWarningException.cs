// -----------------------------------------------------------------------
// <copyright file="LocWarningException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Exceptions
{
    using System;
    using System.ComponentModel;

    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     The loc warning exception
    /// </summary>
    /// <seealso cref="System.ComponentModel.WarningException" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class LocWarningException : WarningException, ILocalizationTextKeyAware
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LocWarningException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        public LocWarningException([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase key)
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