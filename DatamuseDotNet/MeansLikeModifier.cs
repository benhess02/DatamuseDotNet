using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class MeansLikeModifier : IRequestModifier
    {
        public string word { get; private set; }

        public MeansLikeModifier(string word)
        {
            this.word = word;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "ml", word }
            };
        }
    }
}
