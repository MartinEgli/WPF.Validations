// -----------------------------------------------------------------------
// <copyright file="IndexTransform.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    /// <summary>
    ///
    /// </summary>
    public struct IndexTransform
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexTransform"/> struct.
        /// </summary>
        /// <param name="newIndex">The new index.</param>
        /// <param name="oldIndex">The old index.</param>
        public IndexTransform(int newIndex, int oldIndex)
        {
            this.New = newIndex;
            this.Old = oldIndex;
        }

        /// <summary>
        /// Gets the old.
        /// </summary>
        /// <value>
        /// The old.
        /// </value>
        public int Old { get; }

        /// <summary>
        /// Gets the new.
        /// </summary>
        /// <value>
        /// The new.
        /// </value>
        public int New { get; }
    }
}