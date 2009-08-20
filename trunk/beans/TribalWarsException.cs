using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class TribalWarsException:Exception
    {
        public TribalWarsException(string message) : base(message) { }
    }
}
