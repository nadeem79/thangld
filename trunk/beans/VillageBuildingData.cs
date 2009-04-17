using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageBuildingData:IdentityObject
    {
        #region Properties.Building

        

        public virtual int Headquarter
        {
            get;
            set;
        }
        public virtual int Barracks
        {
            get;
            set;
        }
        public virtual int Stable
        {
            get;
            set;
        }
        public virtual int Wall
        {
            get;
            set;
        }
        public virtual int HidingPlace
        {
            get;
            set;
        }
        public virtual int Warehouse
        {
            get;
            set;
        }
        public virtual int Farm
        {
            get;
            set;
        }
        public virtual int IronMine
        {
            get;
            set;
        }
        public virtual int ClayPit
        {
            get;
            set;
        }
        public virtual int TimberCamp
        {
            get;
            set;
        }
        public virtual int Market
        {
            get;
            set;
        }
        public virtual int Rally
        {
            get;
            set;
        }
        public virtual int Smithy
        {
            get;
            set;
        }
        public virtual int Academy
        {
            get;
            set;
        }
        public virtual int Workshop
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
