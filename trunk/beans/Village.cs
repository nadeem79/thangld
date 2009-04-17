using System;
using System.Collections.Generic;
using NHibernate;
using System.Text;
using NHibernate.Criterion;

namespace beans
{
    
    public class Village:IdentityObject
    {
        #region Variables

        private int _loyal, _maxResources = -1;
        
        private IList<Stationed> stationedTroops = new List<Stationed>();
        private IList<Stationed> troopsOutside = new List<Stationed>();
        private Player _owner;
        public Player Owner
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
        public int Loyal
        {
            get { return _loyal; }
            set
            {
                if (value > 100)
                    _loyal = 100;
                else
                    _loyal = value;
            }
        }
        protected long LastUpdateTimestamp
        {
            get;
            set;
        }
        public virtual DateTime LastUpdate
        {
            get
            {
                return DatetimeHelper.TimestampToDatetime(LastUpdateTimestamp);
            }
            set
            {
                this.LastUpdateTimestamp = DatetimeHelper.DatetimeToInt64(value);
            }
        }
        public virtual int Points
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

        public VillageBuildingData Buildings
        {
            get;
            set;
        }
        public VillageResourcesData Resources
        {
            get;
            set;
        }
        public VillageReseachData Research
        {
            get;
            set;
        }
        public VillageTroopData Troop
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
                        return this.Troop.TotalAxe;
                    case TroopType.Catapult:
                        return this.Troop.TotalCatapult;
                    case TroopType.Heavy:
                        return this.Troop.TotalHeavy;
                    case TroopType.Light:
                        return this.Troop.TotalLight;
                    case TroopType.Nobleman:
                        return this.Troop.TotalNoble;
                    case TroopType.Ram:
                        return this.Troop.TotalRam;
                    case TroopType.Scout:
                        return this.Troop.TotalScout;
                    case TroopType.Spear:
                        return this.Troop.TotalSpear;
                    case TroopType.Sword:
                        return this.Troop.TotalSword;
                    default:
                        return -1;
                }
            }
        }
        
        #endregion

        #region Constructors
        public Village() 
        {
            
        }

        #endregion

        #region Static Members

        public static int CheckVillage(int x, int y, ISession session)
        {
            IQuery query = session.CreateQuery("select v.ID from Village as v where v.X=:X and v.Y=:Y");
            query.SetInt32("X", x);
            query.SetInt32("Y", y);

            IList<int> lst = query.List<int>();
            if (lst.Count == 0)
                return -1;
            return lst[0];
        }

        public static Village CreateVillage(ISession session)
        {

            Configuration config = session.Load<Configuration>(1);

            if (config.Index >= (config.Expand * 2 + 1))
            {
                config.Expand++;
                config.Index = 0;
            }
            config.Index++;
            IList<Village> lst;
            Random r = new Random();
            int X, Y;

            do
            {
                X = 50 + config.Expand * (r.Next(3) - 1);
                Y = 50 + config.Expand * (r.Next(3) - 1);

                ICriteria criteria = session.CreateCriteria(typeof(Village));
                criteria.Add(Expression.Eq("X", X));
                criteria.Add(Expression.Eq("Y", Y));
                lst = criteria.List<Village>();
            } while (lst.Count > 0);

            Village village = new Village();
            village.Buildings = new VillageBuildingData();
            village.Troop = new VillageTroopData();
            village.Resources = new VillageResourcesData();
            village.Research = new VillageReseachData();

            village.Buildings.Village = village;
            village.Troop.Village = village;
            village.Resources.Village = village;
            village.Research.Village = village;

            village.X = X;
            village.Y = Y;
            village.Buildings.Headquarter = 1;
            village.Buildings.Rally = 1;
            village.Buildings.Farm = 5;
            village.Buildings.ClayPit = 5;
            village.Buildings.IronMine = 5;
            village.Buildings.TimberCamp = 5;
            village.Buildings.Warehouse = 5;
            village.Loyal = 100;

            village.Points += Build.GetPrice(BuildingType.Headquarter).Point;
            village.Points += Build.GetPrice(BuildingType.Rally).Point;
            for (int i = 1; i <= 5; i++)
            {
                village.Points += Build.GetPrice(BuildingType.Farm, i, 1).Point;
                village.Points += Build.GetPrice(BuildingType.Warehouse, i, 1).Point;
                village.Points += Build.GetPrice(BuildingType.ClayPit, i, 1).Point;
                village.Points += Build.GetPrice(BuildingType.IronMine, i, 1).Point;
                village.Points += Build.GetPrice(BuildingType.TimberCamp, i, 1).Point;
            }

            village.Resources.Iron = 2000;
            village.Resources.Clay = 2000;
            village.Resources.Wood = 2000;
            session.Update(config);
            return village;
        }

        public void Save(ISession session)
        {
            session.Save(this);
            session.Save(this.Buildings);
            session.Save(this.Resources);
            session.Save(this.Research);
            session.Save(this.Troop);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #region Methods.Resources

        public int ProductPerHour(ResourcesType type)
        {
            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.Buildings.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Buildings.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Buildings.IronMine;
                    break;
                default:
                    break;
            }

            if (level == 0)
                return 0;
            int result = 20;
            for (int i = 0; i < level; i++)
                result += (int)(result * 0.2);
            return result;
        }
        public double SecondPerResourceUnit(ResourcesType type)
        {

            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.Buildings.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Buildings.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Buildings.IronMine;
                    break;
                default:
                    break;
            }

            double production = this.ProductPerHour(type);
            if (production == 0)
                return double.MaxValue;
            return (double)3600 / production;
        }
        public void UpdateResources(DateTime from, DateTime to)
        {
            TimeSpan span = to - from;
            double time = span.TotalHours;
            this.Resources.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.Resources.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.Resources.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

            if (this.Resources.Clay > this.MaxResources)
                this.Resources.Clay = this.MaxResources;
            if (this.Resources.Wood > this.MaxResources)
                this.Resources.Wood = this.MaxResources;
            if (this.Resources.Iron > this.MaxResources)
                this.Resources.Iron = this.MaxResources;
        }
        
        #endregion

        #region Methods.Troops

        public int GetIncomingAttackCount(ISession session)
        {
            IQuery query = session.CreateQuery("select count(a.ID) from Attack a where a.To=:village");
            query.SetEntity("village", this);
            return Convert.ToInt32(query.List()[0]);
        }
        public int GetIncomingSupportCount(ISession session)
        {
            IQuery query = session.CreateQuery("select count(s.ID) from Support s where s.To=:village");
            query.SetEntity("village", this);
            return Convert.ToInt32(query.List()[0]);
        }
        protected IList<MovingCommand> GetDependingCommands(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Or(Expression.Eq("To", this), Expression.Eq("From", this)));
            criteria.Add(Expression.Lt("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Ge("StartTimestamp", this.LastUpdateTimestamp));
            criteria.AddOrder(new Order("LandingTimestamp", true));
            return criteria.List<MovingCommand>();
        }
        protected IList<Recruit> GetDependingInfantryRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Axe), Expression.Or(Expression.Eq("Troop", TroopType.Spear), Expression.Eq("Troop", TroopType.Sword))));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
        protected IList<Recruit> GetDependingCavalryRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Scout), Expression.Or(Expression.Eq("Troop", TroopType.Light), Expression.Eq("Troop", TroopType.Heavy))));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
        public IList<MovingCommand> GetTroopMovement(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));

            criteria.Add(
                Expression.Or(
                    Expression.Eq("To", this),
                    Expression.Eq("From", this))                
                );
            criteria.Add(Expression.Eq("Pending", false));
            criteria.Add(Expression.Gt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(DateTime.Now)));
            criteria.AddOrder(Order.Asc("LandingTimestamp"));
            IList<MovingCommand> lst = criteria.List<MovingCommand>();
            return lst;
        } 
        public IList<MovingCommand> GetIncomingTroop(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Eq("Pending", false));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Gt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(DateTime.Now)));
            criteria.AddOrder(Order.Desc("LandingTimestamp"));

            return criteria.List<MovingCommand>();
        }
        
        #endregion 
        
        #region Methods.Recruit

        public int MaxRecruit(TroopType troop)
        {
            return Recruit.MaxRecruit(troop, this.Resources.Wood, this.Resources.Clay, this.Resources.Iron);
        }
        public Recruit BeginRecruit(TroopType troop, int quantity, ISession session)
        {
            if (!Recruit.CanRecruit(troop, quantity, this.Resources.Wood, this.Resources.Clay, this.Resources.Iron))
                return null;

            int level = 0;
            if ((troop == TroopType.Axe) || (troop == TroopType.Spear) || (troop == TroopType.Sword))
                level = this[BuildingType.Barracks];
            if ((troop == TroopType.Light) || (troop == TroopType.Scout) || (troop == TroopType.Heavy))
                level = this[BuildingType.Stable];
            
            Recruit recruit = new Recruit();
            recruit.InVillage = this;
            recruit.Quantity = quantity;
            recruit.Troop = troop;
            recruit.LastUpdate = DateTime.Now;

            Price p = Recruit.GetPrice(troop);
            this.Resources.Clay -= p.Clay * quantity;
            this.Resources.Wood -= p.Wood * quantity;
            this.Resources.Iron -= p.Iron * quantity;

            session.Save(recruit);
            session.Update(this);
            
            return recruit;
        }
        public IList<Recruit> GetRecruit(ISession session, BuildingType building)
        {

            switch (building)
            {
                case BuildingType.Barracks:
                case BuildingType.Academy:
                case BuildingType.Stable:
                case BuildingType.Workshop:
                    break;
                default:
                    throw new Exception("Hack hả ku :))");
            }
            
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Gt("Quantity", 0));
            criteria.AddOrder(new Order("ID", true));

            switch (building)
            {
                case BuildingType.Barracks:
                    criteria.Add(Expression.Or(
                        Expression.Or(
                            Expression.Eq("Troop", TroopType.Axe), 
                            Expression.Eq("Troop", TroopType.Spear)), 
                        Expression.Eq("Troop", TroopType.Sword)));
                    break;
                case BuildingType.Stable:
                    criteria.Add(Expression.Or(
                        Expression.Or(
                            Expression.Eq("Troop", TroopType.Scout), 
                            Expression.Eq("Troop", TroopType.Light)), 
                        Expression.Eq("Troop", TroopType.Heavy)));
                    break;
                case BuildingType.Workshop:
                    criteria.Add(Expression.Or(
                        Expression.Eq("Troop", TroopType.Ram),
                        Expression.Eq("Troop", TroopType.Catapult)));
                    break;
                case BuildingType.Academy:
                    criteria.Add(Expression.Eq("Troop", TroopType.Nobleman));
                    break;
                default:
                    throw new Exception("Hack hả ku :))");
            }
            return criteria.List<Recruit>();
        }
        public void CancelRecruit(int recruit_id, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("ID", recruit_id));
            criteria.Add(Expression.Eq("InVillage", this));
            Recruit recruit = criteria.UniqueResult<Recruit>();
            if (recruit == null)
                return;

            Price price = Recruit.GetPrice(recruit.Troop);
            this.Resources.Wood += price.Wood * recruit.Quantity;
            this.Resources.Clay += price.Clay * recruit.Quantity;
            this.Resources.Iron += price.Iron * recruit.Quantity;
            this.Population -= (int)(price.Population * recruit.Quantity);
            session.Update(this);
            session.Delete(recruit);
        }

        #endregion

        #region Methods.Building

        public BuildableStatus PrepareBuild(BuildingType building, ISession session)
        {
            BuildPrice price = Build.GetPrice(building, this.GetTotalBuildingLevel(building, session) + 1, this.Buildings.Headquarter);

            BuildableStatus status = this.CanBuild(building, session);

            if (status != BuildableStatus.JustDoIt)
                return status;
            Build build = new Build();
            build.Building = building;
            build.InVillage = this;
            build.Start = DateTime.Now;
            build.End = DateTime.Now.AddSeconds(price.BuildTime);
            this.Resources.Wood -= price.Wood;
            this.Resources.Clay -= price.Clay;
            this.Resources.Iron -= price.Iron;
            session.Save(build);
            session.Update(this);
            

            return status;
        }
        public int GetTotalBuildingLevel(BuildingType type, ISession session)
        {
            IQuery query = session.CreateQuery("select count(b.ID) from Build b where b.InVillage=:village and b.Building=:type");
            query.SetEntity("village", this);
            query.SetEnum("type", type);
            return Convert.ToInt32(query.List()[0]) + this[type];
        }
        public int GetTotalBuild(ISession session)
        {
            IQuery query = session.CreateQuery("select count(b.ID) from Build b where b.InVillage=:village");
            query.SetEntity("village", this);
            return Convert.ToInt32(query.List()[0]);
        }
        public BuildableStatus CanBuild(BuildingType type, ISession session)
        {
            if (this[type] == 0)
            {
                switch (type)
                {
                    case BuildingType.Headquarter:
                        if (this[BuildingType.Headquarter] == 0)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Barracks:
                        if (this[BuildingType.Headquarter] < 3)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Stable:
                        if (this[BuildingType.Headquarter] < 10 && this[BuildingType.Smithy] < 5 && this[BuildingType.Barracks] < 5)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Workshop:
                        if (this[BuildingType.Headquarter] < 10 && this[BuildingType.Smithy] < 10)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Academy:
                        if (this[BuildingType.Headquarter] < 20 && this[BuildingType.Smithy] < 20 && this[BuildingType.Market] < 10)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Smithy:
                        if (this[BuildingType.Headquarter] < 5 && this[BuildingType.Barracks] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Rally:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Market:
                        if (this[BuildingType.Headquarter] < 2 && this[BuildingType.Warehouse] < 2)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.TimberCamp:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.ClayPit:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.IronMine:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Farm:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Warehouse:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.HidingPlace:
                        if (this[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Wall:
                        if (this[BuildingType.Headquarter] < 1 && this[BuildingType.Barracks] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    default:
                        break;
                }
            }


            int iTotalLevel = this.GetTotalBuildingLevel(type, session);

            BuildPrice price = Build.GetPrice(type, iTotalLevel + 1, this[BuildingType.Headquarter]);
            if (iTotalLevel >= price.MaxLevel)
                return BuildableStatus.BuildingLevelExceed;

            if ((this.MaxPopulation - this.Population) < price.Population)
                return BuildableStatus.NotEnoughFarm;

            if (this.Resources.Wood < price.Wood)
                return BuildableStatus.NotEnoughWood;
            if (this.Resources.Clay < price.Clay)
                return BuildableStatus.NotEnoughClay;
            if (this.Resources.Iron < price.Iron)
                return BuildableStatus.NotEnoughIron;

            if (this.GetTotalBuild(session) >= 5)
                return BuildableStatus.BuildNumberExceed;

            return BuildableStatus.JustDoIt;
            
        }
        public IList<Build> GetPendingConstruction(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Build));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.AddOrder(Order.Asc("ID"));

            return criteria.List<Build>();
        }
        public void CancelBuild(int id, ISession session)
        {

            ICriteria criteria = session.CreateCriteria(typeof(Build));
            criteria.Add(Expression.Eq("ID", id));
            criteria.Add(Expression.Eq("InVillage", this));
            IList<Build> lstBuild = criteria.List<Build>();
            if (lstBuild.Count == 0)
                return;

            Build build = lstBuild[0];
            BuildPrice price = Build.GetPrice(build.Building, this[build.Building], this[BuildingType.Headquarter]);

            session.Evict(build.InVillage);
            build.InVillage = this;

            build.InVillage.Resources.Wood += price.Wood;
            build.InVillage.Resources.Clay += price.Clay;
            build.InVillage.Resources.Iron += price.Iron;

            session.Delete(build);
            session.Update(build.InVillage);
        }

        #endregion

        //Chưa xét trường hợp xây nhà, xây noble và xe
        public void Update(DateTime to, ISession session)
        {
            this.Loyal += (int)(to - this.LastUpdate).TotalHours;

            IList<MovingCommand> lstMovingCommands = this.GetDependingCommands(to, session);
            IList<Recruit> lstInfantryRecruits = this.GetDependingInfantryRecruit(session);
            IList<Recruit> lstCavalryRecruits = this.GetDependingCavalryRecruit(session);
            IList<Build> lstConstructing = this.GetPendingConstruction(session);

            

            foreach (MovingCommand command in lstMovingCommands)
            {
                this.UpdateResources(this.LastUpdate, command.LandingTime);
                if (lstInfantryRecruits.Count > 0)
                    while (lstInfantryRecruits[0].Expense(command.LandingTime))
                    {
                        DateTime start = lstInfantryRecruits[0].LastUpdate;
                        session.Delete(lstInfantryRecruits[0]);
                        lstInfantryRecruits.RemoveAt(0);
                        if (lstInfantryRecruits.Count == 0)
                            break;
                        else
                            lstInfantryRecruits[0].LastUpdate = start;
                    }

                

                if (lstCavalryRecruits.Count > 0)
                    while (lstCavalryRecruits[0].Expense(command.LandingTime))
                    {
                        DateTime start = lstCavalryRecruits[0].LastUpdate;
                        session.Delete(lstCavalryRecruits[0]);
                        lstCavalryRecruits.RemoveAt(0);
                        if (lstCavalryRecruits.Count == 0)
                            break;
                        else
                            lstCavalryRecruits[0].LastUpdate = start;
                    }

                if (lstConstructing.Count > 0)
                    while (lstConstructing[0].expense(command.LandingTime))
                    {
                        DateTime end = lstConstructing[0].End;
                        session.Delete(lstConstructing[0]);
                        lstConstructing.RemoveAt(0);
                        if (lstConstructing.Count == 0)
                            break;
                        else
                        {
                            TimeSpan t = lstConstructing[0].End - lstConstructing[0].Start;
                            lstConstructing[0].Start = end;
                            lstConstructing[0].End = lstConstructing[0].Start + t;
                        }
                    }

                command.effect(session);
            }

            if (lstInfantryRecruits.Count > 0)
                while (lstInfantryRecruits[0].Expense(to))
                {
                    DateTime start = lstInfantryRecruits[0].LastUpdate;
                    session.Delete(lstInfantryRecruits[0]);
                    lstInfantryRecruits.RemoveAt(0);
                    if (lstInfantryRecruits.Count == 0)
                        break;
                    else
                        lstInfantryRecruits[0].LastUpdate = start;
                }
            if (lstInfantryRecruits.Count > 0)
                session.Update(lstInfantryRecruits[0]);

            if (lstCavalryRecruits.Count > 0)
                while (lstCavalryRecruits[0].Expense(to))
                {
                    DateTime start = lstCavalryRecruits[0].LastUpdate;
                    session.Delete(lstCavalryRecruits[0]);
                    lstCavalryRecruits.RemoveAt(0);
                    if (lstCavalryRecruits.Count == 0)
                        break;
                    else
                        lstCavalryRecruits[0].LastUpdate = start;
                }
            if (lstCavalryRecruits.Count > 0)
                session.Update(lstCavalryRecruits[0]);

            if (lstConstructing.Count > 0)
                while (lstConstructing[0].expense(to))
                {
                    DateTime end = lstConstructing[0].End;
                    session.Delete(lstConstructing[0]);
                    lstConstructing.RemoveAt(0);
                    if (lstConstructing.Count == 0)
                        break;
                    else
                    {
                        TimeSpan t = lstConstructing[0].End - lstConstructing[0].Start;
                        lstConstructing[0].Start = end;
                        lstConstructing[0].End = lstConstructing[0].Start + t;
                    }
                }
            if (lstConstructing.Count > 0)
                session.Update(lstConstructing[0]);

            this.UpdateResources(this.LastUpdate, to);
            this.LastUpdate = to;

            session.Update(this);
            session.Update(this.Owner);
        }

        #endregion       
    }
}