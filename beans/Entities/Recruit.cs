using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Recruit : IdentityObject
    {

        #region Constant
        protected static Price pAxe = null, pSpear = null, pSword = null, pScout = null, pLight = null, pHeavy = null, pRam = null, pCatapult = null, pNoble = null;

        protected static Price Axe
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 60, 30, 10);
                return pAxe;
            }
        }
        protected static Price Spear
        {
            get
            {
                if (object.Equals(pSpear, null))
                    pSpear = new Price(900, 50, 30, 10);
                return pSpear;
            }
        }
        protected static Price Sword
        {
            get
            {
                if (object.Equals(pSword, null))
                    pSword = new Price(900, 30, 30, 70);
                return pSword;
            }
        }
        protected static Price Scout
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 50, 50, 20);
                return pAxe;
            }
        }
        protected static Price Light
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 125, 100, 250);
                return pAxe;
            }
        }
        protected static Price Heavy
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 200, 150, 600);
                return pAxe;
            }
        }
        protected static Price Ram
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 300, 200, 200);
                return pAxe;
            }
        }
        protected static Price Catapult
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 320, 400, 100);
                return pAxe;
            }
        }
        protected static Price Noble
        {
            get
            {
                if (object.Equals(pAxe, null))
                    pAxe = new Price(900, 28000, 30000, 25000);
                return pAxe;
            }
        }

        #endregion

        #region Variable
        private Village inVillage;
        private DateTime start;
        private DateTime end;
        private TroopType troop;
        
        #endregion

        #region Properties

        public virtual Village InVillage
        {
            get { return inVillage; }
            set { inVillage = value; }
        }

        public virtual TroopType Troop
        {
            get { return troop; }
            set { troop = value; }
        }

        public virtual DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public virtual DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        private int quantity;

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        public Recruit()
        {

        }
        #endregion

        public bool Expense(DateTime to)
        {
            TimeSpan t = to - this.start;
            
            int total_troop = (int)(t.TotalSeconds / 900);
            int totalRecruit = (total_troop < this.Quantity) ? total_troop : this.Quantity;

            switch (this.Troop)
            {
                case TroopType.Spear:
                    this.InVillage.Spear += total_troop;
                    break;
                case TroopType.Sword:
                    this.InVillage.Spear += total_troop;
                    break;
                case TroopType.Axe:
                    this.InVillage.Axe += total_troop;
                    break;
                case TroopType.Scout:
                    this.InVillage.Scout += total_troop;
                    break;
                case TroopType.Light:
                    this.InVillage.Light += total_troop;
                    break;
                case TroopType.Heavy:
                    this.InVillage.Heavy += total_troop;
                    break;
                case TroopType.Ram:
                    this.InVillage.Ram += total_troop;
                    break;
                case TroopType.Catapult:
                    this.InVillage.Catapult += total_troop;
                    break;
                case TroopType.Nobleman:
                    this.InVillage.Noble += total_troop;
                    break;
                default:
                    break;
            }

            if (totalRecruit == this.Quantity)
                return true;

            this.Start = this.Start.AddSeconds(totalRecruit * 900);
            this.Quantity -= totalRecruit;

            return false;
        }

        public static bool CanRecruit(TroopType troop, int quantity, int wood, int clay, int iron)
        {
            Price price = null;
            switch (troop)
            {
                case TroopType.Spear:
                    price = Recruit.Spear;
                    break;
                case TroopType.Sword:
                    price = Recruit.Sword;
                    break;
                case TroopType.Axe:
                    price = Recruit.Axe;
                    break;
                case TroopType.Scout:
                    price = Recruit.Scout;
                    break;
                case TroopType.Light:
                    price = Recruit.Light;
                    break;
                case TroopType.Heavy:
                    price = Recruit.Heavy;
                    break;
                case TroopType.Ram:
                    price = Recruit.Ram;
                    break;
                case TroopType.Catapult:
                    price = Recruit.Catapult;
                    break;
                case TroopType.Nobleman:
                    price = Recruit.Noble;
                    break;
                default:
                    
            }

            if (object.Equals(price, null))
                return false;
 
            if (quantity * price.Clay > clay)
                return false;
            if (quantity * price.Wood > wood)
                return false;
            if (quantity * price.Iron > iron)
                return false;
            return true;
        }


        public static long RecruitTime(int quantity, int level)
        {
            if (level==0)
                return long.MaxValue;
            if (quantity == 0)
                return 0;

            return 900 * quantity;
        }
    }
}
