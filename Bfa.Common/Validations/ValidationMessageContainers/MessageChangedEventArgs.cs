// -----------------------------------------------------------------------
// <copyright file="MessageChangedEventArgs.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers
{
    using System;

    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    ///     MessageChangedEventArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MessageChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageChangedEventArgs" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="propertyName">Name of the property.</param>
        public MessageChangedEventArgs(IValidationMessage message, string propertyName)
        {
            this.Message = message;
            this.PropertyName = propertyName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageChangedEventArgs" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public MessageChangedEventArgs(string propertyName)
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