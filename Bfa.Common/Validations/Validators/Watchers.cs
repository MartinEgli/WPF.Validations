// -----------------------------------------------------------------------
// <copyright file="Watchers.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.Validators
{
    using System.ComponentModel;

    using Bfa.Common.Collections;

    using JetBrains.Annotations;

    /// <summary>
    ///     The watchers
    /// </summary>
    internal class Watchers
    {
        /// <summary>
        ///     The collection lock
        /// </summary>
        private readonly object collectionLock = new object();

        /// <summary>
        ///     Gets the watchers collection.
        /// </summary>
        /// <value>
        ///     The watchers collection.
        /// </value>
        private readonly ObservableCollection<Watcher> watchersCollection = new ObservableCollection<Watcher>();

        /// <summary>
        ///     Adds the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="notifyPropertyChanged">The notify property changed.</param>
        public void Add([NotNull] INotifyPropertyChanged notifyPropertyChanged, [NotNull] string propertyName)
        {
            lock (this.collectionLock)
            {
                this.watchersCollection.Add(new Watcher(notifyPropertyChanged, propertyName));
            }
        }

        /// <summary>
        ///     Registers the validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        public void RegisterValidator(Validator validator)
        {
            lock (this.collectionLock)
            {
                foreach (var watcher in this.watchersCollection)
                {
                    watcher.NotifyPropertyChanged.PropertyChanged += (sender, args) =>
                        {
                            if (args.PropertyName == watcher.PropertyName)
                            {
                                validator.Validate();
                            }
                        };
                    //PropertyChangedEventManager.AddHandler(watcher.NotifyPropertyChanged, (sender, args) => validator.Validate(), watcher.PropertyName);
                }
            }
        }
    }
}