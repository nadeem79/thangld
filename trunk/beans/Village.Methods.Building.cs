using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace beans
{
    public partial class Village
    {

        public virtual BuildableStatus PrepareBuild(BuildingType building, ISession session)
        {
            int level = this.GetTotalBuildingLevel(building, session) + 1;
            BuildPrice price = Build.GetPrice(building, level, this.VillageBuildingData.Headquarter);

            BuildableStatus status = this.CanBuild(building, session);

            if (status != BuildableStatus.JustDoIt)
                return status;

            Build build = new Build();
            build.Building = building;
            build.InVillage = this;
            build.Start = DateTime.Now;
            build.End = DateTime.Now.AddSeconds(price.BuildTime);
            build.Level = level;
            this.VillageResourceData.Wood -= price.Wood;
            this.VillageResourceData.Clay -= price.Clay;
            this.VillageResourceData.Iron -= price.Iron;
            this.Points += price.Point;
            this.Population += price.Population;
            session.Save(build);
            session.Update(this);

            return status;
        }
        public virtual int GetTotalBuildingLevel(BuildingType type, ISession session)
        {

            return (from b in session.Linq<Build>()
                    where b.InVillage == this &&
                    b.Building == type
                    select b).Count<Build>() + this[type];
        }
        public virtual int GetTotalBuild(ISession session)
        {
            return (from b in session.Linq<Build>()
                    where b.InVillage == this
                    select b).Count<Build>();
        }
        public virtual BuildableStatus CanBuild(BuildingType type, ISession session)
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

            if (this.VillageResourceData.Wood < price.Wood)
                return BuildableStatus.NotEnoughWood;
            if (this.VillageResourceData.Clay < price.Clay)
                return BuildableStatus.NotEnoughClay;
            if (this.VillageResourceData.Iron < price.Iron)
                return BuildableStatus.NotEnoughIron;

            if (this.GetTotalBuild(session) >= 5)
                return BuildableStatus.BuildNumberExceed;

            return BuildableStatus.JustDoIt;

        }
        public virtual IList<Build> GetPendingConstruction(ISession session)
        {

            return (from b in session.Linq<Build>()
                    where b.InVillage == this
                    orderby b.ID ascending
                    select b).ToList<Build>();
        }
        public virtual void CancelBuild(int id, ISession session)
        {

            IList<Build> lstBuild = (from b in session.Linq<Build>()
                                     where b.ID == id &&
                                     b.InVillage == this
                                     select b).ToList<Build>();



            if (lstBuild.Count == 0)
                return;

            Build build = lstBuild[0];
            BuildPrice price = Build.GetPrice(build.Building, build.Level, this[BuildingType.Headquarter]);

            session.Evict(build.InVillage);
            build.InVillage = this;

            this.VillageResourceData.Wood += (int)(price.Wood * 0 / 8);
            this.VillageResourceData.Clay += (int)(price.Clay * 0 / 8);
            this.VillageResourceData.Iron += (int)(price.Iron * 0 / 8);
            this.Points -= price.Point;
            this.Population -= price.Point;

            session.Delete(build);
            session.Update(build.InVillage);
        }
        public virtual double DefenseBonus()
        {
            double defense = 0;
            if (this[BuildingType.Wall] == 1)
                defense = 0.1;

            for (int i = 1; i < this.VillageBuildingData.Wall; i++)
                defense += (defense * 0.15);

            return defense;
        }

    }
}
