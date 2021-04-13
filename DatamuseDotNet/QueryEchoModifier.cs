using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DatamuseDotNet
{
    public class QueryEchoModifier : IRequestModifier
    {
        public IRequestModifier modifier { get; private set; }

        public QueryEchoModifier(IRequestModifier modifier)
        {
            this.modifier = modifier;
        }

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
