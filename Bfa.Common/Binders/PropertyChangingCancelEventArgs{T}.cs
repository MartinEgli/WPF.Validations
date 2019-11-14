// -----------------------------------------------------------------------
// <copyright file="PropertyChangingCancelEventArgs{T}.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Binders
{
    using JetBrains.Annotations;

    /// <summary>
    ///     PropertyChangingCancelEventArgs class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.PropertyChangingEventArgs" />
    public class PropertyChangingCancelEventArgs<T> : PropertyChangingCancelObjectEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangingCancelEventArgs{T}" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        public PropertyChangingCancelEventArgs(
            [NotNull] string propertyName,
            [CanBeNull] T originalValue,
            [CanBeNull] T newValue)
            : base(propertyName)
        {
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
        }

        /// <summary>
        ///     Gets the original value.
        /// </summary>
        /// <value>
        ///     The original value.
        /// </value>
        [CanBeNull]
        public T OriginalValue { get; }

        /// <summary>
        ///     Gets the new value.
        /// </summary>
        /// <value>
        ///     The new value.
        /// </value>
        [CanBeNull]
        public T NewValue { get; set; }

        /// <summary>
        ///     Gets the original value.
        /// </summary>
        /// <value>
        ///     The original value.
        /// </value>
        public override object OriginalObject => this.OriginalValue;

        /// <summary>
        ///     Gets the new value.
        /// </summary>
        /// <value>
        ///     The new value.
        /// </value>
        public override object NewObject
        {
            get => this.NewValue;
            set => this.NewValue = (T)value;
        }
    }
}