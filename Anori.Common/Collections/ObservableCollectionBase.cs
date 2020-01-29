// -----------------------------------------------------------------------
// <copyright file="ObservableCollectionBase.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;

    /// <summary>
    ///     Implementation of a dynamic data collection based on generic Collection&lt;T&gt;,
    ///     implementing INotifyCollectionChanged to notify listeners
    ///     when items get added, removed or the whole list is refreshed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.ObjectModel.Collection{T}" />
    /// <seealso cref="System.Collections.Specialized.INotifyCollectionChanged" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [Serializable]
    public abstract class ObservableCollectionBase<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        ///     The count string
        /// </summary>
        protected const string CountString = "Count";

        /// <summary>
        ///     This must agree with Binding.IndexerName.  It is declared separately
        ///     here so as to avoid a dependency on PresentationFramework.dll.
        /// </summary>
        protected const string IndexerName = "Item[]";

        /// <summary>
        ///     The monitor
        /// </summary>
        private readonly SimpleMonitor monitor = new SimpleMonitor();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        protected ObservableCollectionBase()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        /// <param name="list">The list.</param>
        protected ObservableCollectionBase(List<T> list)
            : base(list)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollectionBase{T}" /> class.
        /// </summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        protected ObservableCollectionBase(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        ///     Occurs when the collection changes, either by adding or removing an item.
        /// </summary>
        /// <remarks>
        ///     see <seealso cref="INotifyCollectionChanged" />
        /// </remarks>
        [field: NonSerialized]
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        ///     PropertyChanged event (per <see cref="INotifyPropertyChanged" />).
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.PropertyChanged += value;
            remove => this.PropertyChanged -= value;
        }

        /// <summary>
        ///     PropertyChanged event (per <see cref="INotifyPropertyChanged" />).
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Move item at oldIndex to newIndex.
        /// </summary>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        public void Move(int oldIndex, int newIndex)
        {
            this.MoveItem(oldIndex, newIndex);
        }

        /// <summary>
        ///     Disallow reentrant attempts to change this collection. E.g. a event handler
        ///     of the CollectionChanged event is not allowed to make changes to this collection.
        /// </summary>
        /// <remarks>
        ///     typical usage is to wrap e.g. a OnCollectionChanged call with a using() scope:
        ///     <code>
        ///         using (BlockReentrancy())
        ///         {
        ///             CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, item, index));
        ///         }
        /// </code>
        /// </remarks>
        protected IDisposable BlockReentrancy()
        {
            this.monitor.Enter();
            return this.monitor;
        }

        /// <summary> Check and assert for reentrant attempts to change this collection. </summary>
        /// <exception cref="InvalidOperationException">
        ///     raised when changing the collection
        ///     while another collection change is still being notified to other listeners
        /// </exception>
        protected void CheckReentrancy()
        {
            if (!this.monitor.Busy)
            {
                return;
            }

            // we can allow changes if there's only one listener - the problem
            // only arises if reentrant changes make the original event args
            // invalid for later listeners.  This keeps existing code working
            // (e.g. Selector.SelectedItems).
            if ((this.CollectionChanged == null) || (this.CollectionChanged.GetInvocationList().Length <= 1))
            {
                return;
            }

            throw new InvalidOperationException("ObservableCollectionReentrancyNotAllowed");
        }

        /// <summary>
        ///     Called by base class Collection&lt;T&gt; when the list is being cleared;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        protected override void ClearItems()
        {
            this.CheckReentrancy();
            this.CollectionClearItems();
            this.OnPropertyChanged(CountString);
            this.OnPropertyChanged(IndexerName);
            this.OnCollectionReset();
        }

        /// <summary>
        ///     Collections the clear items.
        /// </summary>
        protected void CollectionClearItems()
        {
            base.ClearItems();
        }

        /// <summary>
        ///     Collections the insert item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        protected void CollectionInsertItem(int index, T item)
        {
            base.InsertItem(index, item);
        }

        /// <summary>
        ///     Collections the set item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        protected void CollectionSetItem(int index, T item)
        {
            base.SetItem(index, item);
        }

        /// <summary>
        ///     Copies from.
        /// </summary>
        /// <param name="collection">The collection.</param>
        protected void CopyFrom(IEnumerable<T> collection)
        {
            var items = this.Items;
            if ((collection == null) || (items == null))
            {
                return;
            }

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    items.Add(enumerator.Current);
                }
            }
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
            this.OnPropertyChanged(CountString);
            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
        }

        /// <summary>
        ///     Called by base class ObservableCollection&lt;T&gt; when an item is to be moved within the list;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        protected virtual void MoveItem(int oldIndex, int newIndex)
        {
            this.CheckReentrancy();

            var removedItem = this[oldIndex];

            this.CollectionRemoveItem(oldIndex);
            this.CollectionInsertItem(newIndex, removedItem);

            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Move, removedItem, newIndex, oldIndex);
        }

        /// <summary>
        ///     Raise CollectionChanged event to any listeners.
        ///     Properties/methods modifying this ObservableCollection will raise
        ///     a collection changed event through this virtual method.
        /// </summary>
        /// <remarks>
        ///     When overriding this method, either call its base implementation
        ///     or call <see cref="BlockReentrancy" /> to guard against reentrant collection changes.
        /// </remarks>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged == null)
            {
                return;
            }

            using (this.BlockReentrancy())
            {
                this.CollectionChanged?.Invoke(this, e);
            }
        }

        /// <summary>
        ///     Helper to raise CollectionChanged event to any listeners
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        protected void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
        }

        /// <summary>
        ///     Helper to raise CollectionChanged event to any listeners
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="item">The item.</param>
        /// <param name="index">The index.</param>
        /// <param name="oldIndex">The old index.</param>
        protected void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index, int oldIndex)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index, oldIndex));
        }

        /// <summary>
        ///     Helper to raise CollectionChanged event to any listeners
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="oldItem">The old item.</param>
        /// <param name="newItem">The new item.</param>
        /// <param name="index">The index.</param>
        protected void OnCollectionChanged(
            NotifyCollectionChangedAction action,
            object oldItem,
            object newItem,
            int index)
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, newItem, oldItem, index));
        }

        /// <summary>
        ///     Helper to raise CollectionChanged event with action == Reset to any listeners
        /// </summary>
        protected void OnCollectionReset()
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        ///     Raises a PropertyChanged event (per <see cref="INotifyPropertyChanged" />).
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Helper to raise a PropertyChanged event  /&gt;).
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Called by base class Collection&lt;T&gt; when an item is removed from list;
        ///     raises a CollectionChanged event to any listeners.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        protected override void RemoveItem(int index)
        {
            this.CheckReentrancy();
            var removedItem = this[index];

            this.CollectionRemoveItem(index);

            this.OnPropertyChanged(CountString);
            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, removedItem, index);
        }

        /// <summary>
        ///     Called by base class Collection&lt;T&gt; when an item is set in list;
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

            this.OnPropertyChanged(IndexerName);
            this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, originalItem, item, index);
        }

        /// <summary>
        ///     Collections the remove item.
        /// </summary>
        /// <param name="oldIndex">The old index.</param>
        private void CollectionRemoveItem(int oldIndex)
        {
            base.RemoveItem(oldIndex);
        }

        /// <summary>
        ///     SimpleMonitor class
        /// </summary>
        /// <seealso cref="System.Collections.ObjectModel.Collection{T}" />
        /// <seealso cref="System.Collections.Specialized.INotifyCollectionChanged" />
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
        [Serializable]
        protected class SimpleMonitor : IDisposable
        {
            /// <summary>
            ///     The busy count
            /// </summary>
            private int busyCount;

            /// <summary>
            ///     Gets a value indicating whether this <see cref="SimpleMonitor" /> is busy.
            /// </summary>
            /// <value>
            ///     <c>true</c> if busy; otherwise, <c>false</c>.
            /// </value>
            public bool Busy => this.busyCount > 0;

            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                --this.busyCount;
            }

            /// <summary>
            ///     Enters this instance.
            /// </summary>
            public void Enter()
            {
                ++this.busyCount;
            }
        }
    }
}