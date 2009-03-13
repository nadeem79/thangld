using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public abstract class IdentityObject
    {

        private int id;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public static bool operator ==(IdentityObject lhs, IdentityObject rhs)
        {
            if (object.Equals(lhs, rhs))
                return true;
            return (lhs.ID == rhs.ID);
        }

        public static bool operator !=(IdentityObject lhs, IdentityObject rhs)
        {
            if (!object.Equals(lhs, rhs))
                return true;
            return (lhs.ID != rhs.ID);
        }

        public override int GetHashCode()
        {
            return this.ID;
        } 

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            IdentityObject v = (IdentityObject)obj;
            return this.ID == v.ID;
        }

    }
}
