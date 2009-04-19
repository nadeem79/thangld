using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;

namespace beans
{
    

    public class Build:IdentityObject
    {

        #region Static Members


        public static Dictionary<int, BuildPrice> PriceDictionary
        {
            get { return Build._dictionary; }
        }
        #endregion

        #region Variable
        #endregion

        #region Properties
        public virtual Village InVillage
        {
            get;
            set;
        }
        public virtual DateTime Start
        {
            get;
            set;
        }
        public virtual DateTime End
        {
            get;
            set;
        }
        #endregion

        #region Methods
        public void execute(ISession session)
        {
            BuildPrice price = Build.GetPrice(this.Building, this.InVillage.GetTotalBuildingLevel(this.Building, session) + 1, this.InVillage.Buildings.Headquarter);

            if (this.InVillage.CanBuild(this.Building, session) != BuildableStatus.JustDoIt)
                return;

            this.Start = DateTime.Now;
            this.End = DateTime.Now.AddSeconds(price.BuildTime);
            this.InVillage.Resources.Wood -= price.Wood;
            this.InVillage.Resources.Clay -= price.Clay;
            this.InVillage.Resources.Iron -= price.Iron;
            session.Update(this.InVillage);
            session.Save(this);
        }
        public bool expense(DateTime time)
        {
            if (this.End > time)
                return false;
            this.InVillage[this.Building]++;
            BuildPrice p = Build.GetPrice(this.Building, this.InVillage[this.Building], this.InVillage[beans.BuildingType.Headquarter]);
            this.InVillage.Points += p.Point;
            this.InVillage.Population += p.Population;
            this.InVillage.Owner.Point += p.Point;
            return true;
        }
        public void cancel(ISession session)
        {
            BuildPrice price = Build.GetPrice(this.Building, this.InVillage[this.Building], this.InVillage[BuildingType.Headquarter]);

            this.InVillage.Resources.Wood += price.Wood;
            this.InVillage.Resources.Clay += price.Clay;
            this.InVillage.Resources.Iron += price.Iron;

            session.Update(this.InVillage);
            session.Delete(this);
        }
        #endregion

        #region Static Methods
        public static BuildPrice GetPrice(BuildingType type, int level, int headquarter)
        {
            if (headquarter <= 1)
                return Build.GetPrice(type);

            //int key = (int)type + (headquarter * 100) + level;
            int key = ((int)type * 10000) + (headquarter * 100) + level;
            if (Build.PriceDictionary.ContainsKey(key))
                return Build.PriceDictionary[key];

            BuildPrice basePrice = Build.GetPrice(type);
            int wood = basePrice.Wood, clay = basePrice.Clay, iron = basePrice.Iron, time = basePrice.BuildTime;
            double population = basePrice.Population;
            for (int i = 1; i < level; i++)
            {
                clay += (int)(clay * 0.28);
                wood += (int)(wood * 0.25);
                iron += (int)(iron * 0.25);
                time += (int)(time * 0.22);
                population += population * 0.1;
            }
            for (int i = 1; i < headquarter; i++)
                time -= (int)(time * 0.05);
            BuildPrice price = new BuildPrice(basePrice.Name, time, wood, clay, iron, population, basePrice.MaxLevel);
            Build.PriceDictionary.Add(key, price);
            return price;
        }
        public static BuildPrice GetPrice(BuildingType type)
        {
            switch (type)
            {
                case BuildingType.Headquarter:
                    return Build.Headquarter;
                    break;
                case BuildingType.Barracks:
                    return Build.Barrack;
                    break;
                case BuildingType.Stable:
                    return Build.Stable;
                    break;
                case BuildingType.Workshop:
                    return Build.Workshop;
                    break;
                case BuildingType.Academy:
                    return Build.Academy;
                    break;
                case BuildingType.Smithy:
                    return Build.Smithy;
                    break;
                case BuildingType.Rally:
                    return Build.Rally;
                    break;
                case BuildingType.Market:
                    return Build.Market;
                    break;
                case BuildingType.TimberCamp:
                    return Build.TimberCamp;
                    break;
                case BuildingType.ClayPit:
                    return Build.ClayPit;
                    break;
                case BuildingType.IronMine:
                    return Build.IronMine;
                    break;
                case BuildingType.Farm:
                    return Build.Farm;
                    break;
                case BuildingType.Warehouse:
                    return Build.Warehouse;
                    break;
                case BuildingType.HidingPlace:
                    return Build.HidingPlace;
                    break;
                case BuildingType.Wall:
                    return Build.Wall;
                    break;
                default:
                    throw new Exception("Hack hả ku");
                    break;
            }
        }

        public static bool CanBuild(BuildingType building, int level, Village village)
        {
            switch (building)
            {
                case BuildingType.Headquarter:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Barracks:
                    if (village.Buildings.Headquarter < 3)
                        return false;
                    break;
                case BuildingType.Stable:
                    if (village.Buildings.Barracks < 5 || village.Buildings.Smithy < 5 || village.Buildings.Headquarter < 10)
                        return false;
                    break;
                case BuildingType.Workshop:
                    if (village.Buildings.Headquarter < 10 || village.Buildings.Smithy < 10)
                        return false;
                    break;
                case BuildingType.Academy:
                    if (village.Buildings.Headquarter < 20 || village.Buildings.Smithy < 20 || village.Buildings.Market < 10)
                        return false;
                    break;
                case BuildingType.Smithy:
                    if (village.Buildings.Headquarter < 5 || village.Buildings.Barracks < 1)
                        return false;
                    break;
                case BuildingType.Rally:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Market:
                    if (village.Buildings.Headquarter < 3 || village.Buildings.Warehouse < 2)
                        return false;
                    break;
                case BuildingType.TimberCamp:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.ClayPit:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.IronMine:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Farm:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Warehouse:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.HidingPlace:
                    if (village.Buildings.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Wall:
                    if (village.Buildings.Headquarter < 1 || village.Buildings.Barracks < 1)
                        return false;
                    break;
                default:
                    return false;
            }

            BuildPrice price = Build.GetPrice(building, level, village.Buildings.Headquarter);
            return (price.Wood < village.Resources.Wood && price.Clay < village.Resources.Clay && price.Iron < village.Resources.Iron);
        }
        #endregion

        #region Constructors
        #endregion

    }

    public class BuildPrice:Price
    {
        private int _point, _max;
        
        public int Point
        {
            get { return this._point; }
        }
        public int MaxLevel
        {
            get { return this._max; }
        }

        public BuildPrice(string name, int time, int wood, int clay, int iron, double population, int max):base(name, time, wood, clay, iron, population)
        {
            this._max = max;
        }

    }

    public enum BuildableStatus
    {
        NotEnoughFarm,
        NotEnoughIron,
        NotEnoughWood,
        NotEnoughClay,
        BuildNumberExceed,
        BuildingLevelExceed,
        RequirementNotMet,
        JustDoIt
    }

    public class BuildableStatusFactory
    {
        public static string ToString(BuildableStatus status)
        {
            switch (status)
            {
                case BuildableStatus.NotEnoughFarm:
                    return "Không đủ farm";
                case BuildableStatus.NotEnoughWood:
                    return "Không đủ gỗ";
                case BuildableStatus.NotEnoughClay:
                    return "Không đủ gạch";
                case BuildableStatus.NotEnoughIron:
                    return "Không đủ kim loại";
                case BuildableStatus.BuildNumberExceed:
                    return "Chỉ xây được 5 công trình";
                case BuildableStatus.BuildingLevelExceed:
                    return "Vượt quá level";
                case BuildableStatus.JustDoIt:
                    return "Có thể xây dựng";
                case BuildableStatus.RequirementNotMet:
                    return "Chưa đủ điều kiện xây dựng";
                default:
                    return "";
            }
        }
        
    }
}
