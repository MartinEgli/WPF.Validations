// -----------------------------------------------------------------------
// <copyright file="FormatWithException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Bfa.Common.FormatWith.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The FormatWithException Class
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public abstract class FormatWithException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatWithException" /> class.
        /// </summary>
        protected FormatWithException()
            : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatWithException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected FormatWithException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatWithException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (
        ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
        /// </param>
        protected FormatWithException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatWithException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected FormatWithException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}