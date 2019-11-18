// -----------------------------------------------------------------------
// <copyright file="LocMaxLengthWarning.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationRules
{
    using JetBrains.Annotations;

    using WPFLocalizeExtension.Providers;

    /// <summary>
    /// The loc maximum length warning
    /// </summary>
    /// <seealso cref="Bfa.Common.WPF.Validations.ValidationRules.ValidationRuleLocWarning" />
    public class LocMaxLengthWarning : ValidationRuleLocWarning {
        /// <summary>
        /// Gets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public int MaxLength { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LocMaxLengthWarning"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="textKey">The text key.</param>
        /// <param name="maxLength">The maximum length.</param>
        public LocMaxLengthWarning([NotNull] string message, [NotNull] FullyQualifiedResourceKeyBase textKey, int maxLength)
            : base(message, textKey)
        {
            this.MaxLength = maxLength;
        }
    }
}