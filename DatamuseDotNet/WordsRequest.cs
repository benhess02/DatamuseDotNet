using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public class WordsRequest : DatamuseRequest
    {
        public WordsRequest(params IRequestModifier[] modifiers)
            : base(modifiers) { }

        public override string GetEndpoint()
        {
            return "/words";
        }
    }
}