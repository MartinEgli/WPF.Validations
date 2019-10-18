// -----------------------------------------------------------------------
// <copyright file="SortedObservableCollectionBase.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Bfa.Common.Validations;

    /// <summary>
    ///     SortedObservableCollectionBase class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ObservableCollectionBase{T}" />
    [Serializable]
    public abstract class SortedObservableCollectionBase<T> : ObservableCollectionBase<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        protected SortedObservableCollectionBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        /// <param name="list">The list.</param>
        protected SortedObservableCollectionBase(List<T> list)
            : base(list)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        protected SortedObservableCollectionBase(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        ///     Called by base class Collection&lt;T&gt; when an item is added to list;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert. The value can be <see langword="null" /> for reference types.</param>
        protected override void InsertItem(int index, T item)
        {
            this.CheckReentrancy();
            this.CollectionInsertItem(index, item);
            this.Sorting();
            var newIndex = this.IndexOf(item);
            this.OnPropertyChanged(CountString);
            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Add, item, newIndex);
        }

        /// <summary>
        ///     Called by base class ObservableCollection&lt;T&gt; when an item is to be moved within the list;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            // Not Used
        }

        /// <summary>
        ///     Called by base class Collection{T} when an item is set in list;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">
        ///     The new value for the element at the specified index. The value can be <see langword="null" /> for
        ///     reference types.
        /// </param>
        protected override void SetItem(int index, T item)
        {
            this.CheckReentrancy();
            var originalItem = this[index];
            this.CollectionSetItem(index, item);
            this.Sorting();
            var newIndex = this.IndexOf(item);
            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, originalItem, item, newIndex);
        }

        /// <summary>
        ///     Orderings this instance.
        /// </summary>
        protected abstract IEnumerable<IndexTransform> Sorting();
    }
}