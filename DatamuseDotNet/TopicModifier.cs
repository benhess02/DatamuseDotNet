using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class TopicModifier : IRequestModifier
    {
        public string[] topicWords { get; private set; }

        public TopicModifier(params string[] topicWords)
        {
            this.topicWords = topicWords;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "topcis", string.Join(",", topicWords) }
            };
        }
    }
}
