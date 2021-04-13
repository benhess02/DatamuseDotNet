using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class SpelledLikeModifier : IRequestModifier
    {
        public string word { get; private set; }

        public SpelledLikeModifier(string word)
        {
            this.word = word;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "sp", word }
            };
        }
    }
}
