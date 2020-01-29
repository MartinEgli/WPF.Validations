// -----------------------------------------------------------------------
// <copyright file="LocTextBindingNullItemsException.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     LocTextBindingNoKeyException Class
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class LocTextBindingNullItemsException : LocTextBindingException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingNullItemsException" /> class.
        /// </summary>
        public LocTextBindingNullItemsException()
            : base(Resources.ExceptionStrings.LocTextBindingNoKeyExceptionString)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingNullItemsException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LocTextBindingNullItemsException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingNullItemsException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (
        ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
        /// </param>
        public LocTextBindingNullItemsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingNullItemsException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected LocTextBindingNullItemsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}