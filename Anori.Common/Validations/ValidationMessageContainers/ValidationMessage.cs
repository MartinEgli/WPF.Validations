// -----------------------------------------------------------------------
// <copyright file="ValidationMessage.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers
{
    using System;
    using System.Text;

    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     The abstract ValidationMessage class.
    /// </summary>
    public abstract class ValidationMessage : IValidationMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationMessage" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="id">The error identifier.</param>
        /// <param name="message">The error message.</param>
        protected ValidationMessage([NotNull] string propertyName, [NotNull] string id, [NotNull] string message)
        {
            this.PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [NotNull]
        public string Id { get; }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        [NotNull]
        public string Message { get; }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        [NotNull]
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [NotNull]
        public string Description =>
            new StringBuilder().Append("Property Name='")
                .Append(this.PropertyName)
                .Append("', Id='")
                .Append(this.Id)
                .Append("', Message='")
                .Append(this.Message)
                .Append("'")
                .ToString();

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [NotNull]
        public override string ToString()
        {
            return this.Message;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is IValidationMessage other))
            {
                return false;
            }

            return this.Equals(other);
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(IValidationMessage other)
        {
            if (other == null)
            {
                return false;
            }

            return (this.PropertyName == other.PropertyName && this.Id == other.Id);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.PropertyName.GetHashCode() ^ this.Id.GetHashCode();
        }
    }
}