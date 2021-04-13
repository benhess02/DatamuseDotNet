using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public static class Wildcard
    {
        public static string Length(int length)
        {
            string str = "";
            for(int i = 0; i < length; i++)
            {
                str += "?";
            }
            return str;
        }

        public static string MinLength(int length)
        {
            return Length(length) + "*";
        }

        public static string StartsWith(string start)
        {
            return start + "*";
        }

        public static string StartsWith(string start, int totalLength)
        {
            return start + Length(totalLength - start.Length);
        }

        public static string EndsWith(string end)
        {
            return "*" + end;
        }

        public static string EndsWith(string end, int totalLength)
        {
            return Length(totalLength - end.Length) + end;
        }

        public static string StartsEndsWith(string start, string end)
        {
            return start + "*" + end;
        }

        public static string StartsEndsWith(string start, string end, int totalLength)
        {
            return start + Length(totalLength - start.Length - end.Length) + end;
        }
    }
}