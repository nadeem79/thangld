using System;
using System.Collections.Generic;
using NHibernate;
using System.Text;
using NHibernate.Criterion;

namespace beans
{
    
    [Serializable]
    public class Village:IdentityObject
    {
        #region Variables

        private int _loyal;
        [NonSerialized]
        private IList<MovingCommand> incomings;
        [NonSerialized]
        private IList<MovingCommand> outgoings;
        [NonSerialized]
        private IList<Offer> offers;
        //private IList<SendResource> sendings;
        [NonSerialized]
        private IList<MovingCommand> commands;
        [NonSerialized]
        private IList<Stationed> stationedTroops = new List<Stationed>();
        [NonSerialized]
        private IList<Stationed> troopsOutside = new List<Stationed>();
        [NonSerialized]
        private Player _owner;
        public Player Owner
        {
            get { return this._owner; }
            set { this._owner = value; }
        }
        #endregion

        #region Properties

        public int InVillageSpear
        {
            get;
            set;
        }
        public int InVillageSword
        {
            get;
            set;
        }
        public int InVillageAxe
        {
            get;
            set;
        }
        public int InVillageScout
        {
            get;
            set;
        }
        public int InVillageLight
        {
            get;
            set;
        }
        public int InVillageHeavy
        {
            get;
            set;
        }
        public int InVillageRam
        {
            get;
            set;
        }
        public int InVillageCatapult
        {
            get;
            set;
        }
        public int InVillageNoble
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
        public virtual DateTime LastUpdate
        {
            get;
            set;
        }
        public virtual int Points
        {
            get;
            set;
        }
        public virtual int Wall
        {
            get;
            set;
        }
        public virtual int HidingPlace
        {
            get;
            set;
        }
        public int Warehouse
        {
            get;
            set;
        }
        public virtual int Farm
        {
            get;
            set;
        }
        public virtual int IronMine
        {
            get;
            set;
        }
        public virtual int ClayPit
        {
            get;
            set;
        }
        public virtual int TimberCamp
        {
            get;
            set;
        }
        public virtual int Market
        {
            get;
            set;
        }
        public virtual int Rally
        {
            get;
            set;
        }
        public virtual int Smithy
        {
            get;
            set;
        }
        public virtual int Academy
        {
            get;
            set;
        }
        public virtual int Workshop
        {
            get;
            set;
        }
        public virtual int Stable
        {
            get;
            set;
        }
        public virtual int Barracks
        {
            get;
            set;
        }
        public virtual int Headquarter
        {
            get;
            set;
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
        
        public virtual int Wood
        {
            get;
            set;
        }
        public virtual int Clay
        {
            get;
            set;
        }
        public virtual int Iron
        {
            get;
            set;
        }
        public virtual int Noble
        {
            get;
            set;
        }
        public virtual int Spear
        {
            get;
            set;
        }
        public virtual int Sword
        {
            get;
            set;
        }
        public virtual int Axe
        {
            get;
            set;
        }
        public virtual int Scout
        {
            get;
            set;
        }
        public virtual int Light
        {
            get;
            set;
        }
        public virtual int Heavy
        {
            get;
            set;
        }
        public virtual int Ram
        {
            get;
            set;
        }
        public virtual int Catapult
        {
            get;
            set;
        }
        public int Population 
        {
            get;
            set;
        }
        

        public int ResearchSpear
        {
            get;
            set;
        }
        public int ResearchSword
        {
            get;
            set;
        }
        public int ResearchAxe
        {
            get;
            set;
        }
        public int ResearchScout
        {
            get;
            set;
        }
        public int ResearchLight
        {
            get;
            set;
        }
        public int ResearchHeavy
        {
            get;
            set;
        }
        public int ResearchRam
        {
            get;
            set;
        }
        public int ResearchCatapult
        {
            get;
            set;
        }
        public int ResearchNoble
        {
            get;
            set;
        }

        //public virtual IList<SendResource> Sendings
        //{
        //    get { return sendings; }
        //    set { sendings = value; }
        //}
        public virtual IList<Stationed> StationedTroops
        {
            get;
            set;
        }
        public virtual IList<Stationed> TroopsOutside
        {
            get;
            set;
        }

        public int TotalSpear
        {
            get
            {
                int supportSpear = this.Spear;
                foreach (Stationed stationed in this.StationedTroops)
                    supportSpear += stationed.Spear;
                return supportSpear;
            }
        }

        public int TotalSword
        {
            get
            {
                int result = this.Sword;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Sword;
                return result;
            }
        }

        public int TotalAxe
        {
            get
            {
                int result = this.Axe;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Axe;
                return result;
            }
        }

        public int TotalLight
        {
            get
            {
                int result = this.Light;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Light;
                return result;
            }
        }

        public int TotalScout
        {
            get
            {
                int result = this.Scout;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Scout;
                return result;
            }
        }

        public int TotalHeavy
        {
            get
            {
                int result = this.Heavy;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Heavy;
                return result;
            }
        }

        public int TotalRam
        {
            get
            {
                int result = this.Ram;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Ram;
                return result;
            }
        }

        public int TotalCatapult
        {
            get
            {
                int result = this.Catapult;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Catapult;
                return result;
            }
        }

        public int TotalNoble
        {
            get
            {
                int result = this.Noble;
                foreach (Stationed stationed in this.StationedTroops)
                    result += stationed.Noble;
                return result;
            }
        }

        public int this[BuildingType buildType]
        {
            get 
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        return this.Headquarter;
                    case BuildingType.Academy:
                        return this.Academy;
                    case BuildingType.Barracks:
                        return this.Barracks;
                    case BuildingType.ClayPit:
                        return this.ClayPit;
                    case BuildingType.Farm:
                        return this.Farm;
                    case BuildingType.HidingPlace:
                        return this.HidingPlace;
                    case BuildingType.IronMine:
                        return this.IronMine;
                    case BuildingType.Market:
                        return this.Market;
                    case BuildingType.Rally:
                        return this.Rally;
                    case BuildingType.Smithy:
                        return this.Smithy;
                    case BuildingType.Stable:
                        return this.Stable;
                    case BuildingType.TimberCamp:
                        return this.TimberCamp;
                    case BuildingType.Wall:
                        return this.Wall;
                    case BuildingType.Warehouse:
                        return this.Warehouse;
                    case BuildingType.Workshop:
                        return this.Workshop;
                    default:
                        return -1;
                }
            }
            set
            {
                switch (buildType)
                {
                    case BuildingType.Headquarter:
                        this.Headquarter = value;
                        break;
                    case BuildingType.Academy:
                        this.Academy = value;
                        break;
                    case BuildingType.Barracks:
                        this.Barracks = value;
                        break;
                    case BuildingType.ClayPit:
                        this.ClayPit = value;
                        break;
                    case BuildingType.Farm:
                        this.Farm = value;
                        break;
                    case BuildingType.HidingPlace:
                        this.HidingPlace = value;
                        break;
                    case BuildingType.IronMine:
                        this.IronMine = value;
                        break;
                    case BuildingType.Market:
                        this.Market = value;
                        break;
                    case BuildingType.Rally:
                        this.Rally = value;
                        break;
                    case BuildingType.Smithy:
                        this.Smithy = value;
                        break;
                    case BuildingType.Stable:
                        this.Stable = value;
                        break;
                    case BuildingType.TimberCamp:
                        this.TimberCamp = value;
                        break;
                    case BuildingType.Wall:
                        this.Wall = value;
                        break;
                    case BuildingType.Warehouse:
                        this.Warehouse = value;
                        break;
                    case BuildingType.Workshop:
                        this.Workshop = value;
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
                        return this.TotalAxe;
                    case TroopType.Catapult:
                        return this.TotalCatapult;
                    case TroopType.Heavy:
                        return this.TotalHeavy;
                    case TroopType.Light:
                        return this.TotalLight;
                    case TroopType.Nobleman:
                        return this.TotalNoble;
                    case TroopType.Ram:
                        return this.TotalRam;
                    case TroopType.Scout:
                        return this.TotalScout;
                    case TroopType.Spear:
                        return this.TotalSpear;
                    case TroopType.Sword:
                        return this.TotalSword;
                    default:
                        return -1;
                }
            }
        }

        public int MaxResources
        {
            get
            {
                if (this[BuildingType.Warehouse] == 1)
                    return 1000;
                else if (this[BuildingType.Warehouse] == 0)
                    return 0;

                int result = 1000;

                for (int i = 1; i < this[BuildingType.Warehouse]; i++)
                    result += (int)(result * 0.3);

                return result;
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

        #endregion

        #region Constructors
        public Village() 
        {
            //this.sendings = new List<SendResource>();
            this.offers = new List<Offer>();
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
            village.X = X;
            village.Y = Y;
            village.Headquarter = 1;
            village.Rally = 1;
            village.Farm = 5;
            village.ClayPit = 5;
            village.IronMine = 5;
            village.TimberCamp = 5;
            village.Warehouse = 5;

            village.Iron = 2000;
            village.Clay = 2000;
            village.Wood = 2000;
            session.Update(config);
            return village;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        public int ProductPerHour(ResourcesType type)
        {
            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.IronMine;
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
                    level = this.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.IronMine;
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
            this.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

        }

        protected IList<MovingCommand> GetDependingCommands(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Or(Expression.Eq("To", this), Expression.Eq("From", this)));
            criteria.Add(Expression.Lt("LandingTime", to));
            criteria.Add(Expression.Ge("StartTime", this.LastUpdate));
            criteria.AddOrder(new Order("LandingTime", true));
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

        //Chưa xét trường hợp xây nhà, xây noble và xe
        public void Update(DateTime to, ISession session)
        {
            this.Loyal += (int)(to - this.LastUpdate).TotalHours;

            IList<MovingCommand> lstMovingCommands = this.GetDependingCommands(to, session);
            IList<Recruit> lstInfantryRecruits = this.GetDependingInfantryRecruit(session);
            IList<Recruit> lstCavalryRecruits = this.GetDependingCavalryRecruit(session);
            
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

            this.UpdateResources(this.LastUpdate, to);
            this.LastUpdate = to;
            
            session.Update(this);
        }

        public int MaxRecruit(TroopType troop)
        {
            return Recruit.MaxRecruit(troop, this.Wood, this.Clay, this.Iron);
        }

        public Recruit BeginRecruit(TroopType troop, int quantity, ISession session)
        {
            if (!Recruit.CanRecruit(troop, quantity, this.Wood, this.Clay, this.Iron))
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
            this.Clay -= p.Clay * quantity;
            this.Wood -= p.Wood * quantity;
            this.Iron -= p.Iron * quantity;

            session.Save(recruit);
            session.Update(this);
            
            return recruit;
        }

        public int GetIncomingAttackCount(ISession session)
        {
            return 0;
        }

        public int GetIncomingSupportCount(ISession session)
        {
            return 0;
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
            criteria.Add(Expression.Gt("LandingTime", DateTime.Now));
            criteria.AddOrder(Order.Asc("LandingTime"));
            IList<MovingCommand> lst = criteria.List<MovingCommand>();
            return lst;
        } 

        public IList<MovingCommand> GetIncomingTroop(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Eq("Pending", false));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Gt("LandingTime", DateTime.Now));
            criteria.AddOrder(Order.Desc("LandingTime"));

            return criteria.List<MovingCommand>();
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

        public void CancelRecruit(Recruit recruit, ISession session)
        {
            Price price = Recruit.GetPrice(recruit.Troop);
            this.Wood += price.Wood * recruit.Quantity;
            this.Clay += price.Clay * recruit.Quantity;
            this.Iron += price.Iron * recruit.Quantity;
            session.Update(this);
            session.Delete(recruit);
        }

        #endregion       
    }
}