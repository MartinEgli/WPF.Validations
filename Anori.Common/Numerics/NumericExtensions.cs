// -----------------------------------------------------------------------
// <copyright file="NumericExtensions.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Numerics
{
    using System;

    /// <summary>
    ///     Numeric Extensions
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        ///     Determines whether the specified object is numeric.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     <c>true</c> if the specified object is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this object obj)
        {
            return (obj != null) && obj.GetType().IsNumeric();
        }

        /// <summary>
        ///     Determines whether the specified type is numeric.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            var typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;

                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.String:
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        ///     Determines whether this instance is integer.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     <c>true</c> if the specified object is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger(this object obj)
        {
            return (obj != null) && obj.GetType().IsUnsigned();
        }

        /// <summary>
        ///     Determines whether this instance is unsigned.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///     <c>true</c> if the specified object is unsigned; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUnsigned(this object obj)
        {
            return (obj != null) && obj.GetType().IsUnsigned();
        }

        /// <summary>
        ///     Determines whether the specified type is unsigned.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is unsigned; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUnsigned(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            var typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;

                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.String:
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        ///     Determines whether the specified type is integer.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the specified type is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            var typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;

                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.String:
                    return false;

                default:
                    return false;
            }
        }
    }
}