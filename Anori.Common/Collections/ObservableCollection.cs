// -----------------------------------------------------------------------
// <copyright file="ObservableCollection.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    ///     The ObservableCollection class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ObservableCollectionBase{T}" />
    public class ObservableCollection<T> : ObservableCollectionBase<T>
    {
        /// <summary>
        ///     The list
        /// </summary>
        private readonly List<T> list;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableCollection{T}" /> class.
        /// </summary>
        public ObservableCollection()
            : base(new List<T>())
        {
            this.list = this.Items as List<T>;
        }

        /// <summary>
        ///     Gets or sets the capacity.
        /// </summary>
        /// <value>
        ///     The capacity.
        /// </value>
        public int Capacity
        {
            get => this.list.Capacity;
            set => this.list.Capacity = value;
        }

        /// <summary>
        ///     As the read only.
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<T> AsReadOnlyCollection() => this.list.AsReadOnly();

        /// <summary>
        ///     Finds the last index.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public int FindLastIndex(Predicate<T> match) => this.list.FindLastIndex(match);

        /// <summary>
        ///     Removes the last.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool RemoveLast(T item)
        {
            var index = this.FindLastIndex(i => Equals(i, item));
            if (index < 0)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }
    }
}