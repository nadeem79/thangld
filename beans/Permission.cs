using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Permission:IdentityObject
    {
        public virtual string Job
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

        public Permission()
        {
            
        }
        public Permission(JobEnum job, string privilage)
        {
            this.Job = job.ToString();
            this.Privilage = privilage;
        }
    }
}
