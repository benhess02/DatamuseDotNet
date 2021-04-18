using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Specifies the maximum number of results to be included in a responce.
    /// </summary>
    public class MaxResultsModifier : IRequestModifier
    {
        /// <summary>
        /// The maximum number of results to be included in a responce.
        /// </summary>
        public int maxResults { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxResultsModifier"/> class.
        /// </summary>
        /// <param name="maxResults">The maximum number of results to be included in a responce.</param>
        public MaxResultsModifier(int maxResults)
        {
            this.maxResults = maxResults;
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "max", maxResults.ToString() }
            };
        }
    }
}
