using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class SuggestionsRequest : DatamuseRequest
    {
        public string prefix { get; private set; }

        public SuggestionsRequest(string prefix, params IRequestModifier[] modifiers) : base(modifiers)
        {
            this.prefix = prefix;
        }

        public override string GetEndpoint()
        {
            return "/sug";
        }

        public override Dictionary<string, string> GetCustomParameters()
        {
            return new Dictionary<string, string>()
            {
                { "s", prefix }
            };
        }
    }
}
