using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageReseachData:IdentityObject
    {
        #region Properties.Research

        public virtual int ResearchSpear
        {
            get;
            set;
        }
        public virtual int ResearchSword
        {
            get;
            set;
        }
        public virtual int ResearchAxe
        {
            get;
            set;
        }
        public virtual int ResearchScout
        {
            get;
            set;
        }
        public virtual int ResearchLight
        {
            get;
            set;
        }
        public virtual int ResearchHeavy
        {
            get;
            set;
        }
        public virtual int ResearchRam
        {
            get;
            set;
        }
        public virtual int ResearchCatapult
        {
            get;
            set;
        }
        public virtual int ResearchNoble
        {
            get;
            set;
        }

        #endregion

        public virtual Village Village
        {
            get;
            set;
        }
    }
}
