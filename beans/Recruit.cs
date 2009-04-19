using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{

    public class Price
    {
        string _name;
        int wood, iron, clay;
        int time;
        double _pop;

        public int Wood
        {
            get { return this.wood; }
        }
        public int Iron
        {
            get { return this.iron; }
        }
        public int Clay
        {
            get { return this.clay; }
        }
        public int BuildTime
        {
            get { return this.time; }
        }
        public double Population
        {
            get { return this._pop; }
        }
        public string Name
        {
            get { return this._name; }
        }
        public Price(string name, int time, int wood, int clay, int iron, double population)
        {
            this._name = name;
            this.iron = iron;
            this.clay = clay;
            this.wood = wood;
            this.time = time;
            this._pop = population;
        }
        public override string ToString()
        {
            return this._name;
        }

    }

    public class Recruit : IdentityObject
    {

        #region Constant


        public static Price Spear
        {
            get
            {
                return pSpear;
            }
        }
        public static Price Sword
        {
            get
            {
                return pSword;
            }
        }
        public static Price Axe
        {
            get
            {
                return pAxe;
            }
        }
        public static Price Scout
        {
            get
            {
                return pScout;
            }
        }
        public static Price Light
        {
            get
            {
                return pLight;
            }
        }
        public static Price Heavy
        {
            get
            {
                return pHeavy;
            }
        }
        public static Price Ram
        {
            get
            {
                return pRam;
            }
        }
        public static Price Catapult
        {
            get
            {
                return pCatapult;
            }
        }
        public static Price Noble
        {
            get
            {
                return pNoble;
            }
        }
        public static Dictionary<int, Price> PriceDictionary
        {
            get { return Recruit._dictionary; }
        }

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
        public static Price GetPrice(TroopType troop, int level)
        {
            if (level <= 1)
                return Recruit.GetPrice(troop);

            int key = (int)troop | level;
            if (Recruit.PriceDictionary.ContainsKey(key))
                return Recruit.PriceDictionary[key];

            Price basePrice = Recruit.GetPrice(troop);
            int time = basePrice.BuildTime;

            for (int i = 1; i < level; i++)
                time -= (int)(time * 0.05);
            Price price = new Price(basePrice.Name, time, basePrice.Wood, basePrice.Clay, basePrice.Iron, basePrice.Population);
            Recruit.PriceDictionary.Add(key, price);
            return price;
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
            Price p = Recruit.GetPrice(this.Troop);


            int total_troop = (int)(t.TotalSeconds / p.BuildTime);
            int totalRecruit = (total_troop < this.Quantity) ? total_troop : this.Quantity;

            switch (this.Troop)
            {
                case TroopType.Spear:
                    this.InVillage.Troop.Spear += total_troop;
                    this.InVillage.Troop.InVillageSpear += total_troop;
                    this.InVillage.Troop.TotalSpear += total_troop;
                    break;
                case TroopType.Sword:
                    this.InVillage.Troop.Sword += total_troop;
                    this.InVillage.Troop.InVillageSword += total_troop;
                    this.InVillage.Troop.TotalSword += total_troop;
                    break;
                case TroopType.Axe:
                    this.InVillage.Troop.Axe += total_troop;
                    this.InVillage.Troop.InVillageAxe += total_troop; 
                    this.InVillage.Troop.TotalAxe += total_troop;
                    break;
                case TroopType.Scout:
                    this.InVillage.Troop.Scout += total_troop;
                    this.InVillage.Troop.InVillageScout += total_troop;
                    this.InVillage.Troop.TotalScout += total_troop;
                    break;
                case TroopType.Light:
                    this.InVillage.Troop.Light += total_troop;
                    this.InVillage.Troop.InVillageLight += total_troop;
                    this.InVillage.Troop.TotalLight += total_troop;
                    break;
                case TroopType.Heavy:
                    this.InVillage.Troop.Heavy += total_troop;
                    this.InVillage.Troop.InVillageHeavy += total_troop;
                    this.InVillage.Troop.TotalHeavy += total_troop;
                    break;
                case TroopType.Ram:
                    this.InVillage.Troop.Ram += total_troop;
                    this.InVillage.Troop.InVillageRam += total_troop;
                    this.InVillage.Troop.TotalRam += total_troop;
                    break;
                case TroopType.Catapult:
                    this.InVillage.Troop.Catapult += total_troop;
                    this.InVillage.Troop.InVillageCatapult += total_troop;
                    this.InVillage.Troop.TotalCatapult += total_troop;
                    break;
                case TroopType.Nobleman:
                    this.InVillage.Troop.Noble += total_troop;
                    this.InVillage.Troop.InVillageNoble += total_troop;
                    this.InVillage.Troop.TotalNoble += total_troop;
                    break;
                default:
                    break;
            }

            this.InVillage.Population += (totalRecruit * p.Population);

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
        public void cancel(ISession session)
        {
            Price p = Recruit.GetPrice(this.Troop);
            this.InVillage.Resources.Wood += (int)(this.Quantity * p.Wood * 0.9);
            this.InVillage.Resources.Clay += (int)(this.Quantity * p.Clay * 0.9);
            this.InVillage.Resources.Iron += (int)(this.Quantity * p.Iron * 0.9);
            session.Delete(this);
            session.Update(this.InVillage);
        }
        public static bool CanRecruit(TroopType troop, int quantity, Village village)
        {
            switch (troop)
            {
                case TroopType.Spear:
                    if (village.Buildings.Barracks == 0 || village.Research.ResearchSpear == 0)
                        return false;
                    break;
                case TroopType.Sword:
                    if (village.Buildings.Barracks == 0 || village.Research.ResearchSword == 0 || village.Buildings.Smithy < 1)
                        return false;
                    break;
                case TroopType.Axe:
                    if (village.Buildings.Barracks == 0 || village.Research.ResearchAxe == 0 || village.Buildings.Smithy < 2)
                        return false;
                    break;
                case TroopType.Scout:
                    if (village.Buildings.Stable == 0 || village.Research.ResearchScout == 0)
                        return false;
                    break;
                case TroopType.Light:
                    if (village.Buildings.Stable < 3 || village.Research.ResearchLight == 0 || village.Buildings.Stable < 3)
                        return false;
                    break;
                case TroopType.Heavy:
                    if (village.Buildings.Stable < 10 || village.Buildings.Smithy < 15 || village.Research.ResearchHeavy == 0)
                        return false;
                    break;
                case TroopType.Ram:
                    if (village.Buildings.Workshop == 0 || village.Research.ResearchRam == 0)
                        return false;
                    break;
                case TroopType.Catapult:
                    if (village.Buildings.Workshop < 2 || village.Buildings.Smithy < 12 || village.Research.ResearchCatapult == 0)
                        return false;
                    break;
                case TroopType.Nobleman:
                    if (village.Buildings.Academy == 0 || village.Buildings.Smithy < 20)
                        return false;
                    break;
                default:
                    return false;
                    break;
            }

            return Recruit.CanRecruit(troop, quantity, village.Resources.Wood, village.Resources.Clay, village.Resources.Iron);

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
