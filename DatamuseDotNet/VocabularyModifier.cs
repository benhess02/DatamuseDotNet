using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class VocabularyModifier : IRequestModifier
    {
        public string vocabularyName { get; private set; }

        public VocabularyModifier(string vocabularyName)
        {
            this.vocabularyName = vocabularyName;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "v", vocabularyName }
            };
        }
    }
}
