using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    public class VillageBuildingMethods
    {
        public IList<Build> Builds
        {
            get;
            set;
        }
        public int TopHeadquarterLevel
        {
            get;
            set;
        }
        public int TopBarrackLevel
        {
            get;
            set;
        }
        public int TopStableLevel
        {
            get;
            set;
        }
        public int TopWorkshopLevel
        {
            get;
            set;
        }
        public int TopAcademyLevel
        {
            get;
            set;
        }
        public int TopSmithyLevel
        {
            get;
            set;
        }
        public int TopRallyPointLevel
        {
            get;
            set;
        }
        public int TopMarketLevel
        {
            get;
            set;
        }
        public int TopTimberCampLevel
        {
            get;
            set;
        }
        public int TopClayPitLevel
        {
            get;
            set;
        }
        public int TopIronMineLevel
        {
            get;
            set;
        }
        public int TopFarmLevel
        {
            get;
            set;
        }
        public int TopWarehouseLevel
        {
            get;
            set;
        }
        public int TopHiddenPlaceLevel
        {
            get;
            set;
        }
        public int TopWallLevel
        {
            get;
            set;
        }

        public Village Village
        {
            get;
            set;
        }

        public virtual IList<Build> GetPendingConstruction(ISession session)
        {
            IList<Build> builds = (from b in session.Linq<Build>()
                                   where b.InVillage == this.Village
                                   orderby b.ID ascending
                                   select b).ToList<Build>();

            this.TopHeadquarterLevel = (from b in builds
                                        where b.Building == BuildingType.Headquarter
                                        orderby b.ID descending
                                        select b.Level).FirstOrDefault<int>();
            this.TopBarrackLevel = (from b in builds
                                    where b.Building == BuildingType.Barracks
                                    orderby b.ID descending
                                    select b.Level).FirstOrDefault<int>();
            this.TopStableLevel = (from b in builds
                                   where b.Building == BuildingType.Stable
                                   orderby b.ID descending
                                   select b.Level).FirstOrDefault<int>();
            this.TopWorkshopLevel = (from b in builds
                                     where b.Building == BuildingType.Workshop
                                     orderby b.ID descending
                                     select b.Level).FirstOrDefault<int>();
            this.TopAcademyLevel = (from b in builds
                                    where b.Building == BuildingType.Academy
                                    orderby b.ID descending
                                    select b.Level).FirstOrDefault<int>();
            this.TopSmithyLevel = (from b in builds
                                   where b.Building == BuildingType.Smithy
                                   orderby b.ID descending
                                   select b.Level).FirstOrDefault<int>();
            this.TopRallyPointLevel = (from b in builds
                                       where b.Building == BuildingType.Rally
                                       orderby b.ID descending
                                       select b.Level).FirstOrDefault<int>();
            this.TopMarketLevel = (from b in builds
                                   where b.Building == BuildingType.Market
                                   orderby b.ID descending
                                   select b.Level).FirstOrDefault<int>();
            this.TopTimberCampLevel = (from b in builds
                                       where b.Building == BuildingType.TimberCamp
                                       orderby b.ID descending
                                       select b.Level).FirstOrDefault<int>();
            this.TopClayPitLevel = (from b in builds
                                    where b.Building == BuildingType.ClayPit
                                    orderby b.ID descending
                                    select b.Level).FirstOrDefault<int>();
            this.TopIronMineLevel = (from b in builds
                                     where b.Building == BuildingType.IronMine
                                     orderby b.ID descending
                                     select b.Level).FirstOrDefault<int>();

            this.TopWarehouseLevel = (from b in builds
                                      where b.Building == BuildingType.Warehouse
                                      orderby b.ID descending
                                      select b.Level).FirstOrDefault<int>();
            this.TopFarmLevel = (from b in builds
                                 where b.Building == BuildingType.Farm
                                 orderby b.ID descending
                                 select b.Level).FirstOrDefault<int>();
            this.TopHiddenPlaceLevel = (from b in builds
                                        where b.Building == BuildingType.HidingPlace
                                        orderby b.ID descending
                                        select b.Level).FirstOrDefault<int>();
            this.TopWallLevel = (from b in builds
                                 where b.Building == BuildingType.Wall
                                 orderby b.ID descending
                                 select b.Level).FirstOrDefault<int>();
            this.Builds = builds;
            return builds;
        }
        public virtual BuildableStatus CanBuild(BuildingType type, ISession session)
        {
            if (this.Builds == null)
                this.GetPendingConstruction(session);
            if (this.Village[type] == 0)
            {
                switch (type)
                {
                    case BuildingType.Headquarter:
                        if (this.Village[BuildingType.Headquarter] == 0)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Barracks:
                        if (this.Village[BuildingType.Headquarter] < 3)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Stable:
                        if (this.Village[BuildingType.Headquarter] < 10 && this.Village[BuildingType.Smithy] < 5 && this.Village[BuildingType.Barracks] < 5)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Workshop:
                        if (this.Village[BuildingType.Headquarter] < 10 && this.Village[BuildingType.Smithy] < 10)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Academy:
                        if (this.Village[BuildingType.Headquarter] < 20 && this.Village[BuildingType.Smithy] < 20 && this.Village[BuildingType.Market] < 10)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Smithy:
                        if (this.Village[BuildingType.Headquarter] < 5 && this.Village[BuildingType.Barracks] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Rally:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Market:
                        if (this.Village[BuildingType.Headquarter] < 2 && this.Village[BuildingType.Warehouse] < 2)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.TimberCamp:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.ClayPit:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.IronMine:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Farm:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Warehouse:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.HidingPlace:
                        if (this.Village[BuildingType.Headquarter] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    case BuildingType.Wall:
                        if (this.Village[BuildingType.Headquarter] < 1 && this.Village[BuildingType.Barracks] < 1)
                            return BuildableStatus.RequirementNotMet;
                        break;
                    default:
                        break;
                }
            }


            int level = 0;
            switch (type)
            {
                case BuildingType.Headquarter:
                    level = this.TopHeadquarterLevel + 1;
                    break;
                case BuildingType.Barracks:
                    level = this.TopBarrackLevel + 1;
                    break;
                case BuildingType.Stable:
                    level = this.TopStableLevel + 1;
                    break;
                case BuildingType.Workshop:
                    level = this.TopWorkshopLevel + 1;
                    break;
                case BuildingType.Academy:
                    level = this.TopAcademyLevel + 1;
                    break;
                case BuildingType.Smithy:
                    level = this.TopSmithyLevel + 1;
                    break;
                case BuildingType.Rally:
                    level = this.TopRallyPointLevel + 1;
                    break;
                case BuildingType.Market:
                    level = this.TopMarketLevel + 1;
                    break;
                case BuildingType.TimberCamp:
                    level = this.TopTimberCampLevel + 1;
                    break;
                case BuildingType.ClayPit:
                    level = this.TopClayPitLevel + 1;
                    break;
                case BuildingType.IronMine:
                    level = this.TopIronMineLevel + 1;
                    break;
                case BuildingType.Farm:
                    level = this.TopFarmLevel + 1;
                    break;
                case BuildingType.Warehouse:
                    level = this.TopWarehouseLevel + 1;
                    break;
                case BuildingType.HidingPlace:
                    level = this.TopHiddenPlaceLevel + 1;
                    break;
                case BuildingType.Wall:
                    level = this.TopWallLevel + 1;
                    break;
                default:
                    break;
            }

            BuildPrice price = Build.GetPrice(type, level + 1, this.Village[BuildingType.Headquarter]);
            if (level >= price.MaxLevel)
                return BuildableStatus.BuildingLevelExceed;

            if ((this.Village.MaxPopulation - this.Village.Population) < price.Population)
                return BuildableStatus.NotEnoughFarm;

            if (this.Village.VillageResourceData.Wood < price.Wood)
                return BuildableStatus.NotEnoughWood;
            if (this.Village.VillageResourceData.Clay < price.Clay)
                return BuildableStatus.NotEnoughClay;
            if (this.Village.VillageResourceData.Iron < price.Iron)
                return BuildableStatus.NotEnoughIron;

            if (this.Builds.Count >= 5)
                return BuildableStatus.BuildNumberExceed;

            return BuildableStatus.JustDoIt;

        }
        public virtual BuildableStatus PrepareBuild(BuildingType building, ISession session)
        {
            if (this.Builds == null)
                this.GetPendingConstruction(session);
            int level = 0;
            switch (building)
            {
                case BuildingType.Headquarter:
                    level = this.TopHeadquarterLevel + 1;
                    break;
                case BuildingType.Barracks:
                    level = this.TopBarrackLevel + 1;
                    break;
                case BuildingType.Stable:
                    level = this.TopStableLevel + 1;
                    break;
                case BuildingType.Workshop:
                    level = this.TopWorkshopLevel + 1;
                    break;
                case BuildingType.Academy:
                    level = this.TopAcademyLevel + 1;
                    break;
                case BuildingType.Smithy:
                    level = this.TopSmithyLevel + 1;
                    break;
                case BuildingType.Rally:
                    level = this.TopRallyPointLevel + 1;
                    break;
                case BuildingType.Market:
                    level = this.TopMarketLevel + 1;
                    break;
                case BuildingType.TimberCamp:
                    level = this.TopTimberCampLevel + 1;
                    break;
                case BuildingType.ClayPit:
                    level = this.TopClayPitLevel + 1;
                    break;
                case BuildingType.IronMine:
                    level = this.TopIronMineLevel + 1;
                    break;
                case BuildingType.Farm:
                    level = this.TopFarmLevel + 1;
                    break;
                case BuildingType.Warehouse:
                    level = this.TopWarehouseLevel + 1;
                    break;
                case BuildingType.HidingPlace:
                    level = this.TopHiddenPlaceLevel + 1;
                    break;
                case BuildingType.Wall:
                    level = this.TopWallLevel + 1;
                    break;
                default:
                    break;
            }

            BuildPrice price = Build.GetPrice(building, level, this.Village.VillageBuildingData.Headquarter);

            BuildableStatus status = this.CanBuild(building, session);

            if (status != BuildableStatus.JustDoIt)
                return status;

            Build build = new Build();
            build.Building = building;
            build.InVillage = this.Village;
            build.Start = DateTime.Now;
            build.End = DateTime.Now.AddSeconds(price.BuildTime);
            build.Level = level;
            this.Village.VillageResourceData.Wood -= price.Wood;
            this.Village.VillageResourceData.Clay -= price.Clay;
            this.Village.VillageResourceData.Iron -= price.Iron;
            this.Village.Population += price.Population;

            ITransaction trans = null;

            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.Save(build);
                session.Update(this.Village);
                trans.Commit();
            }
            catch (Exception exc)
            {
                if (trans != null)
                    trans.Rollback();
            }

            return status;
        }

        public virtual void CancelBuild(int id, ISession session)
        {
            if (this.Builds != null)
                this.GetPendingConstruction(session);

            Build build = (from b in this.Builds
                           where b.ID == id &&
                           b.InVillage == this.Village
                           select b).SingleOrDefault<Build>();

            if (build == null)
                return;

            BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);

            this.Village.VillageResourceData.Wood += (int)(price.Wood * 0.8);
            this.Village.VillageResourceData.Clay += (int)(price.Clay * 0.8);
            this.Village.VillageResourceData.Iron += (int)(price.Iron * 0.8);
            this.Village.Population -= price.Population;

            //IList<Build> builds = (from th)



            ITransaction trans = null;

            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.Delete(build);
                session.Update(this.Village);
                session.Update(this.Village.VillageResourceData);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }
        }
    }
}
