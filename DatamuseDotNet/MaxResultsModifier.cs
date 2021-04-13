using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class MaxResultsModifier : IRequestModifier
    {
        public int maxResults { get; private set; }

        public MaxResultsModifier(int maxResults)
        {
            this.maxResults = maxResults;
        }

        public Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { "max", maxResults.ToString() }
            };
        }
    }
}
