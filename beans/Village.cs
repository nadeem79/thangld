using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Text;
using NHibernate.Criterion;

namespace beans
{
    
    public partial class Village:IdentityObject
    {
        #region Variables

        private int _maxResources = -1;
        private double loyal;
        
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
        public double Loyal
        {
            get { return loyal; }
            set
            {
                if (value > 100)
                    loyal = 100;
                else
                    _oyal = value;
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

        public Village GetVillageByID(int ID, ISession session)
        {
            return session.Load<Village>(ID);
        }

        //public Village GetVillageByCoordinate(int x, int y, ISession session)
        //{
        //    var query = from village in session.Linq<Village>()
        //                where village.
        //}
        
        #endregion

        public override string ToString()
        {
            return this.Name;
        }

        //Chưa xét trường hợp xây noble
        public void Update(DateTime to, ISession session)
        {
            this.Loyal += (int)(to - this.LastUpdate).TotalHours;

            IList<Attack> incomings = this.GetDependingAttack(to, session);
            IList<Recruit> lstInfantryRecruits = this.GetDependingInfantryRecruit(session);
            IList<Recruit> lstCavalryRecruits = this.GetDependingCavalryRecruit(session);
            IList<Recruit> lstCarRecruits = this.GetDependingCarRecruit(session);
            IList<Recruit> lstNobleRecruits = this.GetDependingNobleRecruit(session);
            IList<Build> lstConstructing = this.GetPendingConstruction(session);
            IList<Research> lstReseaching = this.GetPendingResearch(session);

            foreach (Attack incoming in incomings)
            {
                #region Tài nguyên
                this.UpdateResources(this.LastUpdate, incoming.LandingTime);
                if (lstInfantryRecruits.Count > 0)
                    while (lstInfantryRecruits[0].Expense(incoming.LandingTime))
                    {
                        DateTime start = lstInfantryRecruits[0].LastUpdate;
                        session.Delete(lstInfantryRecruits[0]);
                        lstInfantryRecruits.RemoveAt(0);
                        if (lstInfantryRecruits.Count == 0)
                            break;
                        else
                            lstInfantryRecruits[0].LastUpdate = start;
                    }

                #endregion 

                #region Xây quân
                if (lstCavalryRecruits.Count > 0)
                    while (lstCavalryRecruits[0].Expense(incoming.LandingTime))
                    {
                        DateTime start = lstCavalryRecruits[0].LastUpdate;
                        session.Delete(lstCavalryRecruits[0]);
                        lstCavalryRecruits.RemoveAt(0);
                        if (lstCavalryRecruits.Count == 0)
                            break;
                        else
                            lstCavalryRecruits[0].LastUpdate = start;
                    }

                if (lstInfantryRecruits.Count > 0)
                    while (lstInfantryRecruits[0].Expense(incoming.LandingTime))
                    {
                        DateTime start = lstInfantryRecruits[0].LastUpdate;
                        session.Delete(lstInfantryRecruits[0]);
                        lstInfantryRecruits.RemoveAt(0);
                        if (lstInfantryRecruits.Count == 0)
                            break;
                        else
                            lstInfantryRecruits[0].LastUpdate = start;
                    }

                if (lstCarRecruits.Count > 0)
                    while (lstCarRecruits[0].Expense(to))
                    {
                        DateTime start = lstCarRecruits[0].LastUpdate;
                        session.Delete(lstCarRecruits[0]);
                        lstCarRecruits.RemoveAt(0);
                        if (lstCarRecruits.Count == 0)
                            break;
                        else
                            lstCarRecruits[0].LastUpdate = start;
                    }

                if (lstNobleRecruits.Count > 0)
                    while (lstNobleRecruits[0].Expense(to))
                    {
                        DateTime start = lstNobleRecruits[0].LastUpdate;
                        session.Delete(lstNobleRecruits[0]);
                        lstNobleRecruits.RemoveAt(0);
                        if (lstNobleRecruits.Count == 0)
                            break;
                        else
                            lstNobleRecruits[0].LastUpdate = start;
                    }

                #endregion

                #region Xây nhà
                if (lstConstructing.Count > 0)
                    while (lstConstructing[0].Expense(incoming.LandingTime))
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
                #endregion

                #region Nâng cấp
                if (lstReseaching.Count > 0)
                    while (lstReseaching[0].Expense(incoming.LandingTime))
                    {
                        ResearchPrice price = beans.Research.GetPrice(lstReseaching[0].Type, lstReseaching[0].Level, this[BuildingType.Smithy]);
                        DateTime end = lstReseaching[0].Start + new TimeSpan(price.Time);
                        session.Delete(lstReseaching[0]);
                        lstReseaching.RemoveAt(0);
                        if (lstReseaching.Count == 0)
                            break;
                        else
                            lstReseaching[0].Start = end;
                    }
                #endregion

                #region Gửi resource đến làng khác
                IList<SendResource> sendings = this.GetDependingResource(incoming.LandingTime, session);
                foreach (SendResource sending in sendings)
                    sending.To.Update(sending.LandingTime, session);
                #endregion

                #region Quân đi đánh làng khác
                IList<Attack> attacks = this.getDependingAttacking(incoming.LandingTime, session);
                foreach (Attack attack in attacks)
                    attack.To.Update(attack.LandingTime, session);
                #endregion

                #region Gửi tài nguyên đến làng khác
                IList<SendResource> lstSendResources = this.GetOutgoingMerchants(incoming.LandingTime, session);
                foreach (SendResource sendResource in lstSendResources)
                    sendResource.To.Update(incoming.LandingTime, session);
                #endregion

                #region Quân hỗ trợ hoặc quay về từ làng khác
                IList<MovingCommand> friendlyIncomings = this.getFriendlyIncomings(to, session);
                foreach(MovingCommand command in friendlyIncomings)
                    command.effect(session);
                #endregion

                this.LastUpdate = incoming.LandingTime;
                incoming.effect(session);
                
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

            if (lstCarRecruits.Count > 0)
                while (lstCarRecruits[0].Expense(to))
                {
                    DateTime start = lstCarRecruits[0].LastUpdate;
                    session.Delete(lstCarRecruits[0]);
                    lstCarRecruits.RemoveAt(0);
                    if (lstCarRecruits.Count == 0)
                        break;
                    else
                        lstCarRecruits[0].LastUpdate = start;
                }
            if (lstCarRecruits.Count > 0)
                session.Update(lstCarRecruits[0]);

            if (lstNobleRecruits.Count > 0)
                while (lstNobleRecruits[0].Expense(to))
                {
                    DateTime start = lstNobleRecruits[0].LastUpdate;
                    session.Delete(lstNobleRecruits[0]);
                    lstNobleRecruits.RemoveAt(0);
                    if (lstNobleRecruits.Count == 0)
                        break;
                    else
                        lstNobleRecruits[0].LastUpdate = start;
                }
            if (lstNobleRecruits.Count > 0)
                session.Update(lstNobleRecruits[0]);

            if (lstConstructing.Count > 0)
                while (lstConstructing[0].Expense(to))
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

            #region Nâng cấp
            if (lstReseaching.Count > 0)
                while (lstReseaching[0].Expense(to))
                {
                    ResearchPrice price = beans.Research.GetPrice(lstReseaching[0].Type, lstReseaching[0].Level, this[BuildingType.Smithy]);
                    DateTime end = lstReseaching[0].Start + new TimeSpan(price.Time);
                    session.Delete(lstReseaching[0]);
                    lstReseaching.RemoveAt(0);
                    if (lstReseaching.Count == 0)
                        break;
                    else
                        lstReseaching[0].Start = end;
                }
            #endregion

            #region Quân đi đánh làng khác
            IList<Attack> _attacks = this.getDependingAttacking(to, session);
            foreach (Attack attack in _attacks)
                attack.To.Update(to, session);
            #endregion

            #region Gửi tài nguyên đến làng khác
            IList<SendResource> _lstSendResources = this.GetOutgoingMerchants(to, session);
            foreach (SendResource sendResource in _lstSendResources)
                sendResource.To.Update(to, session);
            #endregion

            #region Quân hỗ trợ hoặc quay về từ làng khác
            IList<MovingCommand> _friendlyIncomings = this.getFriendlyIncomings(to, session);
            foreach (MovingCommand command in _friendlyIncomings)
                command.effect(session);
            #endregion

            this.UpdateResources(this.LastUpdate, to);
            this.LastUpdate = to;

            session.Update(this);
            session.Update(this.Owner);
        }
  
    }
}