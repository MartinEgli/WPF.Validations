// -----------------------------------------------------------------------
// <copyright file="ValidationWarningException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Exceptions
{
    using System;

    using Anori.Common.Validations.Markers;

    using JetBrains.Annotations;

    /// <summary>
    ///     The validation warning exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    /// <seealso cref="Anori.Common.Validations.Markers.IWarning" />
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