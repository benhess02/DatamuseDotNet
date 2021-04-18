using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies that the API should only return words that have the provided relation(s) to the provided word.
    /// </summary>
    public class RelationModifier : IRequestModifier
    {
        Dictionary<RelationType, string> relationCodes = new Dictionary<RelationType, string>()
        {
            { RelationType.NounModifiedBy, "jja" },
            { RelationType.AdjectiveUsedOn, "jjb" },
            { RelationType.Synonym, "syn" },
            { RelationType.Trigger, "trg" },
            { RelationType.Antonym, "ant" },
            { RelationType.KindOf, "spc" },
            { RelationType.MoreGeneralThan, "gen" },
            { RelationType.Comprises, "com" },
            { RelationType.PartOf, "par" },
            { RelationType.FrequentFollower, "bga" },
            { RelationType.FrequentPredecessor, "bgb" },
            { RelationType.Rhyme, "rhy" },
            { RelationType.ApproximateRhyme, "nry" },
            { RelationType.Homophone, "hom" },
            { RelationType.ConsonantMatch, "cns" }
        };

        /// <summary>
        /// The word to be used by this modifier.
        /// </summary>
        public string word { get; private set; }

        /// <summary>
        /// The relation type to be used by this modifier.
        /// </summary>
        public RelationType[] relationTypes { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationModifier"/> class.
        /// </summary>
        /// <param name="word">The word to be used by this modifier.</param>
        /// <param name="relationTypes">The relation type to be used by this modifier.</param>
        public RelationModifier(string word, params RelationType[] relationTypes)
        {
            this.word = word;
            this.relationTypes = relationTypes;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            for(int i = 0; i < relationTypes.Length; i++)
            {
                string key = "rel_" + relationCodes[relationTypes[i]];
                if (!parameters.ContainsKey(key))
                {
                    parameters.Add(key, word);
                }
            }
            return parameters;
        }
    }
}
