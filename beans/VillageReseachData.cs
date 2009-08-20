using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageResearchData : IdentityObject
    {

        public virtual int Attack
        {
            get;
            set;
        }
        public virtual int Defense
        {
            get;
            set;
        }
        public virtual int TroopSpeed
        {
            get;
            set;
        }
        public virtual int VillageSpeed
        {
            get;
            set;
        }

        public virtual Village Village
        {
            get;
            set;
        }
    }
}
