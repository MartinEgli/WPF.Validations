// -----------------------------------------------------------------------
// <copyright file="ReplacementResult.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith
{
    /// <summary>
    ///     Replacement Result
    /// </summary>
    public struct ReplacementResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReplacementResult" /> struct.
        /// </summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="value">The value.</param>
        public ReplacementResult(bool success, object value)
        {
            this.Success = success;
            this.Value = value;
        }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="ReplacementResult" /> is success.
        /// </summary>
        /// <value>
        ///     <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public object Value { get; }
    }
}