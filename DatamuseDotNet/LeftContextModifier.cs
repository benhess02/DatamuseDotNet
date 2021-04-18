using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Provides the word that appears to the left of the target as a hint to the API.
    /// </summary>
    public class LeftContextModifier : IRequestModifier
    {
        /// <summary>
        /// The word to be used by this modifier.
        /// </summary>
        public string word { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftContextModifier"/> class.
        /// </summary>
        /// <param name="word">The word to be used by this modifier.</param>
        public LeftContextModifier(string word)
        {
            this.word = word;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "lc", word }
            };
        }
    }
}
