﻿// -----------------------------------------------------------------------
// <copyright file="NoFallbackException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     The NoFallbackException Class
    /// </summary>
    /// <seealso cref="Anori.Common.FormatWith.Exceptions.FormatWithException" />
    [Serializable]
    public sealed class NoFallbackException : FormatWithException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoFallbackException" /> class.
        /// </summary>
        public NoFallbackException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoFallbackException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoFallbackException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoFallbackException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (
        ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
        /// </param>
        public NoFallbackException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NoFallbackException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        public NoFallbackException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}