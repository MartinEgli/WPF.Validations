// -----------------------------------------------------------------------
// <copyright file="ValidationError.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using ValidationToolkit;

    /// <summary>
    ///     The ValidationError class
    /// </summary>
    /// <seealso cref="ValidationMessageBase" />
    public class ValidationError : ValidationMessageBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidationError(string propName, string errorId, string errorMessage)
            : base(propName, errorId, errorMessage)
        {
        }

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
    }
}