using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Represents a request for a set of completion suggestions.
    /// </summary>
    public class SuggestionsRequest : DatamuseRequest
    {
        /// <summary>
        /// The prefix for the suggestions.
        /// </summary>
        public string prefix { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestionsRequest"/> class with the provided prefix and applies the provided modifiers.
        /// </summary>
        /// <param name="prefix">The prefix for the suggestions.</param>
        /// <param name="modifiers">The modifiers to be applied.</param>
        public SuggestionsRequest(string prefix, params IRequestModifier[] modifiers) : base(modifiers)
        {
            this.prefix = prefix;
        }

        /// <inheritdoc/>
        public override string GetEndpoint()
        {
            return "/sug";
        }

        /// <inheritdoc/>
        public override Dictionary<string, string> GetCustomParameters()
        {
            return new Dictionary<string, string>()
            {
                { "s", prefix }
            };
        }
    }
}
