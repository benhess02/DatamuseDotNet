using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public abstract class DatamuseRequest
    {
        Dictionary<string, string> modifierParameters;

        public abstract string GetEndpoint();

        public virtual Dictionary<string, string> GetCustomParameters()
        {
            return new Dictionary<string, string>() { };
        }

        public DatamuseRequest(IRequestModifier[] modifiers)
        {
            modifierParameters = new Dictionary<string, string>();
            for (int i = 0; i < modifiers.Length; i++)
            {
                ApplyModifier(modifiers[i]);
            }
        }

        public void ApplyModifier(IRequestModifier modifier)
        {
            Dictionary<string, string> modifierParams = modifier.GetParameters();
            foreach (KeyValuePair<string, string> pair in modifierParams)
            {
                if (!modifierParameters.ContainsKey(pair.Key))
                {
                    modifierParameters.Add(pair.Key, pair.Value);
                }
            }
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = GetCustomParameters();
            foreach(KeyValuePair<string, string> pair in modifierParameters)
            {
                if (!parameters.ContainsKey(pair.Key))
                {
                    parameters.Add(pair.Key, pair.Value);
                }
            }
            return parameters;
        }
    }
}