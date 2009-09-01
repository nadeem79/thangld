using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class SecurityException:TribalWarsException
    {
        public SecurityException(string message)
            : base(message)
        { }

        public SecurityException() : this(Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Security.no_privilage", true).Value) { }
    }
}
