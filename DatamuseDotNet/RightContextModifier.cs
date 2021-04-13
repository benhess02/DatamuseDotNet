using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class RightContextModifier : IRequestModifier
    {
        public string word { get; private set; }

        public RightContextModifier(string word)
        {
            this.word = word;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "rc", word }
            };
        }
    }
}
