using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageReseachData:IdentityObject
    {
        #region Properties.Research

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
        

        #endregion

        public virtual Village Village
        {
            get;
            set;
        }
    }
}
