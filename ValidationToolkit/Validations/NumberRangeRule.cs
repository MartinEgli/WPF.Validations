// -----------------------------------------------------------------------
// <copyright file="NumberRangeRule.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ValidationToolkit
{
    using System;
    using System.Windows.Controls;

    using Bfa.Common.Validations;

    public class IntegerRangeRule : ValidationRule
    {
        public string Name { get; set; }

        public int Min { get; set; } = int.MinValue;

        public int Max { get; set; } = short.MaxValue;

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty((string)value))
            {
                if (this.Name.Length == 0)
                {
                    this.Name = "Field";
                }

                try
                {
                    if (((string)value).Length > 0)
                    {
                        var val = int.Parse((string)value);
                        if (val > this.Max)
                        {
                            return new ValidationResult(
                                false,
                                new ValidationWarning(this.Name, "max", this.Name + " must be <= " + this.Max + "."));
                        }

                        ;
                        if (val < this.Min)
                        {
                            return new ValidationResult(false, this.Name + " must be >= " + this.Min + ".");
                        }
                    }
                }
                catch (Exception)
                {
                    // Try to match the system generated error message so it does not look out of place.
                    return new ValidationResult(false, this.Name + " is not in a correct numeric format.");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}