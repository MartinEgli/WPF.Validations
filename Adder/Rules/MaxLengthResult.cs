// -----------------------------------------------------------------------
// <copyright file="MaxLengthResult.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System.Text;

    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;
    using Bfa.Common.Validations.Validators;
    using Bfa.Common.Validations.Validators.Interfaces;

    using JetBrains.Annotations;

    public class MaxLengthResult : PropertyValidationResult, IValidationMessage
    {
        public MaxLengthResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            int maxLength,
            [NotNull] string message,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, message, isWarning)
        {
            this.MaxLength = maxLength;
        }

        public int MaxLength { get; }

        public string Id => this.RuleName;

        public string Description =>
            new StringBuilder().Append("Property Name='")
                .Append(this.PropertyName)
                .Append("', Id='")
                .Append(this.Id)
                .Append("', Message='")
                .Append(this.Message)
                .Append("'")
                .ToString();
    }

    public class LocMaxLengthResult : MaxLengthResult, ILocalizationTextKeyAware
    {
        public LocMaxLengthResult(
            bool isValid,
            [NotNull] string ruleName,
            [NotNull] string propertyName,
            string textKey,
            int maxLength,
            [NotNull] string message,
            bool isWarning = false)
            : base(isValid, ruleName, propertyName, maxLength, message, isWarning)
        {
            this.TextKey = textKey;
        }

        public string TextKey { get; }
    }
}