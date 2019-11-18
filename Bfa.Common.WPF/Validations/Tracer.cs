// -----------------------------------------------------------------------
// <copyright file="Tracer.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations
{
    using System.Diagnostics;

    /// <summary>
    ///     Tracer
    /// </summary>
    public class Tracer
    {
        /// <summary>
        ///     The topic
        /// </summary>
        public static string Topic;

        /// <summary>
        ///     Logs the validation.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void LogValidation(string msg)
        {
            Debug.WriteLine(msg);
        }

        /// <summary>
        ///     Logs the user defined validation.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void LogUserDefinedValidation(string msg)
        {
            Debug.WriteLine(msg);
        }

        /// <summary>
        ///     Logs the application.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void LogApplication(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}