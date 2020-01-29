// -----------------------------------------------------------------------
// <copyright file="IValidationMessage.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers.Interfaces
{
    /// <summary>
    /// Validation Message Interface
    /// </summary>
    public interface IValidationMessage
    {
        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        string Id { get; }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        string Message { get; }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        string PropertyName { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        string Description { get; }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}