using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    

    public class Build:IdentityObject
    {

        #region Static Members
        private static BuildPrice _headquarter = new BuildPrice("Headquarter", 948, 90, 80, 70, 5, 30, 10);
        private static BuildPrice _barrack = new BuildPrice("Barrack", 1897, 200, 170, 90, 7, 25, 16);
        private static BuildPrice _stable = new BuildPrice("Stable", 6333, 270, 240, 260, 8, 20, 20);
        private static BuildPrice _workshop = new BuildPrice("Workshop", 6328, 300, 240, 260, 8, 15, 24);
        private static BuildPrice _academy = new BuildPrice("Academy", 68112, 25000, 30000, 20000, 80, 3, 512);
        private static BuildPrice _smithy = new BuildPrice("Smithy", 6300, 220, 180, 240, 20, 20, 19);
        private static BuildPrice _rally = new BuildPrice("Rally", 1658, 10, 40, 30, 0, 1, 0);
        private static BuildPrice _market = new BuildPrice("Market", 2848, 100, 100, 100, 20, 25, 10);
        private static BuildPrice _timber = new BuildPrice("Timber camp", 949, 50, 60, 40, 10, 30, 6);
        private static BuildPrice _clay = new BuildPrice("Clay pit", 949, 65, 50, 40, 10, 30, 6);
        private static BuildPrice _iron = new BuildPrice("Iron mine", 1139, 75, 65, 70, 10, 30, 6);
        private static BuildPrice _farm = new BuildPrice("Farm", 1054, 45, 40, 30, 0, 30, 5);
        private static BuildPrice _warehouse = new BuildPrice("Warehouse", 1075, 60, 50, 40, 0, 30, 6);
        private static BuildPrice _hiding = new BuildPrice("Hiding place", 1561, 50, 60, 50, 2, 10, 5);
        private static BuildPrice _wall = new BuildPrice("Wall", 3801, 50, 100, 20, 5, 20, 8);
        private static Dictionary<int, BuildPrice> _dictionary = new Dictionary<int, BuildPrice>();

        public static Dictionary<int, BuildPrice> PriceDictionary
        {
            get { return Build._dictionary; }
        }
        public static BuildPrice Headquarter
        {
            get
            {
                return _headquarter;
            }
        }
        public static BuildPrice Barrack
        {
            get
            {
                return _barrack;
            }
        }
        public static BuildPrice Stable
        {
            get
            {
                return _stable;
            }
        }
        public static BuildPrice Workshop
        {
            get
            {
                return _workshop;
            }
        }
        public static BuildPrice Academy
        {
            get
            {
                return _academy;
            }
        }
        public static BuildPrice Smithy
        {
            get
            {
                return _smithy;
            }
        }
        public static BuildPrice Rally
        {
            get
            {
                return _rally;
            }
        }
        public static BuildPrice Market
        {
            get
            {
                return _market;
            }
        }
        public static BuildPrice TimberCamp
        {
            get
            {
                return _timber;
            }
        }
        public static BuildPrice ClayPit
        {
            get
            {
                return _clay;
            }
        }
        public static BuildPrice IronMine
        {
            get
            {
                return _iron;
            }
        }
        public static BuildPrice Farm
        {
            get
            {
                return _farm;
            }
        }
        public static BuildPrice Warehouse
        {
            get { return _warehouse; }
        }
        public static BuildPrice HidingPlace
        {
            get
            {
                return _hiding;
            }
        }
        public static BuildPrice Wall
        {
            get
            {
                return _wall;
            }
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
        public virtual BuildingType Building
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
        public int Level
        {
            get;
            set;
        }
        public virtual int Wood
        {
            get; set;
        }
        public int Clay
        {
            get; set;
        }
        public int Iron
        {
            get; set;
        }
        public float Point
        {
            get; set;
        }
        public float Population
        {
            get; set;
        }
        #endregion

        #region Methods
        public bool Expense(DateTime time)
        {
            if (this.End > time)
                return false;
            this.InVillage[this.Building]++;
            BuildPrice p = Build.GetPrice(this.Building, this.InVillage[this.Building], this.InVillage[beans.BuildingType.Headquarter]);
            this.InVillage.Player.Point += p.Point;
            return true;
        }

        public void Cancel(ISession session)
        {
            BuildPrice price = Build.GetPrice(this.Building, this.Level, this.InVillage[BuildingType.Headquarter]);
            
            this.InVillage.VillageResourceData.Wood += (int)(price.Wood * 0.8);
            this.InVillage.VillageResourceData.Clay += (int)(price.Clay * 0.8);
            this.InVillage.VillageResourceData.Iron += (int)(price.Iron * 0.8);
            this.InVillage.Population -= price.Population;

            IList<Build> builds = (from build in session.Linq<Build>()
                                   where build.InVillage == this.InVillage
                                   && build.ID > this.ID
                                   orderby build.ID ascending
                                   select build).ToList<Build>();

            for (int i = 0; i < builds.Count; i++)
            {
                Build b = builds[i];
                if (i == 0)
                    b.Start = DateTime.Now;
                else
                    b.Start = builds[i - 1].End;

                if (b.Building == this.Building)
                    b.Level--;

                BuildPrice p = Build.GetPrice(b.Building, b.Level, this.InVillage[BuildingType.Headquarter]);
                b.End = b.Start.AddSeconds(p.BuildTime);
            }

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.Update(this.InVillage);
                session.Delete(this);
                foreach (Build b in builds)
                    session.Update(b);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }
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
            double point = basePrice.Point;
            double population = basePrice.Population;
            for (int i = 1; i < level; i++)
            {
                clay += (int)(clay * 0.28);
                wood += (int)(wood * 0.25);
                iron += (int)(iron * 0.25);
                time += (int)(time * 0.22);
                population += (float)(population * 0.1);
                point += (int)Math.Ceiling(point*0.2);
                
            }
            for (int i = 1; i < headquarter; i++)
                time -= (int)(time * 0.05);
            BuildPrice price = new BuildPrice(basePrice.Name, time, wood, clay, iron, population, basePrice.MaxLevel, point);
            Build.PriceDictionary.Add(key, price);
            return price;
        }
        public static BuildPrice GetPrice(BuildingType type)
        {
            switch (type)
            {
                case BuildingType.Headquarter:
                    return Build.Headquarter;
                case BuildingType.Barracks:
                    return Build.Barrack;
                case BuildingType.Stable:
                    return Build.Stable;
                case BuildingType.Workshop:
                    return Build.Workshop;
                case BuildingType.Academy:
                    return Build.Academy;
                case BuildingType.Smithy:
                    return Build.Smithy;
                case BuildingType.Rally:
                    return Build.Rally;
                case BuildingType.Market:
                    return Build.Market;
                case BuildingType.TimberCamp:
                    return Build.TimberCamp;
                case BuildingType.ClayPit:
                    return Build.ClayPit;
                case BuildingType.IronMine:
                    return Build.IronMine;
                case BuildingType.Farm:
                    return Build.Farm;
                case BuildingType.Warehouse:
                    return Build.Warehouse;
                case BuildingType.HidingPlace:
                    return Build.HidingPlace;
                case BuildingType.Wall:
                    return Build.Wall;
                default:
                    throw new Exception("Hack hả ku");
            }
        }

        public static bool CanBuild(BuildingType building, int level, Village village)
        {
            switch (building)
            {
                case BuildingType.Headquarter:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Barracks:
                    if (village.VillageBuildingData.Headquarter < 3)
                        return false;
                    break;
                case BuildingType.Stable:
                    if (village.VillageBuildingData.Barracks < 5 || village.VillageBuildingData.Smithy < 5 || village.VillageBuildingData.Headquarter < 10)
                        return false;
                    break;
                case BuildingType.Workshop:
                    if (village.VillageBuildingData.Headquarter < 10 || village.VillageBuildingData.Smithy < 10)
                        return false;
                    break;
                case BuildingType.Academy:
                    if (village.VillageBuildingData.Headquarter < 20 || village.VillageBuildingData.Smithy < 20 || village.VillageBuildingData.Market < 10)
                        return false;
                    break;
                case BuildingType.Smithy:
                    if (village.VillageBuildingData.Headquarter < 5 || village.VillageBuildingData.Barracks < 1)
                        return false;
                    break;
                case BuildingType.Rally:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Market:
                    if (village.VillageBuildingData.Headquarter < 3 || village.VillageBuildingData.Warehouse < 2)
                        return false;
                    break;
                case BuildingType.TimberCamp:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.ClayPit:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.IronMine:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Farm:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Warehouse:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.HidingPlace:
                    if (village.VillageBuildingData.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Wall:
                    if (village.VillageBuildingData.Headquarter < 1 || village.VillageBuildingData.Barracks < 1)
                        return false;
                    break;
                default:
                    return false;
            }

            BuildPrice price = Build.GetPrice(building, level, village.VillageBuildingData.Headquarter);
            return (price.Wood < village.VillageResourceData.Wood && price.Clay < village.VillageResourceData.Clay && price.Iron < village.VillageResourceData.Iron);
        }
        #endregion

    }

    public class BuildPrice:Price
    {
        private double _point;
        private int _max;

        public double Point
        {
            get { return this._point; }
        }
        public int MaxLevel
        {
            get { return this._max; }
        }

        public BuildPrice(string name, int time, int wood, int clay, int iron, double population, int max, double point)
            : base(name, time, wood, clay, iron, population)
        {
            this._max = max;
            this._point = point;
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
