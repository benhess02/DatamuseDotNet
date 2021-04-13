using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class SoundsLikeModifier : IRequestModifier
    {
        public string word { get; private set; }

        public SoundsLikeModifier(string word)
        {
            this.word = word;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "sl", word }
            };
        }
    }
}
