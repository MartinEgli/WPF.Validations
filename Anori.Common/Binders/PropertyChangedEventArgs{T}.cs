// -----------------------------------------------------------------------
// <copyright file="PropertyChangedEventArgs.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Binders
{
    using JetBrains.Annotations;

    /// <summary>
    /// PropertyChangedEventArgs class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="PropertyChangedEventArgs" />
    /// <seealso cref="System.ComponentModel.PropertyChangedEventArgs" />
    public class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangedEventArgs{T}" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="previousValue">The previous value.</param>
        /// <param name="currentValue">The current value.</param>
        public PropertyChangedEventArgs([NotNull] string propertyName, [CanBeNull]  T previousValue, [CanBeNull]  T currentValue)
            : base(propertyName)
        {
            this.PreviousValue = previousValue;
            this.CurrentValue = currentValue;
        }

        /// <summary>
        ///     Gets the previous value.
        /// </summary>
        /// <value>
        ///     The previous value.
        /// </value>
        [CanBeNull] public T PreviousValue { get; }

        /// <summary>
        ///     Gets the current value.
        /// </summary>
        /// <value>
        ///     The current value.
        /// </value>
        [CanBeNull] public T CurrentValue { get; }

        /// <summary>
        ///     Gets the previous object.
        /// </summary>
        /// <value>
        ///     The previous object.
        /// </value>
        public override object PreviousObject => this.PreviousValue;

        /// <summary>
        ///     Gets the current object.
        /// </summary>
        /// <value>
        ///     The current object.
        /// </value>
        public override object CurrentObject => this.CurrentValue;
    }
}