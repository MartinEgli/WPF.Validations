// -----------------------------------------------------------------------
// <copyright file="SortedObservableCollection.cs" company="Anori Soft">
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
    public class SortedObservableCollection<TKey, T> : SortedObservableCollectionBase<T>
    {
        /// <summary>
        ///     The get key for item delegate
        /// </summary>
        private readonly Func<T, TKey> getKeyForItemDelegate;

        /// <summary>
        ///     The keyed collection
        /// </summary>
        private readonly List<T> list;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SortedObservableCollection{TKey, T}" /> class.
        /// </summary>
        /// <param name="getKeyForItemDelegate">The get key for item delegate.</param>
        public SortedObservableCollection(Func<T, TKey> getKeyForItemDelegate)
            : base(new List<T>())
        {
            this.getKeyForItemDelegate = getKeyForItemDelegate;
            this.list = this.Items as List<T>;
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        public IEnumerable<IndexTransform> SortByKeys()
        {
            var comparer = Comparer<TKey>.Default;
            return this.SortByKeys(comparer);
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        /// <param name="keyComparer">The key comparer.</param>
        public IEnumerable<IndexTransform> SortByKeys(IComparer<TKey> keyComparer)
        {
            var comparer = new Comparer<T>((x, y) => keyComparer.Compare(this.GetKeyForItem(x), this.GetKeyForItem(y)));
            return this.Sort(comparer);
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        /// <param name="keyComparison">The key comparison.</param>
        public IEnumerable<IndexTransform> SortByKeys(Comparison<TKey> keyComparison)
        {
            var oldList = this.list.ToList();

            var comparer = new Comparer<T>((x, y) => keyComparison(this.GetKeyForItem(x), this.GetKeyForItem(y)));
            this.list.Sort(comparer);

            IList<int> move = new List<int>(this.list.Count);
            foreach (var item in this.list)
            {
                move.Add(oldList.IndexOf(item));
            }

            return IndexTransforms(move);
        }

        /// <summary>
        ///     When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>
        ///     The key for the specified element.
        /// </returns>
        protected TKey GetKeyForItem(T item)
        {
            return this.getKeyForItemDelegate(item);
        }

        /// <summary>
        ///     Orderings this instance.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IndexTransform> Sorting()
        {
            return this.SortByKeys();
        }

        /// <summary>
        ///     Orderings this instance.
        /// </summary>
        protected IEnumerable<IndexTransform> Sort()
        {
            var oldList = this.list.ToList();
            var comparer = Comparer<T>.Default;
            this.list.Sort(comparer);

            IList<int> move = new List<int>(this.list.Count);
            foreach (var item in this.list)
            {
                move.Add(oldList.IndexOf(item));
            }

            return IndexTransforms(move);
        }

        /// <summary>
        ///     Sorts the specified comparison.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public IEnumerable<IndexTransform> Sort(Comparison<T> comparison)
        {
            var newComparer = new Comparer<T>(comparison);
            return this.Sort(newComparer);
        }

        /// <summary>
        ///     Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public IEnumerable<IndexTransform> Sort(IComparer<T> comparer)
        {
            var oldList = this.list.ToList();
            this.list.Sort(comparer);

            IList<int> move = new List<int>(this.list.Count);
            foreach (var item in this.list)
            {
                move.Add(oldList.IndexOf(item));
            }

            return IndexTransforms(move);
        }

        /// <summary>
        ///     Indexes the transforms.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        private static IEnumerable<IndexTransform> IndexTransforms(IEnumerable<int> c)
        {
            var l = new List<IndexTransform>();

            for (var i = 0; i >= c.Count(); i++)
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