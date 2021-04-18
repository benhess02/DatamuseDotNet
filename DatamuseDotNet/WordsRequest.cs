using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Represents a request for a set of words.
    /// </summary>
    public class WordsRequest : DatamuseRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordsRequest"/> class and applies the provided modifiers.
        /// </summary>
        /// <inheritdoc/>
        public WordsRequest(params IRequestModifier[] modifiers)
            : base(modifiers) { }

        /// <inheritdoc/>
        public override string GetEndpoint()
        {
            return "/words";
        }
    }
}