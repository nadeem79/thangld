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

        private int x;
        private int y;
        private string name;
        private User owner;
        private int wood;
        private int iron;
        private int clay;
        private int headquarter;
        private int barracks;
        private int stable;
        private int workshop;
        private int academy;
        private int smithy;
        private int rally;
        private int market;
        private int timberCamp;
        private int clayPit;
        private int ironMine;
        private int farm;
        private int warehouse;
        private int hidingPlace;
        private int wall;
        private int points;
        private DateTime lastUpdate;
        private int spear;
        private int sword;
        private int axe;
        private int catapult;
        private int scout;
        private int light;
        private int ram;
        private int heavy;
        private int noble;
        private int loyal;
        private IList<MovingCommand> incomings;
        private IList<MovingCommand> outgoings;
        private IList<Offer> offers;
        private IList<SendResource> sendings;
        private IList<MovingCommand> commands;
        private IList<Stationed> stationedTroops = new List<Stationed>();        
        private IList<Stationed> troopsOutside = new List<Stationed>();

        #endregion

        #region Properties

        public int Loyal
        {
            get { return loyal; }
            set { loyal = value; }
        }

        public virtual DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }
        public virtual int Points
        {
            get { return points; }
            set { points = value; }
        }
        public virtual int Wall
        {
            get { return wall; }
            set { wall = value; }
        }

        public virtual int HidingPlace
        {
            get { return hidingPlace; }
            set { hidingPlace = value; }
        }

        public int Warehouse
        {
            get { return warehouse; }
            set { warehouse = value; }
        }

        public virtual int Farm
        {
            get { return farm; }
            set { farm = value; }
        }

        public virtual int IronMine
        {
            get { return ironMine; }
            set { ironMine = value; }
        }

        public virtual int ClayPit
        {
            get { return clayPit; }
            set { clayPit = value; }
        }

        public virtual int TimberCamp
        {
            get { return timberCamp; }
            set { timberCamp = value; }
        }

        public virtual int Market
        {
            get { return market; }
            set { market = value; }
        }

        public virtual int Rally
        {
            get { return rally; }
            set { rally = value; }
        }

        public virtual int Smithy
        {
            get { return smithy; }
            set { smithy = value; }
        }

        public virtual int Academy
        {
            get { return academy; }
            set { academy = value; }
        }

        public virtual int Workshop
        {
            get { return workshop; }
            set { workshop = value; }
        }

        public virtual int Stable
        {
            get { return stable; }
            set { stable = value; }
        }

        public virtual int Barracks
        {
            get { return barracks; }
            set { barracks = value; }
        }

        public virtual int Headquarter
        {
            get { return headquarter; }
            set { headquarter = value; }
        }

        public virtual int X
        {
            get { return x; }
            set { x = value; }
        }
        public virtual int Y
        {
            get { return y; }
            set { y = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual User Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public virtual int Wood 
        { 
            get 
            {
                return this.wood;
            } 

            set
            {
                this.wood = value;
            } 
        
        }

        public virtual int Clay 
        { 
            get
            {
                return this.clay;
            }
            set
            {
                this.clay = value;
            }
        }

        public virtual int Iron
        {
            get
            {
                return this.iron;
            }
            set
            {
                this.iron = value;
            }
        }

        public virtual int Noble
        {
            get { return noble; }
            set { noble = value; }
        }

        public virtual int Spear
        {
            get { return spear; }
            set { spear = value; }
        }

        public virtual int Sword
        {
            get { return sword; }
            set { sword = value; }
        }

        public virtual int Axe
        {
            get { return axe; }
            set { axe = value; }
        }

        public virtual int Scout
        {
            get { return scout; }
            set { scout = value; }
        }

        public virtual int Light
        {
            get { return light; }
            set { light = value; }
        }

        public virtual int Heavy
        {
            get { return heavy; }
            set { heavy = value; }
        }

        public virtual int Ram
        {
            get { return ram; }
            set { ram = value; }
        }

        public virtual int Catapult
        {
            get { return catapult; }
            set { catapult = value; }
        }

        public virtual IList<MovingCommand> Incomings
        {
            get { return this.incomings; }
            set { this.incomings = value; }
        }

        public virtual IList<MovingCommand> Outgoings
        {
            get { return this.outgoings; }
            set { this.outgoings = value; }
        }

        public virtual IList<Offer> Offers
        {
            get { return offers; }
            set { offers = value; }
        }

        public virtual IList<SendResource> Sendings
        {
            get { return sendings; }
            set { sendings = value; }
        }

        public virtual IList<Stationed> StationedTroops
        {
            get { return stationedTroops; }
            set { stationedTroops = value; }
        }

        public virtual IList<Stationed> TroopsOutside
        {
            get { return troopsOutside; }
            set { troopsOutside = value; }
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
            this.attacks = new List<Attack>();
            this.supports = new List<Support>();
            this.sendings = new List<SendResource>();
            this.returnings = new List<SendResource>();
            this.offers = new List<Offer>();
        }

        #endregion

        #region Static Members
        public static Village CreateVillage(ISession session)
        {
            int expand = beans.Properties.Settings.Default.Expand;
            int number = beans.Properties.Settings.Default.Number;

            if (number > (expand * 2 + 1))
            {
                expand++;
                number = 0;
            }
            IList<Village> lst;
            Random r = new Random();
            int X, Y;

            do
            {
                X = 50 + expand * (r.Next(3) - 1);
                Y = 50 + expand * (r.Next(3) - 1);

                ICriteria criteria = session.CreateCriteria(typeof(Village));
                criteria.Add(Expression.Eq("X", X));
                criteria.Add(Expression.Eq("Y", Y));
                lst = criteria.List<Village>();
            } while (lst.Count > 0);

            Village village = new Village();
            village.X = X;
            village.Y = Y;
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
            TimeSpan span = from - to;
            double time = span.TotalHours;
            this.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

        }

        protected IList<MovingCommand> GetDependingCommands(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Lt("LandingTime", to));
            criteria.Add(Expression.Ge("StartTime", this.LastUpdate));
            criteria.AddOrder(new Order("LandingTime", true));
            return criteria.List<MovingCommand>();
        }

        protected IList<Recruit> GetDependingInfantryRecruit(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Le("Start", this.LastUpdate));
            criteria.Add(Expression.Ge("End", to));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Axe), Expression.Or(Expression.Eq("Troop", TroopType.Spear), Expression.Eq("Troop", TroopType.Sword))));
            criteria.AddOrder(new Order("ID", false));
            return criteria.List<Recruit>();
        }

        protected IList<Recruit> GetDependingCavalryRecruit(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Le("Start", this.LastUpdate));
            criteria.Add(Expression.Ge("End", to));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Scout), Expression.Or(Expression.Eq("Troop", TroopType.Light), Expression.Eq("Troop", TroopType.Heavy))));
            criteria.AddOrder(new Order("ID", false));
            return criteria.List<Recruit>();
        }

        //Chưa xét trường hợp xây nhà, xây noble và xe
        public void Update(DateTime to, ISession session)
        {
            IList<MovingCommand> lstMovingCommands = this.GetDependingCommands(to, session);
            IList<Recruit> lstInfantryRecruits = this.GetDependingInfantryRecruit(to, session);
            IList<Recruit> lstCavalryRecruits = this.GetDependingCavalryRecruit(to, session);
            
            foreach (MovingCommand command in lstMovingCommands)
            {
                this.UpdateResources(this.LastUpdate, command.LandingTime);
                if (lstInfantryRecruits.Count > 0)
                    while (lstInfantryRecruits[0].Expense(command.LandingTime))
                    {
                        session.Delete(lstInfantryRecruits[0]);
                        lstInfantryRecruits.RemoveAt(0);
                    }

                if (lstCavalryRecruits.Count > 0)
                    while (lstCavalryRecruits[0].Expense(command.LandingTime))
                    {
                        session.Delete(lstCavalryRecruits[0]);
                        lstCavalryRecruits.RemoveAt(0);
                    }
                
                command.effect(session);
            }
            session.Save(this);
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
            recruit.Start = DateTime.Now;

            recruit.End = recruit.Start.AddSeconds(Recruit.RecruitTime(quantity, level));

            session.Save(recruit);
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

        public IList<MovingCommand> GetIncomingTroop(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));

            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Gt("LandingTime", DateTime.Now));
            criteria.AddOrder(Order.Desc("LandingTime"));

            return criteria.List<MovingCommand>();
        }

        #endregion       
    }
}