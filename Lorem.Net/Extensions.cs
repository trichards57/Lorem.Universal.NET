// <copyright file="Extensions.cs" company="PlaceholderCompany">
// Copyright (c) 2015 dochoffiday, xfischer
// Copyright (c) 2016-2025 Tony Richards
//
// This source code is licensed under the MIT license. See LICENSE file for details.
// </copyright>

using System;

namespace LoremNET
{
    /// <summary>
    /// Class containing extension methods to support string manipulation.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Removes the specified pattern.
        /// </summary>
        /// <param name="s">The string to remove <paramref name="pattern"/> from.</param>
        /// <param name="pattern">The pattern to remove.</param>
        /// <returns>A new string with all instances of <paramref name="pattern" /> removed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> and <paramref name="pattern"/> must not be null.</exception>
        internal static string Remove(this string s, string pattern)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "the string must not be null");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern), "the pattern to replace must not be null");
            }

            return s.Replace(pattern, string.Empty);
        }

        /// <summary>
        /// Splits the string using the specified separator.
        /// </summary>
        /// <param name="s">The string to split.</param>
        /// <param name="separator">The separator.</param>
        /// <returns><paramref name="s" /> split into an array of strings.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> and <paramref name="separator"/> must not be null.</exception>
        internal static string[] Split(this string s, string separator)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "the string must not be null");
            }

            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator), "the separator must not be null.");
            }

            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        /// <summary>
        /// Capitalises the first letter.
        /// </summary>
        /// <param name="s">The string to capitalise.</param>
        /// <returns>A new string with the first character capitalised.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> must not be null.</exception>
        internal static string UppercaseFirst(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "the string must not be null");
            }

            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}