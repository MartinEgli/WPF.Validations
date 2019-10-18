// -----------------------------------------------------------------------
// <copyright file="ErrorsChangedEventArgs.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;

    /// <summary>
    ///     ErrorsChangedEventArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ErrorsChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ErrorsChangedEventArgs" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="propertyName">Name of the property.</param>
        public ErrorsChangedEventArgs(IValidationMessage message, string propertyName)
        {
            this.Message = message;
            this.PropertyName = propertyName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ErrorsChangedEventArgs" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public ErrorsChangedEventArgs(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public IValidationMessage Message { get; }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        public string PropertyName { get; }
    }
}