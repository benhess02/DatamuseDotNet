using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies that the API should only return words that sound similar to the provided word.
    /// </summary>
    public class SpelledLikeModifier : IRequestModifier
    {
        /// <summary>
        /// The word to be used by this modifier.
        /// </summary>
        public string word { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpelledLikeModifier"/> class.
        /// </summary>
        /// <param name="word">The word to be used by this modifier.</param>
        public SpelledLikeModifier(string word)
        {
            this.word = word;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "sp", word }
            };
        }
    }
}
