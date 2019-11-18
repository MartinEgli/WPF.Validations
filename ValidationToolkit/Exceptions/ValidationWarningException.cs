// -----------------------------------------------------------------------
// <copyright file="ValidationWarningException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Exceptions
{
    using System;

    using Bfa.Common.Validations.Markers;

    using JetBrains.Annotations;

    /// <summary>
    ///     The validation warning exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="Bfa.Common.Validations.Markers.IWarning" />
    public class ValidationWarningException : Exception, IWarning
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationWarningException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationWarningException([NotNull] string message)
            : base(message)
        {
        }
    }
}