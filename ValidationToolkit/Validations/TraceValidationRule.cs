using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Text;

namespace ValidationToolkit
{
    // The debug rule has only one purpose - to report that when it is called.
    public class TraceValidationRule : ValidationRule
    {
        public string PropertyName
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            StringBuilder buidler = new StringBuilder();
            Debug.WriteLine(buidler.Append("TraceValidationRule for '")
                                .Append(PropertyName)
                                .Append("' called. ValidationStep='")
                                .Append(ValidationStep.ToString())
                                .Append("'").ToString());

            return ValidationResult.ValidResult;  // Don't stop the validation process by reporting an error.
        }
    }
}
