using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies that the API should use the vocabulary corresponding to the provided name.
    /// </summary>
    public class VocabularyModifier : IRequestModifier
    {
        /// <summary>
        /// The name of the voaculary to be used.
        /// </summary>
        public string vocabularyName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VocabularyModifier"/> class.
        /// </summary>
        /// <param name="vocabularyName">The name of the voaculary to be used.</param>
        public VocabularyModifier(string vocabularyName)
        {
            this.vocabularyName = vocabularyName;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "v", vocabularyName }
            };
        }
    }
}
