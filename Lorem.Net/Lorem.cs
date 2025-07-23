// <copyright file="Lorem.cs" company="PlaceholderCompany">
// Copyright (c) 2015 dochoffiday, xfischer
// Copyright (c) 2016-2025 Tony Richards
//
// This source code is licensed under the MIT license. See LICENSE file for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LoremNET;

/// <summary>
/// Class to generate random values of various types.
/// </summary>
public static class Lorem
{
    /// <summary>
    /// Returns true <paramref name="successes"/> times out of <paramref name="attempts"/>.
    /// </summary>
    /// <param name="successes">The number of successes per <paramref name="attempts"/>.</param>
    /// <param name="attempts">The attempts.</param>
    /// <returns><c>true</c> on success, otherwise <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="successes"/> must be greater than or equal to 0 and <paramref name="attempts"/> must be greater than 0.</exception>
    /// <exception cref="ArgumentException"><paramref name="successes"/> is greater than <paramref name="attempts"/>.</exception>
    public static bool Chance(int successes, int attempts)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(successes, 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(attempts, 1);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(successes, attempts);

        var number = System.Random.Shared.Next(1, attempts);

        return number <= successes;
    }

    /// <summary>
    /// Creates a random DateTime between the given date and now.
    /// </summary>
    /// <param name="startYear">The minimum year.</param>
    /// <param name="startMonth">The minimum month.</param>
    /// <param name="startDay">The minimum day.</param>
    /// <returns>A DateTime.</returns>
    public static DateTime DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1)
        => DateTime(new DateTime(startYear, startMonth, startDay), System.DateTime.Now);

    /// <summary>
    /// Creates a random DateTime between the given date and now.
    /// </summary>
    /// <param name="min">The minimum date.</param>
    /// <returns>A DateTime.</returns>
    public static DateTime DateTime(DateTime min)
        => DateTime(min, System.DateTime.Now);

    /// <summary>
    /// Creates a random DateTime between the given minimum and maximum dates.
    /// </summary>
    /// <param name="min">The minimum date.</param>
    /// <param name="max">The maximum date.</param>
    /// <returns>A DateTime.</returns>
    /// <remarks>From http://stackoverflow.com/a/1483677/234132.</remarks>
    /// <exception cref="ArgumentException"><paramref name="max"/> must be greater than or equal to <paramref name="min"/>.</exception>
    public static DateTime DateTime(DateTime min, DateTime max)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(max, min);

        var timeSpan = max - min;
        var newSpan = new TimeSpan(0, System.Random.Shared.Next(0, (int)timeSpan.TotalMinutes), 0);

        return min + newSpan;
    }

    /// <summary>
    /// Creates a random email address of the type random1@random2.com.
    /// </summary>
    /// <returns>A random email address.</returns>
    public static string Email()
    {
        return $"{Words(1, false)}@{Words(1, false)}.com";
    }

    /// <summary>
    /// Creates a random item from the given enum.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <returns>A random <typeparamref name="TEnum"/>.</returns>
    /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> must be an enum.</exception>
    public static TEnum Enum<TEnum>()
        where TEnum : struct, Enum
    {
        var v = System.Enum.GetValues<TEnum>();
        return v[System.Random.Shared.Next(v.Length)];
    }

    /// <summary>
    /// Creates a random hexidecimal number in string format.
    /// </summary>
    /// <param name="digits">The number of digits required.</param>
    /// <returns>A string created using the 'X' format string.</returns>
    /// <remarks>From http://stackoverflow.com/a/1054087/234132.</remarks>
    /// <exception cref="ArgumentException"><paramref name="digits"/> must be greater than 0.</exception>
    public static string HexNumber(int digits)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(digits, 0);

        var buffer = new byte[digits / 2];
        System.Random.Shared.NextBytes(buffer);

        var result = string.Concat(buffer.Select(x => x.ToString("X2", CultureInfo.InvariantCulture)));

        if (digits % 2 == 0)
        {
            return result;
        }

        return result + System.Random.Shared.Next(16).ToString("X", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Creates a random lowercase letter.
    /// </summary>
    /// <returns>A random character between 'a' and 'z' (inclusive).</returns>
    public static char Letter()
    {
        var charNumber = System.Random.Shared.Next(0, 26);
        return (char)('a' + charNumber);
    }

    /// <summary>
    /// Creates a random paragraph with <paramref name="sentenceCount"/> sentences and <paramref name="wordCount"/> words per sentence.
    /// </summary>
    /// <param name="wordCount">The number of words per sentence.</param>
    /// <param name="sentenceCount">The number of sentences.</param>
    /// <returns>A string containing the generated paragraph.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCount"/> and <paramref name="sentenceCount"/> must be greater than 0.</exception>
    public static string Paragraph(int wordCount, int sentenceCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCount, 1);

        return Paragraph(wordCount, wordCount, sentenceCount, sentenceCount);
    }

    /// <summary>
    /// Creates a random paragraph with <paramref name="sentenceCount"/> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words per sentence.</param>
    /// <param name="wordCountMax">The maximum number of words per sentence.</param>
    /// <param name="sentenceCount">The number of sentences.</param>
    /// <returns>A string containing the generated paragraph.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCountMin"/>, <paramref name="wordCountMax"/> and <paramref name="sentenceCount"/> must be greater than 0.</exception>
    /// <exception cref="ArgumentException"><paramref name="wordCountMax"/> must be greater than or equal to <paramref name="wordCountMin"/>.</exception>
    public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);

        return Paragraph(wordCountMin, wordCountMax, sentenceCount, sentenceCount);
    }

    /// <summary>
    /// Creates a random paragraph with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words per sentence.</param>
    /// <param name="wordCountMax">The maximum number of words per sentence.</param>
    /// <param name="sentenceCountMin">The minimum number of sentences.</param>
    /// <param name="sentenceCountMax">The maximum number of sentences.</param>
    /// <returns>A string containing the generated paragraph.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="wordCountMin"/>, <paramref name="wordCountMax"/>, <paramref name="sentenceCountMin"/> and <paramref name="sentenceCountMax"/>
    ///   must all be greater than 0.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///   <paramref name="wordCountMax"/> must be greater than or equal to <paramref name="wordCountMin"/>
    ///   and <paramref name="sentenceCountMax"/> must be greater than or equal to <paramref name="sentenceCountMin"/>.
    /// </exception>
    public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, sentenceCountMin);

        var source = string.Join(" ", Enumerable.Range(0, System.Random.Shared.Next(sentenceCountMin, sentenceCountMax)).Select(x => Sentence(wordCountMin, wordCountMax)));

        return source.Trim();
    }

    /// <summary>
    /// Creates <paramref name="paragraphCount"/> paragraphs with <paramref name="sentenceCount"/> sentences and <paramref name="wordCount"/> words per sentence.
    /// </summary>
    /// <param name="wordCount">The number of words per sentence.</param>
    /// <param name="sentenceCount">The number of sentences.</param>
    /// <param name="paragraphCount">The number of paragraphs.</param>
    /// <returns>An IEnumerable containing the generated paragraphs.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="wordCount"/>, <paramref name="sentenceCount"/> and <paramref name="paragraphCount"/>
    ///   must all be greater than 0.
    /// </exception>
    public static IEnumerable<string> Paragraphs(int wordCount, int sentenceCount, int paragraphCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCount, 1);

        return Paragraphs(wordCount, wordCount, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
    }

    /// <summary>
    /// Creates <paramref name="paragraphCount"/> paragraphs with <paramref name="sentenceCount"/> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words per sentence.</param>
    /// <param name="wordCountMax">The maximum number of words per sentence.</param>
    /// <param name="sentenceCount">The number of sentences.</param>
    /// <param name="paragraphCount">The paragraph count.</param>
    /// <returns>An IEnumerable containing the generated paragraphs.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="wordCountMin"/>, <paramref name="wordCountMax"/>, <paramref name="sentenceCount"/> and <paramref name="paragraphCount"/>
    ///   must all be greater than 0.
    /// </exception>
    /// <exception cref="ArgumentException"><paramref name="wordCountMax"/> must be greater than or equal to <paramref name="wordCountMin"/>.</exception>
    public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCount, int paragraphCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);

        return Paragraphs(wordCountMin, wordCountMax, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
    }

    /// <summary>
    /// Creates <paramref name="paragraphCount"/> paragraphs with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words per sentence.</param>
    /// <param name="wordCountMax">The maximum number of words per sentence.</param>
    /// <param name="sentenceCountMin">The minimum number of sentences.</param>
    /// <param name="sentenceCountMax">The maximum number of sentences.</param>
    /// <param name="paragraphCount">The paragraph count.</param>
    /// <returns>An IEnumerable containing the generated paragraphs.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="wordCountMin"/>, <paramref name="wordCountMax"/>, <paramref name="sentenceCountMin"/>, <paramref name="sentenceCountMax"/>
    ///   and <paramref name="paragraphCount"/> must all be greater than 0.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///   <paramref name="wordCountMax"/> must be greater than or equal to <paramref name="wordCountMin"/>
    ///   and <paramref name="sentenceCountMax"/> must be greater than or equal to <paramref name="sentenceCountMin"/>.
    /// </exception>
    public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCount, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, sentenceCountMin);

        return Paragraphs(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax, paragraphCount, paragraphCount);
    }

    /// <summary>
    /// Creates between <paramref name="paragraphCountMin"/> and <paramref name="paragraphCountMin"/> paragraphs with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words per sentence.</param>
    /// <param name="wordCountMax">The maximum number of words per sentence.</param>
    /// <param name="sentenceCountMin">The minimum number of sentences.</param>
    /// <param name="sentenceCountMax">The maximum number of sentences.</param>
    /// <param name="paragraphCountMin">The minimum number of paragraphs.</param>
    /// <param name="paragraphCountMax">The maximum number of paragraphs.</param>
    /// <returns>An IEnumerable containing the generated paragraphs.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///   <paramref name="wordCountMin"/>, <paramref name="wordCountMax"/>, <paramref name="sentenceCountMin"/>, <paramref name="sentenceCountMax"/>,
    ///   <paramref name="paragraphCountMin"/> and <paramref name="paragraphCountMax"/> must all be greater than 0.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///   <paramref name="wordCountMax"/> must be greater than or equal to <paramref name="wordCountMin"/>,
    ///   <paramref name="sentenceCountMax"/> must be greater than or equal to <paramref name="sentenceCountMin"/>
    ///   and <paramref name="paragraphCountMax"/> must be greater than or equal to <paramref name="paragraphCountMin"/>.
    /// </exception>
    public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCountMin, int paragraphCountMax)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);
        ArgumentOutOfRangeException.ThrowIfLessThan(sentenceCountMax, sentenceCountMin);
        ArgumentOutOfRangeException.ThrowIfLessThan(paragraphCountMax, paragraphCountMin);

        return Enumerable.Range(0, System.Random.Shared.Next(paragraphCountMin, paragraphCountMax)).Select(p => Paragraph(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax));
    }

    /// <summary>
    /// Picks a random item from the provided array.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    /// <param name="items">The items to pick from.</param>
    /// <returns>A random element from <paramref name="items"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="items"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="items"/> is empty.</exception>
    public static T Random<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentOutOfRangeException.ThrowIfLessThan(items.Length, 1);

        var index = System.Random.Shared.Next(items.Length);

        return items[index];
    }

    /// <summary>
    /// Creates a random sentence with <paramref name="wordCount"/> words.
    /// </summary>
    /// <param name="wordCount">The word count for the sentence.</param>
    /// <returns>A string containing the generated sentence.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCount"/> must be greater than 0.</exception>
    public static string Sentence(int wordCount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCount, 1);

        return Sentence(wordCount, wordCount);
    }

    /// <summary>
    /// Creates a random sentence with between <paramref name="wordCountMin"/> and <paramref name="wordCountMax" /> words.
    /// </summary>
    /// <param name="wordCountMin">The minimum word count for the sentence.</param>
    /// <param name="wordCountMax">The maximum word count for the sentence.</param>
    /// <returns>A string containing the generated words.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCountMin"/> and <paramref name="wordCountMax"/> must be greater than 0.</exception>
    /// <exception cref="ArgumentException"><paramref name="wordCountMax"/> is less than <paramref name="wordCountMin"/>.</exception>
    public static string Sentence(int wordCountMin, int wordCountMax)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);

        return $"{Words(wordCountMin, wordCountMax, true, true)}.".Replace(",.", ".").Remove("..");
    }

    /// <summary>
    /// Creates a string containing <paramref name="wordCount"/> words.
    /// </summary>
    /// <param name="wordCount">The number of words to generate.</param>
    /// <param name="uppercaseFirstLetter">if set to <c>true</c>, capitalises the first letter.</param>
    /// <param name="includePunctuation">if set to <c>true</c>, includes punctuation in the string.</param>
    /// <returns>A string containing the generated words.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCount"/> must be greater than 0.</exception>
    public static string Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCount, 1);

        return Words(wordCount, wordCount, uppercaseFirstLetter, includePunctuation);
    }

    /// <summary>
    /// Creates a string containing between <paramref name="wordCountMin"/> and <paramref name="wordCountMax"/> words.
    /// </summary>
    /// <param name="wordCountMin">The minimum number of words.</param>
    /// <param name="wordCountMax">The maximum number of words.</param>
    /// <param name="uppercaseFirstLetter">if set to <c>true</c> capitalises the first letter.</param>
    /// <param name="includePunctuation">if set to <c>true</c> includes punctuation in the string.</param>
    /// <returns>A string containing the generated words.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="wordCountMin"/> and <paramref name="wordCountMax"/> must be greater than 0.</exception>
    /// <exception cref="ArgumentException"><paramref name="wordCountMax"/> is less than <paramref name="wordCountMin"/>.</exception>
    public static string Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMin, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(wordCountMax, wordCountMin);

        var source = string.Join(" ", Source.WordList(includePunctuation).Take(System.Random.Shared.Next(wordCountMin, wordCountMax)));

        if (uppercaseFirstLetter)
        {
            source = source.UppercaseFirst();
        }

        return source;
    }
}