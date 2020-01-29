// -----------------------------------------------------------------------
// <copyright file="IComparerTwoValues.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.Rules
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