﻿// -----------------------------------------------------------------------
// <copyright file="ValidationLocWarning.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationMessageContainers
{
    using System;

    using Anori.Common.Validations.ValidationMessageContainers;
    using Anori.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    ///     The validation loc warning class
    /// </summary>
    /// <seealso cref="Anori.Common.Validations.ValidationMessageContainers.ValidationWarning" />
    /// <seealso cref="Anori.Common.Validations.Validators.Interfaces.ILocalizationTextKeyAware" />
    public class ValidationLocWarning : ValidationWarning, ILocalizationTextKeyAware
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationLocWarning" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="id">The error identifier.</param>
        /// <param name="message">The error message.</param>
        /// <param name="textKey">The text key.</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public ValidationLocWarning(
            [NotNull] string propertyName,
            [NotNull] string id,
            [NotNull] string message,
            [NotNull] FullyQualifiedResourceKeyBase textKey)
            : base(propertyName, id, message)
        {
            this.TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationLocWarning" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <exception cref="ArgumentNullException">textKey</exception>
        public ValidationLocWarning(
            [NotNull] string propertyName,
            [NotNull] string id,
            [NotNull] string message,
            [NotNull] string textKey)
            : base(propertyName, id, message)
        {
            this.TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
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