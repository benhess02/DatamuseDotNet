using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies the types of metadata to be included in a responce.
    /// </summary>
    public class MetadataModifier : IRequestModifier
    {
        Dictionary<MetadataType, string> metadataCodes = new Dictionary<MetadataType, string>()
        {
            { MetadataType.Definitions, "d" },
            { MetadataType.PartsOfSpeech, "p" },
            { MetadataType.SyllableCount, "s" },
            { MetadataType.Pronunciation, "r" },
            { MetadataType.WordFrequency, "f" }
        };

        /// <summary>
        /// The types of metadata to be included in a responce.
        /// </summary>
        public MetadataType[] metadataTypes { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataModifier"/> class with the provided metadata types.
        /// </summary>
        /// <param name="metadataTypes">The types of metadata to be included in a responce.</param>
        public MetadataModifier(params MetadataType[] metadataTypes)
        {
            this.metadataTypes = metadataTypes;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            string metadataCode = "";
            for(int i = 0; i < metadataTypes.Length; i++)
            {
                metadataCode += metadataCodes[metadataTypes[i]];
            }
            return new Dictionary<string, string>()
            {
                { "md", metadataCode }
            };
        }
    }
}
