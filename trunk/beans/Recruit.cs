﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Recruit : IdentityObject
    {

        #region Constant
        protected static Price pAxe = null, pSpear = null, pSword = null, pScout = null, pLight = null, pHeavy = null, pRam = null, pCatapult = null, pNoble = null;

        public static Price GetPrice(TroopType troop)
        {
            switch (troop)
            {
                case TroopType.Spear:
                    return Recruit.Spear;
                    break;
                case TroopType.Sword:
                    return Recruit.Sword;
                    break;
                case TroopType.Axe:
                    return Recruit.Axe;
                    break;
                case TroopType.Scout:
                    return Recruit.Scout;
                    break;
                case TroopType.Light:
                    return Recruit.Light;
                    break;
                case TroopType.Heavy:
                    return Recruit.Heavy;
                    break;
                case TroopType.Ram:
                    return Recruit.Ram;
                    break;
                case TroopType.Catapult:
                    return Recruit.Catapult;
                    break;
                case TroopType.Nobleman:
                    return Recruit.Noble;
                    break;
                default:
                    throw new Exception("Báo động: HACK!!!");
                    break;
            }
        }
        public static Price Spear
        {
            get
            {
                if (pSpear == null)
                    pSpear = new Price(900, 50, 30, 10);
                return pSpear;
            }
        }
        public static Price Sword
        {
            get
            {
                if (pSword == null)
                    pSword = new Price(900, 30, 30, 70);
                return pSword;
            }
        }
        public static Price Axe
        {
            get
            {
                if (pAxe == null)
                    pAxe = new Price(900, 60, 30, 10);
                return pAxe;
            }
        }
        public static Price Scout
        {
            get
            {
                if (pScout == null)
                    pScout = new Price(900, 50, 50, 20);
                return pScout;
            }
        }
        public static Price Light
        {
            get
            {
                if (pLight == null)
                    pLight = new Price(200, 125, 100, 250);
                return pLight;
            }
        }
        public static Price Heavy
        {
            get
            {
                if (pHeavy == null)
                    pHeavy = new Price(900, 200, 150, 600);
                return pHeavy;
            }
        }
        public static Price Ram
        {
            get
            {
                if (pRam == null)
                    pRam = new Price(900, 300, 200, 200);
                return pRam;
            }
        }
        public static Price Catapult
        {
            get
            {
                if (pCatapult == null)
                    pCatapult = new Price(900, 320, 400, 100);
                return pCatapult;
            }
        }
        public static Price Noble
        {
            get
            {
                if (pNoble == null)
                    pNoble = new Price(900, 28000, 30000, 25000);
                return pNoble;
            }
        }

        #endregion

        #region Properties

        public virtual Village InVillage
        {
            get;
            set;
        }
        public virtual TroopType Troop
        {
            get;
            set;
        }
        public virtual DateTime LastUpdate
        {
            get;
            set;
        }
        public virtual int Quantity
        {
            get;
            set;
        }
        #endregion

        #region Constructors

        #endregion

        public bool Expense(DateTime to)
        {
            TimeSpan t = to - this.LastUpdate;
            
            int total_troop = (int)(t.TotalSeconds / Recruit.GetPrice(this.Troop).BuildTime);
            int totalRecruit = (total_troop < this.Quantity) ? total_troop : this.Quantity;

            switch (this.Troop)
            {
                case TroopType.Spear:
                    this.InVillage.Spear += total_troop;
                    this.InVillage.InVillageSpear += total_troop;
                    break;
                case TroopType.Sword:
                    this.InVillage.Sword += total_troop;
                    this.InVillage.InVillageSword += total_troop;
                    break;
                case TroopType.Axe:
                    this.InVillage.Axe += total_troop;
                    this.InVillage.InVillageAxe += total_troop;
                    break;
                case TroopType.Scout:
                    this.InVillage.Scout += total_troop;
                    this.InVillage.InVillageScout += total_troop;
                    break;
                case TroopType.Light:
                    this.InVillage.Light += total_troop;
                    this.InVillage.InVillageLight += total_troop;
                    break;
                case TroopType.Heavy:
                    this.InVillage.Heavy += total_troop;
                    this.InVillage.InVillageHeavy += total_troop;
                    break;
                case TroopType.Ram:
                    this.InVillage.Ram += total_troop;
                    this.InVillage.InVillageRam += total_troop;
                    break;
                case TroopType.Catapult:
                    this.InVillage.Catapult += total_troop;
                    this.InVillage.InVillageCatapult += total_troop;
                    break;
                case TroopType.Nobleman:
                    this.InVillage.Noble += total_troop;
                    this.InVillage.InVillageNoble += total_troop;
                    break;
                default:
                    break;
            }

            if (totalRecruit == this.Quantity)
            {
                this.LastUpdate = this.LastUpdate.AddSeconds(totalRecruit * Recruit.GetPrice(this.Troop).BuildTime);
                this.Quantity = 0;
                return true;
            }

            this.LastUpdate = this.LastUpdate.AddSeconds(totalRecruit * Recruit.GetPrice(this.Troop).BuildTime);
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
                    break;
                    
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

        public static int MaxRecruit(TroopType troop, int wood, int clay, int iron)
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
                    break;

            }

            int maxRecruit = clay / price.Clay;
            if (maxRecruit > iron / price.Iron)
                maxRecruit = iron / price.Iron;
            if (maxRecruit > wood / price.Wood)
                maxRecruit = wood / price.Wood;

            return maxRecruit;
        }

        public static long RecruitTime(TroopType troop, int quantity, int level)
        {
            if (level==0)
                return int.MaxValue;
            if (quantity == 0)
                return 0;

            return Recruit.GetPrice(troop).BuildTime * quantity;
        }
    }
}
