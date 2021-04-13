using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class DatamuseResultItem
    {
        public string word { get; set; }
        public int score { get; set; }
        public string[] tags { get; set; } = new string[0];
        public string[] definitions { get; set; }
        public string headword { get; set; }
        public int syllableCount { get; set; } = -1;

        public override string ToString()
        {
            return string.Format("\"{0}\" ({1})", word, score);
        }
    }
}