using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageTroopData:IdentityObject
    {
        #region Properties.Troop

        public virtual int Noble
        {
            get;
            set;
        }
        public virtual int Spear
        {
            get;
            set;
        }
        public virtual int Sword
        {
            get;
            set;
        }
        public virtual int Axe
        {
            get;
            set;
        }
        public virtual int Scout
        {
            get;
            set;
        }
        public virtual int Light
        {
            get;
            set;
        }
        public virtual int Heavy
        {
            get;
            set;
        }
        public virtual int Ram
        {
            get;
            set;
        }
        public virtual int Catapult
        {
            get;
            set;
        }

        public virtual int InVillageSpear
        {
            get;
            set;
        }
        public virtual int InVillageSword
        {
            get;
            set;
        }
        public virtual int InVillageAxe
        {
            get;
            set;
        }
        public virtual int InVillageScout
        {
            get;
            set;
        }
        public virtual int InVillageLight
        {
            get;
            set;
        }
        public virtual int InVillageHeavy
        {
            get;
            set;
        }
        public virtual int InVillageRam
        {
            get;
            set;
        }
        public virtual int InVillageCatapult
        {
            get;
            set;
        }
        public virtual int InVillageNoble
        {
            get;
            set;
        }

        public virtual int TotalSpear
        {
            get;
            set;
        }
        public virtual int TotalSword
        {
            get;
            set;
        }
        public virtual int TotalAxe
        {
            get;
            set;
        }
        public virtual int TotalLight
        {
            get;
            set;
        }
        public virtual int TotalScout
        {
            get;
            set;
        }
        public virtual int TotalHeavy
        {
            get;
            set;
        }
        public virtual int TotalRam
        {
            get;
            set;
        }
        public virtual int TotalCatapult
        {
            get;
            set;
        }
        public virtual int TotalNoble
        {
            get;
            set;
        }

        #endregion

        public virtual IList<Stationed> StationedTroops
        {
            get;
            set;
        }
        public virtual IList<Stationed> TroopsOutside
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
