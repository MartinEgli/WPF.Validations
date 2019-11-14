﻿// -----------------------------------------------------------------------
// <copyright file="ValidationError.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers
{
    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The ValidationError class
    /// </summary>
    /// <seealso cref="ValidationMessage" />
    public class ValidationError : ValidationMessage  , IValidationError
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="id">The error identifier.</param>
        /// <param name="message">The error message.</param>
        public ValidationError([NotNull] string propertyName, [NotNull] string id, [NotNull] string message)
            : base(propertyName, id, message)
        {
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Message;
        }
    }
}