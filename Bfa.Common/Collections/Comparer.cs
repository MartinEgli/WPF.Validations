// -----------------------------------------------------------------------
// <copyright file="Comparer.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Collections
{
    using System;

    /// <summary>
    ///     The Comparer
    /// </summary>
    /// <typeparam name="T">The Type.</typeparam>
    /// <seealso cref="System.Collections.Generic.Comparer{T}" />
    public class Comparer<T> : System.Collections.Generic.Comparer<T>
    {
        /// <summary>
        ///     The compare function
        /// </summary>
        private readonly Comparison<T> compareFunction;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Comparer{T}" /> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException">comparison is null.</exception>
        public Comparer(Comparison<T> comparison)
        {
            this.compareFunction = comparison ?? throw new ArgumentNullException(nameof(comparison));
        }

        /// <summary>
        ///     Compares the specified argument 1.
        /// </summary>
        /// <param name="x">The argument 1.</param>
        /// <param name="y">The argument 2.</param>
        /// <returns>
        ///     The result.
        /// </returns>
        public override int Compare(T x, T y) => this.compareFunction(x, y);
    }
}