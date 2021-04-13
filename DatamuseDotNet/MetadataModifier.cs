using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
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

        public MetadataType[] metadataTypes { get; private set; }

        public MetadataModifier(params MetadataType[] metadataTypes)
        {
            this.metadataTypes = metadataTypes;
        }

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
