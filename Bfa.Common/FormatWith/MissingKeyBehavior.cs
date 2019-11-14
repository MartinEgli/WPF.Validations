﻿// -----------------------------------------------------------------------
// <copyright file="MissingKeyBehavior.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.FormatWith
{
    /// <summary>
    ///     Behavior to use when a parameter is given that has no key in the replacement dictionary
    /// </summary>
    public enum MissingKeyBehavior
    {
        /// <summary>
        ///     Throws a FormatException
        /// </summary>
        ThrowException,

        /// <summary>
        ///     Replaces the parameter with a given fallback string
        /// </summary>
        ReplaceWithFallback,

        /// <summary>
        ///     Ignores the parameter, leaving it unprocessed in the output string
        /// </summary>
        Ignore
    }
}