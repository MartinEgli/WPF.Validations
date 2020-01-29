// -----------------------------------------------------------------------
// <copyright file="FormatToken.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.FormatWith.Internal
{
    /// <summary>
    ///     FormatToken structure
    /// </summary>
    internal struct FormatToken
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FormatToken" /> struct.
        /// </summary>
        /// <param name="tokenType">Type of the token.</param>
        /// <param name="source">The source.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The length.</param>
        public FormatToken(TokenType tokenType, string source, int startIndex, int length)
        {
            this.TokenType = tokenType;
            this.SourceString = source;
            this.StartIndex = startIndex;
            this.Length = length;
        }

        /// <summary>
        ///      Gets the length of the whole token.
        /// </summary>
        /// <value>
        ///     The length.
        /// </value>
        public int Length { get; }

        /// <summary>
        ///     Gets the complete value.
        ///     This performs a substring operation and allocates a new string object.
        /// </summary>
        public string Raw => this.SourceString.Substring(this.StartIndex, this.Length);

        /// <summary>
        ///   Gets the source format string that the token exists within
        /// </summary>
        /// <value>
        ///     The source string.
        /// </value>
        public string SourceString { get; }

        /// <summary>
        ///     Gets the index of the start of the whole token, relative to the start of the source format string.
        /// </summary>
        /// <value>
        ///     The start index.
        /// </value>
        public int StartIndex { get; }

        /// <summary>
        ///     Gets the type of the token.
        /// </summary>
        /// <value>
        ///     The type of the token.
        /// </value>
        public TokenType TokenType { get; }

        /// <summary>
        ///     Gets the token inner text.
        ///     This performs a substring operation and allocates a new string object.
        /// </summary>
        public string Value =>
            this.TokenType == TokenType.Parameter
                ? this.SourceString.Substring(this.StartIndex + 1, this.Length - 2)
                : this.SourceString.Substring(this.StartIndex, this.Length);
    }
}