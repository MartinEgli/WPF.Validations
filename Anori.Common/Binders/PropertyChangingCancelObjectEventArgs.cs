// -----------------------------------------------------------------------
// <copyright file="PropertyChangingCancelObjectEventArgs.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Binders
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     PropertyChangingCancelObjectEventArgs class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.PropertyChangingEventArgs" />
    public class PropertyChangingCancelObjectEventArgs : PropertyChangingCancelEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangingCancelEventArgs{T}" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        public PropertyChangingCancelObjectEventArgs([NotNull] string propertyName, [CanBeNull] object originalValue, [CanBeNull] object newValue)
            : base(propertyName)
        {
            this.OriginalObject = originalValue;
            this.NewObject = newValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyChangingCancelObjectEventArgs"/> class.
        /// </summary>
        /// <param name="propertyName">The name of the property whose value is changing.</param>
        protected PropertyChangingCancelObjectEventArgs(string propertyName)
            : base(propertyName)
        {
        }

        /// <summary>
        ///     Gets the original value.
        /// </summary>
        /// <value>
        ///     The original value.
        /// </value>
        [CanBeNull] public virtual object OriginalObject { get; }

        /// <summary>
        ///     Gets the new value.
        /// </summary>
        /// <value>
        ///     The new value.
        /// </value>
        [CanBeNull] public virtual object NewObject { get; set; }
    }
}