using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Text;
using NHibernate.Criterion;
using System.Linq;
using System.IO;

namespace beans
{
    
    public partial class Village:IdentityObject
    {

        private int _maxResources = -1;
        private double loyal;
        protected VillageResearchMethods villageResearchMethods = new VillageResearchMethods();
        protected VillageBuildingMethods villageBuildingMethods = new VillageBuildingMethods();
        protected VillageCommonMethods villageCommonMethods = new VillageCommonMethods();
        protected VillageTroopMethods villageTroopMethods = new VillageTroopMethods();
        protected VillageMarketMethods villageMarketMethods = new VillageMarketMethods();
        protected VillageRecruitMethods villageRecruitMethods = new VillageRecruitMethods();
        protected VillageResourceMethods villageResourceMethods = new VillageResourceMethods();
        protected VillageTransportMethods villageTransportMethods = new VillageTransportMethods();
        private Player _owner;
        public virtual Player Player
        {
            get { return this._owner; }
            set { this._owner = value; }
        }



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
        public virtual double Loyal
        {
            get { return loyal; }
            set
            {
                if (value > 100)
                    loyal = 100;
                else
                    loyal = value;
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
        public virtual double Population
        {
            get;
            set;
        }
        public virtual int Attack
        {
            get;
            set;
        }
        public virtual int Defense
        {
            get;
            set;
        }
        public virtual int Speed
        {
            get;
            set;
        }
        
        public virtual int MaxResources
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
        public virtual int MaxPopulation
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

        public virtual IList<Build> Builds
        {
            get;
            set;
        }
        public virtual IList<Recruit> Recruits
        {
            get;
            set;
        }
        public virtual IList<Offer> Offers
        {
            get;
            set;
        }
        public virtual IList<Research> Researches
        {
            get;
            set;
        }
        public virtual IList<MovingCommand> MovingCommandsFromMe
        {
            get;
            set;
        }
        public virtual IList<MovingCommand> MovingCommandsToMe
        {
            get;
            set;
        }
        public virtual IList<Station> StationsAtMe
        {
            get;
            set;
        }
        public virtual IList<Station> StationsFromMe
        {
            get;
            set;
        }

        public virtual VillageBuildingData VillageBuildingData
        {
            get;
            set;
        }
        public virtual VillageResourcesData VillageResourceData
        {
            get;
            set;
        }

        public virtual VillageTroopData VillageTroopData
        {
            get;
            set;
        }
        public virtual VillageResearchData VillageResearchData
        {
            get;
            set;
        }

        public virtual VillageResearchMethods VillageResearchMethods
        {
            get
            {
                return this.villageResearchMethods;
            }
        }
        public virtual VillageBuildingMethods VillageBuildingMethods
        {
            get
            {
                return this.villageBuildingMethods;
            }
        }
        public virtual VillageCommonMethods VillageCommonMethods
        {
            get
            {
                return this.villageCommonMethods;
            }
        }
        public virtual VillageTroopMethods VillageTroopMethods
        {
            get
            {
                return this.villageTroopMethods;
            }
        }

        public virtual VillageMarketMethods VillageMarketMethods
        {
            get {return this.villageMarketMethods;}
        }
        public virtual VillageRecruitMethods VillageRecruitMethods
        {
            get {return this.villageRecruitMethods;}
        }
        public virtual VillageResourceMethods VillageResourceMethods
        {
            get { return this.villageResourceMethods; }
        }
        public virtual VillageTransportMethods VillageTransportMethods
        {
            get { return this.villageTransportMethods; }
        }

        public virtual int this[BuildingType buildType]
        {
            get 
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        return this.VillageBuildingData.Headquarter;
                    case BuildingType.Academy:
                        return this.VillageBuildingData.Academy;
                    case BuildingType.Barracks:
                        return this.VillageBuildingData.Barracks;
                    case BuildingType.ClayPit:
                        return this.VillageBuildingData.ClayPit;
                    case BuildingType.Farm:
                        return this.VillageBuildingData.Farm;
                    case BuildingType.HidingPlace:
                        return this.VillageBuildingData.HidingPlace;
                    case BuildingType.IronMine:
                        return this.VillageBuildingData.IronMine;
                    case BuildingType.Market:
                        return this.VillageBuildingData.Market;
                    case BuildingType.Rally:
                        return this.VillageBuildingData.Rally;
                    case BuildingType.Smithy:
                        return this.VillageBuildingData.Smithy;
                    case BuildingType.Stable:
                        return this.VillageBuildingData.Stable;
                    case BuildingType.TimberCamp:
                        return this.VillageBuildingData.TimberCamp;
                    case BuildingType.Wall:
                        return this.VillageBuildingData.Wall;
                    case BuildingType.Warehouse:
                        return this.VillageBuildingData.Warehouse;
                    case BuildingType.Workshop:
                        return this.VillageBuildingData.Workshop;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        this.VillageBuildingData.Headquarter = value;
                        break;
                    case BuildingType.Academy:
                        this.VillageBuildingData.Academy = value;
                        break;
                    case BuildingType.Barracks:
                        this.VillageBuildingData.Barracks = value;
                        break;
                    case BuildingType.ClayPit:
                        this.VillageBuildingData.ClayPit = value;
                        break;
                    case BuildingType.Farm:
                        this.VillageBuildingData.Farm = value;
                        break;
                    case BuildingType.HidingPlace:
                        this.VillageBuildingData.HidingPlace = value;
                        break;
                    case BuildingType.IronMine:
                        this.VillageBuildingData.IronMine = value;
                        break;
                    case BuildingType.Market:
                        this.VillageBuildingData.Market = value;
                        break;
                    case BuildingType.Rally:
                        this.VillageBuildingData.Rally = value;
                        break;
                    case BuildingType.Smithy:
                        this.VillageBuildingData.Smithy = value;
                        break;
                    case BuildingType.Stable:
                        this.VillageBuildingData.Stable = value;
                        break;
                    case BuildingType.TimberCamp:
                        this.VillageBuildingData.TimberCamp = value;
                        break;
                    case BuildingType.Wall:
                        this.VillageBuildingData.Wall = value;
                        break;
                    case BuildingType.Warehouse:
                        this.VillageBuildingData.Warehouse = value;
                        break;
                    case BuildingType.Workshop:
                        this.VillageBuildingData.Workshop = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public virtual int this[TroopType troopType]
        {
            get
            {
                switch (troopType)
                {
                    case TroopType.Axe:
                        return this.VillageTroopData.AxeInVillage;
                    case TroopType.Catapult:
                        return this.VillageTroopData.CatapultInVillage;
                    case TroopType.Heavy:
                        return this.VillageTroopData.HeavyCavalryInVillage;
                    case TroopType.Light:
                        return this.VillageTroopData.LightCavalryInVillage;
                    case TroopType.Nobleman:
                        return this.VillageTroopData.NobleInVillage;
                    case TroopType.Ram:
                        return this.VillageTroopData.RamInVillage;
                    case TroopType.Scout:
                        return this.VillageTroopData.ScoutInVillage;
                    case TroopType.Spear:
                        return this.VillageTroopData.SpearInVillage;
                    case TroopType.Sword:
                        return this.VillageTroopData.SwordInVillage;
                    default:
                        return -1;
                }
            }
        }
        public virtual int this[ResourcesType resource]
        {
            get
            {
                switch (resource)
                {
                    case ResourcesType.Clay:
                        return this.VillageResourceData.Clay;
                    case ResourcesType.Wood:
                        return this.VillageResourceData.Wood;
                    case ResourcesType.Iron:
                        return this.VillageResourceData.Iron;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (resource)
                {
                    case ResourcesType.Clay:
                        this.VillageResourceData.Clay = value;
                        break;
                    case ResourcesType.Wood:
                        this.VillageResourceData.Wood = value;
                        break;
                    case ResourcesType.Iron:
                        this.VillageResourceData.Iron = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public virtual int this[ResearchType researchType]
        {
            get
            {
                switch (researchType)
                {
                    case ResearchType.Speed:
                        return this.VillageResearchData.TroopSpeed;
                    case ResearchType.Attack:
                        return this.VillageResearchData.Attack;
                    case ResearchType.Defense:
                        return this.VillageResearchData.Defense;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (researchType)
                {
                    case ResearchType.Speed:
                        this.VillageResearchData.TroopSpeed = value;
                        break;
                    case ResearchType.Attack:
                        this.VillageResearchData.Attack = value;
                        break;
                    case ResearchType.Defense:
                        this.VillageResearchData.Defense = value;
                        break;
                    default:
                        break;
                }
            }
        }

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
            village.VillageResearchData = new VillageResearchData();

            village.VillageBuildingData.Village = village;
            village.VillageTroopData.Village = village;
            village.VillageResourceData.Village = village;
            village.VillageResearchData.Village = village;

            village.X = X;
            village.Y = Y;
            village.Loyal = 100;
            village.LastUpdate = DateTime.Now;

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

            village.VillageResearchData.Attack = 1;
            village.VillageResearchData.Defense = 1;
            village.VillageResearchData.TroopSpeed = 1;

            config.InsertOrUpdateConfiguration(expandCount, session);
            config.InsertOrUpdateConfiguration(expandTo, session);
            return village;
        }

        
        public static Village GetVillageByID(int ID, ISession session)
        {
            return session.Load<Village>(ID);
        }

        public static Village GetVillageByCoordinate(int x, int y, ISession session)
        {
            return (from village in session.Linq<Village>()
                    where village.X == x && village.Y == y
                    select village).SingleOrDefault<Village>();
        }
        
        #endregion

        public Village()
        {
            this.villageResearchMethods.Village = this;
            this.villageBuildingMethods.Village = this;
            this.villageCommonMethods.Village = this;
            this.villageTroopMethods.Village = this;
            this.villageMarketMethods.Village = this;
            this.villageRecruitMethods.Village = this;
            this.villageResourceMethods.Village = this;
            this.villageTransportMethods.Village = this;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public virtual void UpgradeBuilding(BuildingType building, int level)
        {
            int currentLevel = this[building];
            this[building] = level;
            if (level > currentLevel)
            {
                for (int i = currentLevel; i < level; i++)
                {
                    BuildPrice price = Build.GetPrice(building, i, 1);
                    this.Points += price.Point;
                    this.Population += price.Population;
                }
                if (building == BuildingType.Market)
                {
                    this.VillageBuildingData.Merchant += VillageBuildingData.MerchantCountDictionary[level] - VillageBuildingData.MerchantCountDictionary[currentLevel];
                }
            }
            else
                for (int i = currentLevel; i > level; i--)
                {
                    BuildPrice price = Build.GetPrice(building, i, 1);
                    this.Points -= price.Point;
                    this.Population -= price.Population;
                }
        }

        public virtual void Save(ISession session)
        {
            session.Save(this);
            session.Save(this.VillageBuildingData);
            session.Save(this.VillageResourceData);
            //session.Save(this.VillageResearchData);
            session.Save(this.VillageTroopData);
        }
        
  
    }
}