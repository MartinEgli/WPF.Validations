// -----------------------------------------------------------------------
// <copyright file="PropertyChangingCancelEventArgs.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Binders
{
    using System.ComponentModel;

    using JetBrains.Annotations;

    /// <summary>
    ///     PropertyChangingCancelEventArgs class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.PropertyChangingEventArgs" />
    public class PropertyChangingCancelEventArgs : PropertyChangingEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropertyChangingCancelEventArgs" /> class.
        /// </summary>
        /// <param name="propertyName">The name of the property whose value is changing.</param>
        public PropertyChangingCancelEventArgs([NotNull] string propertyName)
            : base(propertyName)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="PropertyChangingCancelEventArgs" /> is cancel.
        /// </summary>
        /// <value>
        ///     <c>true</c> if cancel; otherwise, <c>false</c>.
        /// </value>
        public bool Cancel { get; set; }
    }
}