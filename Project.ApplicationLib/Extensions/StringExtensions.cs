using System;

namespace CommonLib.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Converts first character of string to uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUppercaseFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

    }
}
