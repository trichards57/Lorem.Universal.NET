// <copyright file="Extensions.cs" company="PlaceholderCompany">
// Copyright (c) 2015 dochoffiday, xfischer
// Copyright (c) 2016-2025 Tony Richards
//
// This source code is licensed under the MIT license. See LICENSE file for details.
// </copyright>

using System;

namespace LoremNET;

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
        ArgumentNullException.ThrowIfNull(s);
        ArgumentNullException.ThrowIfNull(pattern);

        return s.Replace(pattern, string.Empty);
    }

    /// <summary>
    /// Capitalises the first letter.
    /// </summary>
    /// <param name="s">The string to capitalise.</param>
    /// <returns>A new string with the first character capitalised.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> must not be null.</exception>
    internal static string UppercaseFirst(this string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }

        // Return char and concat substring.
        return char.ToUpperInvariant(s[0]) + s[1..];
    }
}