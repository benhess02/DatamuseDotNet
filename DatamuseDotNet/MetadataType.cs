using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Defines the types of metadata that can be included with a responce.
    /// </summary>
    /// <remarks>Used with <see cref="MetadataModifier"/>.</remarks>
    public enum MetadataType
    {
        /// <summary>
        /// Include definitions with each response item.
        /// </summary>
        Definitions,

        /// <summary>
        /// Include parts of speech with the tags of each response item.
        /// </summary>
        PartsOfSpeech,

        /// <summary>
        /// Include the syllable count of each response item.
        /// </summary>
        SyllableCount,

        /// <summary>
        /// Include the pronunciation with the tags of each response item.
        /// </summary>
        Pronunciation,

        /// <summary>
        /// Include the word frequency with the tags of each response item.
        /// </summary>
        WordFrequency
    }
}