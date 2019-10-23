// -----------------------------------------------------------------------
// <copyright file="PropertyChangedEventArgs.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Binders
{
    using JetBrains.Annotations;

    /// <summary>
    /// PropertyChangedEventArgs class.
    /// </summary>
    /// <seealso cref="PropertyChangedEventArgs" />
    public class PropertyChangedEventArgs : System.ComponentModel.PropertyChangedEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangedEventArgs" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="previousValue">The previous value.</param>
        /// <param name="currentValue">The current value.</param>
        public PropertyChangedEventArgs([NotNull] string propertyName, [CanBeNull]  object previousValue, [CanBeNull]  object currentValue)
            : base(propertyName)
        {
            this.PreviousObject = previousValue;
            this.CurrentObject = currentValue;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangedEventArgs" /> class.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected PropertyChangedEventArgs([NotNull] string propertyName)
            : base(propertyName)
        {
        }

        /// <summary>
        ///     Gets the previous object.
        /// </summary>
        /// <value>
        ///     The previous object.
        /// </value>
        [CanBeNull] public virtual object PreviousObject { get; }

        /// <summary>
        ///     Gets the current object.
        /// </summary>
        /// <value>
        ///     The current object.
        /// </value>
        [CanBeNull] public virtual object CurrentObject { get; }
    }
}