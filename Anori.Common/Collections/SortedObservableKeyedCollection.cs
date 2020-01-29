// -----------------------------------------------------------------------
// <copyright file="SortedObservableKeyedCollection.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Anori.Common.Validations;

    /// <summary>
    ///     SortedObservableKeyedCollection class
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="SortedObservableCollectionBase{T}" />
    public class SortedObservableKeyedCollection<TKey, T> : SortedObservableCollectionBase<T>
    {
        /// <summary>
        ///     The keyed collection
        /// </summary>
        private readonly KeyedCollection<TKey, T> keyedCollection;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SortedObservableKeyedCollection{TKey, T}" /> class.
        /// </summary>
        /// <param name="getKeyForItemDelegate">The get key for item delegate.</param>
        public SortedObservableKeyedCollection(Func<T, TKey> getKeyForItemDelegate)
            : base(new KeyedCollection<TKey, T>(getKeyForItemDelegate))
        {
            this.keyedCollection = this.Items as KeyedCollection<TKey, T>;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SortedObservableKeyedCollection{TKey, T}" /> class.
        /// </summary>
        /// <param name="getKeyForItemDelegate">The get key for item delegate.</param>
        /// <param name="comparer">The comparer.</param>
        public SortedObservableKeyedCollection(Func<T, TKey> getKeyForItemDelegate, IEqualityComparer<TKey> comparer)
            : base(new KeyedCollection<TKey, T>(getKeyForItemDelegate, comparer))
        {
            this.keyedCollection = this.Items as KeyedCollection<TKey, T>;
        }

        /// <summary>
        ///     Orderings this instance.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IndexTransform> Sorting()
        {
            return this.Sort();
        }

        /// <summary>
        ///     Orderings this instance.
        /// </summary>
        protected IEnumerable<IndexTransform> Sort()
        {
            var c = this.keyedCollection.SortByKeys().ToList();
            return IndexTransforms(c);
        }

        /// <summary>
        ///     Indexes the transforms.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        private static IEnumerable<IndexTransform> IndexTransforms(IReadOnlyCollection<int> c)
        {
            var l = new List<IndexTransform>();
            for (var i = 0; i >= c.Count; i++)
            {
                var n = c.ElementAt(i);
                if (i == n)
                {
                    l.Add(new IndexTransform(n, i));
                }
            }

            return l;
        }
    }
}