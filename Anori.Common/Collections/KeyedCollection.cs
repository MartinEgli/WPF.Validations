// -----------------------------------------------------------------------
// <copyright file="KeyedCollection.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Keyed Collection
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="System.Collections.ObjectModel.KeyedCollection{TKey, TItem}" />
    public class KeyedCollection<TKey, TItem> : System.Collections.ObjectModel.KeyedCollection<TKey, TItem>
    {
        /// <summary>
        ///     The delegate null exception message
        /// </summary>
        private const string DelegateNullExceptionMessage = "Delegate passed cannot be null";

        /// <summary>
        ///     The get key for item delegate
        /// </summary>
        private readonly Func<TItem, TKey> getKeyForItemDelegate;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyedCollection{TKey, TItem}" /> class.
        /// </summary>
        /// <param name="getKeyForItemDelegate">The get key for item delegate.</param>
        /// <exception cref="ArgumentNullException">Delegate Null Exception</exception>
        public KeyedCollection(Func<TItem, TKey> getKeyForItemDelegate)
        {
            this.getKeyForItemDelegate = getKeyForItemDelegate
                                         ?? throw new ArgumentNullException(DelegateNullExceptionMessage);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyedCollection{TKey, TItem}" /> class.
        /// </summary>
        /// <param name="getKeyForItemDelegate">The get key for item delegate.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Delegate Null Exception</exception>
        public KeyedCollection(Func<TItem, TKey> getKeyForItemDelegate, IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
            this.getKeyForItemDelegate = getKeyForItemDelegate
                                         ?? throw new ArgumentNullException(DelegateNullExceptionMessage);
        }

        /// <summary>
        ///     Sorts this instance.
        /// </summary>
        public IEnumerable<int> Sort()
        {
            var comparer = Comparer<TItem>.Default;
            return this.Sort(comparer);
        }

        /// <summary>
        ///     Sorts the specified comparison.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public IEnumerable<int> Sort(Comparison<TItem> comparison)
        {
            var newComparer = new Comparer<TItem>(comparison);
            return this.Sort(newComparer);
        }

        /// <summary>
        ///     Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public IEnumerable<int> Sort(IComparer<TItem> comparer)
        {
            if (!(this.Items is List<TItem> list))
            {
                return new List<int>();
            }

            var oldList = list.ToList();
            list.Sort(comparer);

            IList<int> move = new List<int>(list.Count);
            foreach (var item in list)
            {
                move.Add(oldList.IndexOf(item));
            }

            return move;
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        public IEnumerable<int> SortByKeys()
        {
            var comparer = Comparer<TKey>.Default;
            return this.SortByKeys(comparer);
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        /// <param name="keyComparer">The key comparer.</param>
        public IEnumerable<int> SortByKeys(IComparer<TKey> keyComparer)
        {
            var comparer = new Comparer<TItem>(
                (x, y) => keyComparer.Compare(this.GetKeyForItem(x), this.GetKeyForItem(y)));
            return this.Sort(comparer);
        }

        /// <summary>
        ///     Sorts the by keys.
        /// </summary>
        /// <param name="keyComparison">The key comparison.</param>
        public IEnumerable<int> SortByKeys(Comparison<TKey> keyComparison)
        {
            var comparer = new Comparer<TItem>((x, y) => keyComparison(this.GetKeyForItem(x), this.GetKeyForItem(y)));
            return this.Sort(comparer);
        }

        /// <summary>
        ///     When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>
        ///     The key for the specified element.
        /// </returns>
        protected override TKey GetKeyForItem(TItem item)
        {
            return this.getKeyForItemDelegate(item);
        }
    }
}