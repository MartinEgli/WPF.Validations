// -----------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Strings
{
    using System;
    using System.Security;

    using JetBrains.Annotations;

    /// <summary>
    ///     Secure String Extensions Class
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        ///     Convert a secure string into a normal plain text string.
        /// </summary>
        /// <param name="secure">The secure.</param>
        /// <returns>
        ///     The plain string.
        /// </returns>
        /// <exception cref="ArgumentNullException">secure is null.</exception>
        [NotNull]
        public static string ToPlainString([NotNull] this SecureString secure)
        {
            if (secure == null)
            {
                throw new ArgumentNullException(nameof(secure));
            }

            var plainStr = new System.Net.NetworkCredential(string.Empty, secure).Password;
            return plainStr;
        }

        /// <summary>
        ///     Convert a plain text string into a secure string.
        /// </summary>
        /// <param name="plain">The plain string.</param>
        /// <returns>The secure string.</returns>
        /// <exception cref="ArgumentNullException">plain is null.</exception>
        [NotNull]
        public static SecureString ToSecureString([NotNull] this string plain)
        {
            if (plain == null)
            {
                throw new ArgumentNullException(nameof(plain));
            }

            var secure = new SecureString();
            secure.Clear();
            foreach (var c in plain)
            {
                secure.AppendChar(c);
            }

            secure.MakeReadOnly();
            return secure;
        }
    }
}