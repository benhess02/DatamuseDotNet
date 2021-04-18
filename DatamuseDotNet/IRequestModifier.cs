using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    /// <summary>
    /// Can be used to create or modify the parameters of a <see cref="DatamuseRequest"/>.
    /// </summary>
    public interface IRequestModifier
    {
        /// <summary>
        /// Returns the parameters that are created or modified by this modifier.
        /// </summary>
        Dictionary<string, string> GetParameters();
    }
}