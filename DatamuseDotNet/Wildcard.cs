using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Provides a set of methods for generating wildcard search strings.
    /// </summary>
    public static class Wildcard
    {
        /// <summary>
        /// Matches with strings of the provided length.
        /// </summary>
        public static string Length(int length)
        {
            string str = "";
            for(int i = 0; i < length; i++)
            {
                str += "?";
            }
            return str;
        }

        /// <summary>
        /// Matches with strings of at least the provided length.
        /// </summary>
        public static string MinLength(int length)
        {
            return Length(length) + "*";
        }

        /// <summary>
        /// Matches with strings that start with the provided string.
        /// </summary>
        public static string StartsWith(string start)
        {
            return start + "*";
        }

        /// <summary>
        /// Matches with strings that start with the provided string and are of the provided total length.
        /// </summary>
        public static string StartsWith(string start, int totalLength)
        {
            return start + Length(totalLength - start.Length);
        }

        /// <summary>
        /// Matches with strings that end with the provided string.
        /// </summary>
        public static string EndsWith(string end)
        {
            return "*" + end;
        }

        /// <summary>
        /// Matches with strings that end with the provided string and are of the provided total length.
        /// </summary>
        public static string EndsWith(string end, int totalLength)
        {
            return Length(totalLength - end.Length) + end;
        }

        /// <summary>
        /// Matches with strings that start and end with the provided strings.
        /// </summary>
        public static string StartsEndsWith(string start, string end)
        {
            return start + "*" + end;
        }

        /// <summary>
        /// Matches with strings that start and end with the provided strings and are of the provided total length.
        /// </summary>
        public static string StartsEndsWith(string start, string end, int totalLength)
        {
            return start + Length(totalLength - start.Length - end.Length) + end;
        }
    }
}