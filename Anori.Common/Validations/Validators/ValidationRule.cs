// -----------------------------------------------------------------------
// <copyright file="ValidationRule.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.Validators
{
    using System;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationRule class.
    /// </summary>
    /// <seealso cref="ValidationRule" />
    public abstract class ValidationRule
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationRule" /> class.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        protected ValidationRule([NotNull] string ruleName)
        {
            this.RuleName = ruleName ?? throw new ArgumentNullException(nameof(ruleName));
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public string RuleName { get; }
    }
}