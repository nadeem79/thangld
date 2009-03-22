using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Configuration:IdentityObject
    {
        public int Index
        {
            get;
            set;
        }

        public int Expand
        {
            get;
            set;
        }
    }
}
