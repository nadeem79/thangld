using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageTroopData:IdentityObject
    {

        #region Quân đội có thể điều động
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
        public virtual int LightCavalry
        {
            get;
            set;
        }
        public virtual int HeavyCavalry
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
        public virtual int Noble
        {
            get;
            set;
        }
        #endregion

        #region Quân đội của thành phố, có thể ở trong hoặc ngoài
        public virtual int SpearOfVillage
        {
            get;
            set;
        }
        public virtual int SwordOfVillage
        {
            get;
            set;
        }
        public virtual int AxeOfVillage
        {
            get;
            set;
        }
        public virtual int ScoutOfVillage
        {
            get;
            set;
        }
        public virtual int LightCavalryOfVillage
        {
            get;
            set;
        }
        public virtual int HeavyCavalryOfVillage
        {
            get;
            set;
        }
        public virtual int RamOfVillage
        {
            get;
            set;
        }
        public virtual int CatapultOfVillage
        {
            get;
            set;
        }
        public virtual int NobleOfVillage
        {
            get;
            set;
        }
        #endregion

        #region Quân đội đang đóng trong thành phố
        public virtual int SpearInVillage
        {
            get;
            set;
        }
        public virtual int SwordInVillage
        {
            get;
            set;
        }
        public virtual int AxeInVillage
        {
            get;
            set;
        }
        public virtual int LightCavalryInVillage
        {
            get;
            set;
        }
        public virtual int ScoutInVillage
        {
            get;
            set;
        }
        public virtual int HeavyCavalryInVillage
        {
            get;
            set;
        }
        public virtual int RamInVillage
        {
            get;
            set;
        }
        public virtual int CatapultInVillage
        {
            get;
            set;
        }
        public virtual int NobleInVillage
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
