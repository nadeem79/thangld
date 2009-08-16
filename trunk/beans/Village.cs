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
        #region Variables

        private int _maxResources = -1;
        private double loyal;
        
        private Player _owner;
        public virtual Player Player
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

        #endregion

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
                        this.VillageResourceData.Clay = value;
                        break;
                    case ResourcesType.Iron:
                        this.VillageResourceData.Clay = value;
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
            //village.VillageResearchData = new VillageReseachData();

            village.VillageBuildingData.Village = village;
            village.VillageTroopData.Village = village;
            village.VillageResourceData.Village = village;
            //village.VillageResearchData.Village = village;

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

        //Chưa xét trường hợp xây noble
        public virtual void Update(DateTime to, ISession session)
        {


            IList<MovingCommand> commands = (from movingCommand in session.Linq<MovingCommand>()
                                             where (movingCommand.FromVillage == this || movingCommand.ToVillage == this)
                                             && movingCommand.LandingTime < to
                                             orderby movingCommand.LandingTime ascending
                                             select movingCommand).ToList<MovingCommand>();

            IList<Build> builds = (from build in session.Linq<Build>()
                                   where build.InVillage == this
                                   && build.End < to
                                   orderby build.ID ascending
                                   select build).ToList<Build>();

            IList<Recruit> recruits = (from recruit in session.Linq<Recruit>()
                                       where recruit.InVillage == this
                                       orderby recruit.ID ascending
                                       select recruit).ToList<Recruit>();
            IList<Recruit> infantryRecruits = (from recruit in recruits
                                               where recruit.Troop == TroopType.Axe
                                               || recruit.Troop == TroopType.Spear
                                               || recruit.Troop == TroopType.Sword
                                               select recruit).ToList<Recruit>();
            IList<Recruit> cavalryRecruits = (from recruit in recruits
                                               where recruit.Troop == TroopType.Scout
                                               || recruit.Troop == TroopType.Light
                                               || recruit.Troop == TroopType.Heavy
                                               select recruit).ToList<Recruit>();
            IList<Recruit> carRecruits = (from recruit in recruits
                                               where recruit.Troop == TroopType.Ram
                                               || recruit.Troop == TroopType.Catapult
                                               select recruit).ToList<Recruit>();

            DateTime currentTime = this.LastUpdate;

            while (commands.Count > 0)
            {
                MovingCommand command = commands[0];
                if (command.ToVillage == this)
                {
                    this.UpdateResources(currentTime, command.LandingTime);
                    while (builds.Count > 0 && builds[0].End < command.LandingTime)
                    {
                        this[builds[0].Building]++;
                        session.Delete(builds[0]);
                        builds.RemoveAt(0);
                    }

                    while (infantryRecruits.Count > 0 && infantryRecruits[0].Expense(command.LandingTime))
                    {
                        session.Delete(infantryRecruits[0]);
                        infantryRecruits.RemoveAt(0);
                    }
                    while (cavalryRecruits.Count > 0 && cavalryRecruits[0].Expense(command.LandingTime))
                    {
                        session.Delete(cavalryRecruits[0]);
                        cavalryRecruits.RemoveAt(0);
                    }
                    while (carRecruits.Count > 0 && carRecruits[0].Expense(command.LandingTime))
                    {
                        session.Delete(carRecruits[0]);
                        carRecruits.RemoveAt(0);
                    }

                    MovingCommand newCommand = command.Effect(session);
                    if (newCommand != null)
                        session.Save(newCommand);

                    currentTime = command.LandingTime;
                }
                else
                {
                    command.ToVillage.Update(command.LandingTime, session);
                    MovingCommand newCommand = command.Effect(session);
                    if (newCommand != null && newCommand.LandingTime < to)
                    {
                        commands.Add(newCommand);
                        for (int i = 1; i < commands.Count; i++)
                            if (commands[i].LandingTime > newCommand.LandingTime)
                                commands.Insert(i, newCommand);
                    }
                }
                commands.RemoveAt(0);
            }

            this.UpdateResources(currentTime, to);
            while (builds.Count > 0 && builds[0].End < to)
            {
                this[builds[0].Building]++;
                session.Delete(builds[0]);
                builds.RemoveAt(0);
            }
            

            while (infantryRecruits.Count > 0 && infantryRecruits[0].Expense(to))
            {
                session.Delete(infantryRecruits[0]);
                infantryRecruits.RemoveAt(0);
            }
            if (infantryRecruits.Count > 0)
                session.Update(infantryRecruits[0]);
            while (cavalryRecruits.Count > 0 && cavalryRecruits[0].Expense(to))
            {
                session.Delete(cavalryRecruits[0]);
                cavalryRecruits.RemoveAt(0);
            }
            if (cavalryRecruits.Count > 0)
                session.Update(cavalryRecruits[0]);
            while (carRecruits.Count > 0 && carRecruits[0].Expense(to))
            {
                session.Delete(carRecruits[0]);
                carRecruits.RemoveAt(0);
            }
            if (carRecruits.Count > 0)
                session.Update(carRecruits[0]);

            this.LastUpdate = to;
        }
  
    }
}