// -----------------------------------------------------------------------
// <copyright file="ValidationMessageBase.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System.Text;

    /// <summary>
    ///    The abstract ValidationMessageBase class.
    /// </summary>
    public abstract class ValidationMessageBase : IValidationMessage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationMessageBase" /> class.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <param name="errorMessage">The error message.</param>
        protected ValidationMessageBase(string propName, string errorId, string errorMessage)
        {
            this.PropertyName = propName;
            this.Id = errorId;
            this.Message = errorMessage;
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description =>
            new StringBuilder().Append("Property Name='")
                .Append(this.PropertyName)
                .Append("', Id='")
                .Append(this.Id)
                .Append("', Msg='")
                .Append(this.Message)
                .Append("'")
                .ToString();

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