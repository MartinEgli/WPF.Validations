// -----------------------------------------------------------------------
// <copyright file="MarkupExtensionExtensions.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations
{
    using System;
    using System.Windows;

    using JetBrains.Annotations;

    public static class MarkupExtensionExtensions
    {
        private static Type SharedDpType = typeof(Window).Assembly.GetType("System.Windows.SharedDp");
        public static bool IsSharedDp([CanBeNull] this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj.GetType() == SharedDpType;
        }

    }
}