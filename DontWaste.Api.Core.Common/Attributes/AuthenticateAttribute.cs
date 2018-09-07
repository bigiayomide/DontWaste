using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Core.Common.Attributes
{
    public class AuthenticateAttribute: Attribute
    {
        public AuthenticateAttribute(string Policy)
        {
        }
    }
}
