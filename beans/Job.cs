using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Job
    {

        public Job() { }
        public Job(string job)
        {
            this.JobName = job;
        }


        public virtual string JobName
        {
            get;
            set;
        }

        public static bool operator ==(Job lhs, Job rhs)
        {
            if (object.Equals(null, lhs) && !object.Equals(null, rhs))
                return false;
            if (object.Equals(null, rhs) && !object.Equals(null, lhs))
                return false;
            if (object.Equals(lhs, rhs))
                return true;
            return (lhs.JobName == rhs.JobName);
        }

        public static bool operator !=(Job lhs, Job rhs)
        {
            if (!object.Equals(lhs, rhs))
                return true;
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return this.JobName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            Job v = (Job)obj;
            return this.JobName == v.JobName;
        }
    }
}
