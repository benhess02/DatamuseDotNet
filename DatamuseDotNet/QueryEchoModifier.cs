using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies that the API should echo the query of the provided modifier in it's response.
    /// </summary>
    public class QueryEchoModifier : IRequestModifier
    {
        /// <summary>
        /// The modifier containing the query to be echoed.
        /// </summary>
        public IRequestModifier modifier { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryEchoModifier"/> class.
        /// </summary>
        /// <param name="modifier">The modifier containing the query to be echoed.</param>
        public QueryEchoModifier(IRequestModifier modifier)
        {
            this.modifier = modifier;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = modifier.GetParameters();
            if (parameters.Count > 0 && !parameters.ContainsKey("qe"))
            {
                parameters.Add("qe", parameters.Keys.First());
            }
            return parameters;
        }
    }
}