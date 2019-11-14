// -----------------------------------------------------------------------
// <copyright file="ValidationWarningException.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Exceptions
{
    using System;

    using Bfa.Common.Validations.Markers;

    public class ValidationWarningException : Exception, IWarning
    {
        public ValidationWarningException(string message)
            : base(message)
        {
        }
    }
}