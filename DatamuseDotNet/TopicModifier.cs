using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Uses the provided set of words as a hint to the API about the topic of the target text.
    /// </summary>
    public class TopicModifier : IRequestModifier
    {
        /// <summary>
        /// A set of words that define the intended topic.
        /// </summary>
        public string[] topicWords { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicModifier"/> class.
        /// </summary>
        /// <param name="topicWords">A set of words that define the intended topic.</param>
        public TopicModifier(params string[] topicWords)
        {
            this.topicWords = topicWords;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "topcis", string.Join(",", topicWords) }
            };
        }
    }
}
