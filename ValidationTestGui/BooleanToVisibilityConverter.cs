// -----------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverter.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui
{
    using System;
    using System.Windows.Data;
    using System.Windows.Markup;

    public class BooleanToVisibilityConverter : MarkupExtension
    {
        private static readonly IValueConverter Instance = new System.Windows.Controls.BooleanToVisibilityConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}