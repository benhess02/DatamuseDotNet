using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Represents a request to the Datamuse API.
    /// </summary>
    public abstract class DatamuseRequest
    {
        Dictionary<string, string> modifierParameters;

        /// <summary>
        /// Returns the API endpoint used by this request.
        /// </summary>
        public abstract string GetEndpoint();

        /// <summary>
        /// Returns the parameters which are specific to this request regardless of modifiers.
        /// </summary>
        public virtual Dictionary<string, string> GetCustomParameters()
        {
            return new Dictionary<string, string>() { };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatamuseRequest"/> class and applies the provided modifiers.
        /// </summary>
        /// <param name="modifiers">The modifiers to be applied.</param>
        public DatamuseRequest(IRequestModifier[] modifiers)
        {
            modifierParameters = new Dictionary<string, string>();
            for (int i = 0; i < modifiers.Length; i++)
            {
                ApplyModifier(modifiers[i]);
            }
        }

        /// <summary>
        /// Applies the provided modifier.
        /// </summary>
        /// <param name="modifier">The modifier to be applied.</param>
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

        /// <summary>
        /// Returns the parameters to be used in this request.
        /// </summary>
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