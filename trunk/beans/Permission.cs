using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Permission:IdentityObject
    {
        public virtual Job Job
        {
            get;
            set;
        }

        public virtual string Privilage
        {
            get;
            set;
        }

        public virtual StaffGroup StaffGroup
        {
            get;
            set;
        }
    }
}
