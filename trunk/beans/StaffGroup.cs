using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class StaffGroup:IdentityObject
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual IList<Permission> Permissions
        {
            get;
            set;
        }

    }
}
