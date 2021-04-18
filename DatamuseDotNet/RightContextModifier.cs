using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Provides the word that appears to the right of the target as a hint to the API.
    /// </summary>
    public class RightContextModifier : IRequestModifier
    {
        /// <summary>
        /// The word to be used by this modifier.
        /// </summary>
        public string word { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RightContextModifier"/> class.
        /// </summary>
        /// <param name="word">The word to be used by this modifier.</param>
        public RightContextModifier(string word)
        {
            this.word = word;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "rc", word }
            };
        }
    }
}
