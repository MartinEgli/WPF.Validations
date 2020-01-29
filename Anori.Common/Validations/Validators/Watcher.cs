// -----------------------------------------------------------------------
// <copyright file="Watcher.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using System;
    using System.ComponentModel;

    using JetBrains.Annotations;

    /// <summary>
    ///     The watcher
    /// </summary>
    internal class Watcher
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Watcher" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="notifyPropertyChanged">The notify property changed.</param>
        /// <exception cref="ArgumentNullException">
        ///     propertyName
        ///     or
        ///     notifyPropertyChanged
        /// </exception>
        public Watcher([NotNull] INotifyPropertyChanged notifyPropertyChanged, [NotNull] string propertyName)
        {
            this.PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            this.NotifyPropertyChanged =
                notifyPropertyChanged ?? throw new ArgumentNullException(nameof(notifyPropertyChanged));
        }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <value>
        ///     The name of the property.
        /// </value>
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the notify property changed.
        /// </summary>
        /// <value>
        ///     The notify property changed.
        /// </value>
        public INotifyPropertyChanged NotifyPropertyChanged { get; }
    }
}