using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Defines the types of relations between two words.
    /// </summary>
    /// <remarks>Used with <see cref="RelationModifier"/>.</remarks>
    public enum RelationType
    {
        /// <summary>
        /// The target word is a noun that is modified by the provided word.
        /// </summary>
        NounModifiedBy,

        /// <summary>
        /// The target word is a adjective that is used on the provided word.
        /// </summary>
        AdjectiveUsedOn,

        /// <summary>
        /// The target word is a synonym of the provided word.
        /// </summary>
        Synonym,

        /// <summary>
        /// The target word is statistically associated with the provided word.
        /// </summary>
        Trigger,

        /// <summary>
        /// The target word is an antonym of the provided word.
        /// </summary>
        Antonym,

        /// <summary>
        /// The target word is a kind of the provided word.
        /// </summary>
        KindOf,

        /// <summary>
        /// The target word is more general than the provided word.
        /// </summary>
        MoreGeneralThan,

        /// <summary>
        /// The target word comprises the provided word.
        /// </summary>
        Comprises,

        /// <summary>
        /// The target word is part of the provided word.
        /// </summary>
        PartOf,

        /// <summary>
        /// The target word frequently follows the provided word.
        /// </summary>
        FrequentFollower,

        /// <summary>
        /// The target word frequently appears before the provided word.
        /// </summary>
        FrequentPredecessor,

        /// <summary>
        /// The target word rhymes with the provided word.
        /// </summary>
        Rhyme,

        /// <summary>
        /// The target word is an approximate rhyme of the provided word.
        /// </summary>
        ApproximateRhyme,

        /// <summary>
        /// The target word is a homophone of the provided word. (It sounds the same.)
        /// </summary>
        Homophone,

        /// <summary>
        /// The consonants of the target word match those of the provided word.
        /// </summary>
        ConsonantMatch
    }
}