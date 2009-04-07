using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace beans
{
    

    public class Build
    {
        private static BuildPrice _headquarter = new BuildPrice(948, 90, 80, 70, 5, 30);
        private static BuildPrice _barrack = new BuildPrice(1897, 200, 170, 90, 7, 25);
        private static BuildPrice _stable = new BuildPrice(6333, 270, 240, 260, 8, 20);
        private static BuildPrice _workshop = new BuildPrice(6328, 300, 240, 260, 8, 15);
        private static BuildPrice _academy = new BuildPrice(68112, 20000, 25000, 15000, 80, 3);
        private static BuildPrice _smithy = new BuildPrice(6300, 220, 180, 240, 20, 20);
        private static BuildPrice _rally = new BuildPrice(1658, 10, 40, 30, 0, 1);
        private static BuildPrice _market = new BuildPrice(2848, 100, 100, 100, 20, 25);
        private static BuildPrice _timber = new BuildPrice(949, 50, 60, 40, 5, 30);
        private static BuildPrice _clay = new BuildPrice(949, 65, 50, 40, 10, 30);
        private static BuildPrice _iron = new BuildPrice(1139, 75, 65, 70, 10, 30);
        private static BuildPrice _farm = new BuildPrice(1054, 45, 40, 30, 0, 30);
        private static BuildPrice _warehouse = new BuildPrice(1075, 60, 50, 40, 0, 30);
        private static BuildPrice _hiding = new BuildPrice(1561, 50, 60, 50, 2, 10);
        private static BuildPrice _wall = new BuildPrice(3801, 50, 100, 20, 5, 20);
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
                if (_clay == null)
                    _clay = new BuildPrice(900, 65, 50, 40, 10, 30);
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

        #region Variable
        private int id;
        private Village inVillage;
        private DateTime start, end;
        private BuildingType building;
        #endregion

        #region Properties
        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        public virtual Village InVillage
        {
            get { return inVillage; }
            set { inVillage = value; }
        }


        public virtual BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }

        public virtual DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public virtual DateTime End
        {
            get { return this.end; }
            set { this.end = value; }
        }
        #endregion

        #region Static Methods
        public static BuildPrice GetPrice(BuildingType type, int level, int headquarter)
        {
            if (headquarter <= 1)
                return Build.GetPrice(type);

            int key = (int)type | headquarter | level;
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
                time += (int)(time * 0.2);
                population += population * 0.1;
            }
            for (int i = 1; i < headquarter; i++)
                time -= (int)(time * 0.05);
            BuildPrice price = new BuildPrice(time, wood, clay, iron, population, basePrice.MaxLevel);
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
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Barracks:
                    if (village.Headquarter < 3)
                        return false;
                    break;
                case BuildingType.Stable:
                    if (village.Barracks < 5 || village.Smithy < 5 || village.Headquarter < 10)
                        return false;
                    break;
                case BuildingType.Workshop:
                    if (village.Headquarter < 10 || village.Smithy < 10)
                        return false;
                    break;
                case BuildingType.Academy:
                    if (village.Headquarter < 20 || village.Smithy < 20 || village.Market < 10)
                        return false;
                    break;
                case BuildingType.Smithy:
                    if (village.Headquarter < 5 || village.Barracks < 1)
                        return false;
                    break;
                case BuildingType.Rally:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Market:
                    if (village.Headquarter < 3 || village.Warehouse < 2)
                        return false;
                    break;
                case BuildingType.TimberCamp:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.ClayPit:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.IronMine:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Farm:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Warehouse:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.HidingPlace:
                    if (village.Headquarter < 1)
                        return false;
                    break;
                case BuildingType.Wall:
                    if (village.Headquarter < 1 || village.Barracks < 1)
                        return false;
                    break;
                default:
                    return false;
            }

            BuildPrice price = Build.GetPrice(building, level, village.Headquarter);
            return (price.Wood < village.Wood && price.Clay < village.Clay && price.Iron < village.Iron);
        }
        #endregion

        #region Constructors
        public Build()
        {

        }

        public Build(int ID)
            : this()
        {

        }
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

        public BuildPrice(int time, int wood, int clay, int iron, double population, int max):base(time, wood, clay, iron, population)
        {
            this._max = max;
        }

    }

}
