using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies that the API should only return words that have a similar meaning to the provided meaning.
    /// </summary>
    public class MeansLikeModifier : IRequestModifier
    {
        /// <summary>
        /// The meaning to use with this modifier.
        /// </summary>
        public string meaning { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansLikeModifier"/> class.
        /// </summary>
        /// <param name="meaning">The meaning to use with this modifier.</param>
        public MeansLikeModifier(string meaning)
        {
            this.meaning = meaning;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "ml", meaning }
            };
        }
    }
}
