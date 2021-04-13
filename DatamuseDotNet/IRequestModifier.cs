using System;
using System.Collections.Generic;
using System.Text;

namespace DatamuseDotNet
{
    public interface IRequestModifier
    {
        Dictionary<string, string> GetParameters();
    }
}