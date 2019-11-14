// -----------------------------------------------------------------------
// <copyright file="IComparerTwoValues.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.Rules
{
    /// <summary>
    /// ComparerTwoValues
    /// </summary>
    public interface IComparerTwoValues
    {
        /// <summary>
        /// Gets or sets the value1.
        /// </summary>
        /// <value>
        /// The value1.
        /// </value>
        string Value1 { get; set; }

        /// <summary>
        /// Gets or sets the value2.
        /// </summary>
        /// <value>
        /// The value2.
        /// </value>
        string Value2 { get; set; }
    }
}