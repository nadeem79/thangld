using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Text;
using NHibernate.Criterion;
using System.Linq;

namespace beans
{
    
    public partial class Village:IdentityObject
    {
        #region Variables

        private int _maxResources = -1;
        private double loyal;
        
        private Player _owner;
        public Player Player
        {
            get { return this._owner; }
            set { this._owner = value; }
        }
        #endregion

        #region Properties

        #region Properties.Common

        public virtual int X
        {
            get;
            set;
        }
        public virtual int Y
        {
            get;
            set;
        }
        public virtual string Name
        {
            get;
            set;
        }
        public double Loyal
        {
            get { return loyal; }
            set
            {
                if (value > 100)
                    loyal = 100;
                else
                    _loyal = value;
            }
        }
        public virtual DateTime LastUpdate
        {
            get;
            set;
        }
        public virtual double Points
        {
            get;
            set;
        }
        public double Population
        {
            get;
            set;
        }
        public int MaxResources
        {
            get
            {
                if (this._maxResources > -1)
                    return this._maxResources;
                if (this[BuildingType.Warehouse] == 1)
                    this._maxResources = 1000;
                else if (this[BuildingType.Warehouse] == 0)
                    return 0;

                this._maxResources = 1000;

                for (int i = 1; i < this[BuildingType.Warehouse]; i++)
                    this._maxResources += (int)(this._maxResources * 0.3);

                return this._maxResources;
            }
        }
        public int MaxPopulation
        {
            get
            {
                if (this[BuildingType.Warehouse] == 1)
                    return 240;
                else if (this[BuildingType.Warehouse] == 0)
                    return 0;

                int result = 240;

                for (int i = 1; i < this[BuildingType.Warehouse]; i++)
                    result += (int)(result * 0.2);

                return result;
            }
        }

        public VillageBuildingData VillageBuildingData
        {
            get;
            set;
        }
        public VillageResourcesData VillageResourceData
        {
            get;
            set;
        }
        public VillageReseachData VillageResearchData
        {
            get;
            set;
        }
        public VillageTroopData VillageTroopData
        {
            get;
            set;
        }

        #endregion

        public int this[BuildingType buildType]
        {
            get 
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        return this.Buildings.Headquarter;
                    case BuildingType.Academy:
                        return this.Buildings.Academy;
                    case BuildingType.Barracks:
                        return this.Buildings.Barracks;
                    case BuildingType.ClayPit:
                        return this.Buildings.ClayPit;
                    case BuildingType.Farm:
                        return this.Buildings.Farm;
                    case BuildingType.HidingPlace:
                        return this.Buildings.HidingPlace;
                    case BuildingType.IronMine:
                        return this.Buildings.IronMine;
                    case BuildingType.Market:
                        return this.Buildings.Market;
                    case BuildingType.Rally:
                        return this.Buildings.Rally;
                    case BuildingType.Smithy:
                        return this.Buildings.Smithy;
                    case BuildingType.Stable:
                        return this.Buildings.Stable;
                    case BuildingType.TimberCamp:
                        return this.Buildings.TimberCamp;
                    case BuildingType.Wall:
                        return this.Buildings.Wall;
                    case BuildingType.Warehouse:
                        return this.Buildings.Warehouse;
                    case BuildingType.Workshop:
                        return this.Buildings.Workshop;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        this.Buildings.Headquarter = value;
                        break;
                    case BuildingType.Academy:
                        this.Buildings.Academy = value;
                        break;
                    case BuildingType.Barracks:
                        this.Buildings.Barracks = value;
                        break;
                    case BuildingType.ClayPit:
                        this.Buildings.ClayPit = value;
                        break;
                    case BuildingType.Farm:
                        this.Buildings.Farm = value;
                        break;
                    case BuildingType.HidingPlace:
                        this.Buildings.HidingPlace = value;
                        break;
                    case BuildingType.IronMine:
                        this.Buildings.IronMine = value;
                        break;
                    case BuildingType.Market:
                        this.Buildings.Market = value;
                        break;
                    case BuildingType.Rally:
                        this.Buildings.Rally = value;
                        break;
                    case BuildingType.Smithy:
                        this.Buildings.Smithy = value;
                        break;
                    case BuildingType.Stable:
                        this.Buildings.Stable = value;
                        break;
                    case BuildingType.TimberCamp:
                        this.Buildings.TimberCamp = value;
                        break;
                    case BuildingType.Wall:
                        this.Buildings.Wall = value;
                        break;
                    case BuildingType.Warehouse:
                        this.Buildings.Warehouse = value;
                        break;
                    case BuildingType.Workshop:
                        this.Buildings.Workshop = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public int this[TroopType troopType]
        {
            get
            {
                switch (troopType)
                {
                    case TroopType.Axe:
                        return this.Troop.AxeInVillage;
                    case TroopType.Catapult:
                        return this.Troop.CatapultInVillage;
                    case TroopType.Heavy:
                        return this.Troop.HeavyCavalryInVillage;
                    case TroopType.Light:
                        return this.Troop.LightCavalryInVillage;
                    case TroopType.Nobleman:
                        return this.Troop.NobleInVillage;
                    case TroopType.Ram:
                        return this.Troop.RamInVillage;
                    case TroopType.Scout:
                        return this.Troop.ScoutInVillage;
                    case TroopType.Spear:
                        return this.Troop.SpearInVillage;
                    case TroopType.Sword:
                        return this.Troop.SwordInVillage;
                    default:
                        return -1;
                }
            }
        }
        public int this[ResourcesType resource]
        {
            get
            {
                switch (resource)
                {
                    case ResourcesType.Clay:
                        return this.Resources.Clay;
                        break;
                    case ResourcesType.Wood:
                        return this.Resources.Wood;
                        break;
                    case ResourcesType.Iron:
                        return this.Resources.Iron;
                        break;
                    default:
                        return 0;
                        break;
                }
            }
            set
            {
                switch (resource)
                {
                    case ResourcesType.Clay:
                        this.Resources.Clay = value;
                        break;
                    case ResourcesType.Wood:
                        this.Resources.Clay = value;
                        break;
                    case ResourcesType.Iron:
                        this.Resources.Clay = value;
                        break;
                    default:
                        break;
                }
            }
        }
        
        #endregion

        #region Static Members

        public static Village CreateVillage(ISession session)
        {

            Configuration config = Configuration.TribalWarsConfiguration;
            NumericConfiguration expandTo = config.GetNumericConfigurationItem("Village.expand_to");
            NumericConfiguration expandCount = config.GetNumericConfigurationItem("Village.expand_count");
            NumericConfiguration centerX = config.GetNumericConfigurationItem("Map.center_x");
            NumericConfiguration centerY = config.GetNumericConfigurationItem("Map.center_y");

            if (expandCount.Value >= (expandTo.Value * 2 + 1))
            {
                expandTo.Value++;
                expandCount.Value = 0;
            }
            expandCount.Value++;
            IList<Village> lst;
            Random r = new Random();
            int X, Y;

            do
            {
                X = (int)(centerX.Value + expandTo.Value * (r.Next(3) - 1));
                Y = (int)(centerY.Value + expandTo.Value * (r.Next(3) - 1));

                ICriteria criteria = session.CreateCriteria(typeof(Village));
                criteria.Add(Expression.Eq("X", X));
                criteria.Add(Expression.Eq("Y", Y));
                lst = criteria.List<Village>();
            } while (lst.Count > 0);

            Village village = new Village();
            village.VillageBuildingData = new VillageBuildingData();
            village.VillageTroopData = new VillageTroopData();
            village.VillageResourceData = new VillageResourcesData();
            village.VillageResearchData = new VillageReseachData();

            village.VillageBuildingData.Village = village;
            village.VillageTroopData.Village = village;
            village.VillageResourceData.Village = village;
            village.VillageResearchData.Village = village;

            village.X = X;
            village.Y = Y;
            village.Loyal = 100;

            village.UpgradeBuilding(BuildingType.Headquarter, 1);
            village.UpgradeBuilding(BuildingType.Rally, 1);
            village.UpgradeBuilding(BuildingType.Farm, 5);
            village.UpgradeBuilding(BuildingType.ClayPit, 5);
            village.UpgradeBuilding(BuildingType.IronMine, 5);
            village.UpgradeBuilding(BuildingType.TimberCamp, 5);
            village.UpgradeBuilding(BuildingType.Warehouse, 5);

            village.VillageResourceData.Iron = 2000;
            village.VillageResourceData.Clay = 2000;
            village.VillageResourceData.Wood = 2000;
            session.Update(config);
            return village;
        }

        public void UpgradeBuilding(BuildingType building, int level)
        {
            for (int i = this[building]; i <= level; i++)
                this.Points += Build.GetPrice(building, i, 1).Point;

            this[building] = level;
        }


        public void Save(ISession session)
        {
            session.Save(this);
            session.Save(this.VillageBuildingData);
            session.Save(this.VillageResourceData);
            session.Save(this.VillageResearchData);
            session.Save(this.VillageTroopData);
        }

        public Village GetVillageByID(int ID, ISession session)
        {
            return session.Load<Village>(ID);
        }

        public Village GetVillageByCoordinate(int x, int y, ISession session)
        {
            return (from village in session.Linq<Village>()
                    where village.X == x && village.Y == y
                    select village).SingleOrDefault<Village>();
        }
        
        #endregion

        public override string ToString()
        {
            return this.Name;
        }

        //Chưa xét trường hợp xây noble
        public void Update(DateTime to, ISession session)
        {
            
        }
  
    }
}