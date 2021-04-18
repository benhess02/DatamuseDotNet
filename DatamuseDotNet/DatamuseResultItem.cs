using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Represents an item in a response from the API.
    /// </summary>
    public class DatamuseResultItem
    {
        /// <summary>
        /// The word or phrase represented by this result item.
        /// </summary>
        public string word { get; set; }

        /// <summary>
        /// The ranking score of this result item.
        /// </summary>
        public int score { get; set; }

        /// <summary>
        /// The tags included in this result.
        /// </summary>
        public string[] tags { get; set; }

        /// <summary>
        /// The definitions included in this result.
        /// </summary>
        /// <remarks>Only available if <see cref="MetadataModifier"/> is used with <see cref="MetadataType.Definitions"/>.</remarks>
        public string[] definitions { get; set; }

        /// <summary>
        /// The form of the word which is defined by the definitions field.
        /// </summary>
        /// <remarks>Only available if <see cref="MetadataModifier"/> is used with <see cref="MetadataType.Definitions"/>.</remarks>
        public string headword { get; set; }

        /// <summary>
        /// The number of syllables in this item's word.
        /// </summary>
        /// <remarks>Only available if <see cref="MetadataModifier"/> is used with <see cref="MetadataType.SyllableCount"/>.</remarks>
        public int syllableCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("\"{0}\" ({1})", word, score);
        }
    }
}