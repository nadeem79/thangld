using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageBuildingData:IdentityObject
    {

        private static Dictionary<int, int> merchantCount = new Dictionary<int, int>();
        private static Dictionary<int, int> basicDefense = new Dictionary<int, int>();
        private static Dictionary<int, double> fortifiedWall = new Dictionary<int, double>();
        private int merchant;

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

        public virtual int MerchantOfVillage
        {
            get
            {
                if (this.Market == 0)
                    return 0;
                if (this.Market == 1)
                    return 1;

                if (VillageBuildingData.merchantCount.ContainsKey(this.Market))
                    return VillageBuildingData.merchantCount[this.Market];

                int merchant = 1;
                for (int i = 1; i <= this.Market; i++)
                    merchant += (int)Math.Ceiling(merchant * 0.25);



                VillageBuildingData.merchantCount.Add(this.Market, merchant);
                return merchant;
            }
        }
        public virtual int Merchant
        {
            get { return merchant; }
            set
            {
                if (value > MerchantOfVillage)
                    merchant = MerchantOfVillage;
                else
                    merchant = value;
            }
        }

        public virtual int BasicDefense
        {
            get
            {
                if (this.Wall == 0)
                    return 0;
                if (this.Wall == 1)
                    return 100;

                if (VillageBuildingData.basicDefense.ContainsKey(this.Wall))
                    return VillageBuildingData.basicDefense[this.Wall];

                int defense = 100;
                for (int i = 1; i <= this.Wall; i++)
                    defense += (int)(defense * 0.2);

                VillageBuildingData.basicDefense.Add(this.Wall, defense);
                return defense;
            }
        }

        public virtual double Fortified
        {
            get
            {
                if (this.Wall == 0)
                    return 0;
                if (this.Wall == 1)
                    return 0.05;

                if (VillageBuildingData.fortifiedWall.ContainsKey(this.Wall))
                    return VillageBuildingData.fortifiedWall[this.Wall];

                double fortified = 0.05;

                for (int i = 1; i <= this.Wall; i++)
                    fortified += fortified * 0.2;

                VillageBuildingData.fortifiedWall.Add(this.Wall, fortified);

                return fortified;
            }
        }

        #endregion

        public virtual Village Village
        {
            get;
            set;
        }
    }
}
