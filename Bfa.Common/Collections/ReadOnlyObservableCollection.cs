// -----------------------------------------------------------------------
// <copyright file="ReadOnlyObservableCollection.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;

    /// <summary>
    ///     Read-only wrapper around an ObservableCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.ObjectModel.ReadOnlyCollection{T}" />
    /// <seealso cref="System.Collections.Specialized.INotifyCollectionChanged" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [Serializable]
    public sealed class ReadOnlyObservableCollection<T> : ReadOnlyCollection<T>,
                                                          INotifyCollectionChanged,
                                                          INotifyPropertyChanged
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReadOnlyObservableCollection{T}" /> class.
        /// </summary>
        /// <param name="list">The list.</param>
        private ReadOnlyObservableCollection(IList<T> list)
            : base(list)
        {
            ((INotifyCollectionChanged)this.Items).CollectionChanged += this.HandleCollectionChanged;
            ((INotifyPropertyChanged)this.Items).PropertyChanged += this.HandlePropertyChanged;
        }

        /// <summary>
        ///     CollectionChanged event (per <see cref="INotifyCollectionChanged" />).
        /// </summary>
        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add => this.CollectionChanged += value;
            remove => this.CollectionChanged -= value;
        }

        /// <summary>
        ///     Occurs when the collection changes, either by adding or removing an item.
        /// </summary>
        /// <remarks>
        ///     see <seealso cref="INotifyCollectionChanged" />
        /// </remarks>
        [field: NonSerialized]
        private event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        ///     PropertyChanged event (per <see cref="INotifyPropertyChanged" />).
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.PropertyChanged += value;
            remove => this.PropertyChanged -= value;
        }

        /// <summary>
        ///     Occurs when a property changes.
        /// </summary>
        /// <remarks>
        ///     see <seealso cref="INotifyPropertyChanged" />
        /// </remarks>
        [field: NonSerialized]
        private event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Creates the instance.
        /// </summary>
        /// <typeparam name="TList">The type of the list.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static ReadOnlyObservableCollection<T> CreateInstance<TList>(TList instance)
            where TList : IList<T>, INotifyCollectionChanged, INotifyPropertyChanged
        {
            return new ReadOnlyObservableCollection<T>(instance);
        }

        /// <summary>
        ///     raise CollectionChanged event to any listeners
        /// </summary>
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            this.CollectionChanged?.Invoke(this, args);
        }

        /// <summary>
        ///     raise PropertyChanged event to any listeners
        /// </summary>
        /// <param name="args">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(PropertyChangedEventArgs args) => this.PropertyChanged?.Invoke(this, args);

        /// <summary>
        ///     Handles the collection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) =>
            this.OnCollectionChanged(e);

        /// <summary>
        ///     Handles the property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e) => this.OnPropertyChanged(e);
    }
}