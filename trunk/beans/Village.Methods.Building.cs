using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {
        #region Methods.Building

        public BuildableStatus PrepareBuild(BuildingType building, ISession session)
        {
            int level = this.GetTotalBuildingLevel(building, session) + 1;
            BuildPrice price = Build.GetPrice(building, level, this.Buildings.Headquarter);

            BuildableStatus status = this.CanBuild(building, session);

            if (status != BuildableStatus.JustDoIt)
                return status;

            Build build = new Build();
            build.Building = building;
            build.InVillage = this;
            build.Start = DateTime.Now;
            build.End = DateTime.Now.AddSeconds(price.BuildTime);
            build.Level = level;
            this.Resources.Wood -= price.Wood;
            this.Resources.Clay -= price.Clay;
            this.Resources.Iron -= price.Iron;
            this.Points += price.Point;
            this.Population += price.Population;
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
            BuildPrice price = Build.GetPrice(build.Building, build.Level, this[BuildingType.Headquarter]);

            session.Evict(build.InVillage);
            build.InVillage = this;

            this.Resources.Wood += (int)(price.Wood * 0 / 8);
            this.Resources.Clay += (int)(price.Clay * 0 / 8);
            this.Resources.Iron += (int)(price.Iron * 0 / 8);
            this.Points -= price.Point;
            this.Population -= price.Point;

            session.Delete(build);
            session.Update(build.InVillage);
        }
        public double DefenseBonus()
        {
            double defense = 0;
            if (this[BuildingType.Wall] == 1)
                defense = 0.1;

            for (int i = 1; i < this.Buildings.Wall; i++)
                defense += (defense * 0.15);

            return defense;
        }

        #endregion
    }
}
