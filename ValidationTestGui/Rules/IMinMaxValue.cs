// -----------------------------------------------------------------------
// <copyright file="IMinMaxValue.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    /// <summary>
    ///
    /// </summary>
    public interface IMinMaxValue
    {
        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        double Min { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        double Value { get; }

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        double Max { get; }
    }
}