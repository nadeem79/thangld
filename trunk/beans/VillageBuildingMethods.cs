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

        private int topHeadquarterLevel = -1, topBarrackLevel = -1, topStableLevel = -1, topWorkshopLevel = -1, topAcademyLevel = -1, topSmithyLevel = -1, topRallyPointLevel = -1;
        private int topMarketLevel = -1, topTimberCampLevel = -1, topClayPitLevel = -1, topIronMineLevel = -1, topFarmLevel = -1, topWarehouseLevel = -1, topHiddenPlaceLevel = -1, topWallLevel = -1;
        public int TopHeadquarterLevel
        {
            get
            {
                if (topHeadquarterLevel >= 0)
                    return topHeadquarterLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Headquarter
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topHeadquarterLevel = this.Village.VillageBuildingData.Headquarter;
                else
                    this.topHeadquarterLevel = maxBuildLevel.Level;
                return topHeadquarterLevel;
            }
        }
        public int TopBarrackLevel
        {
            get
            {
                if (topBarrackLevel >= 0)
                    return topBarrackLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Barracks
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topBarrackLevel = this.Village.VillageBuildingData.Barracks;
                else
                    this.topBarrackLevel = maxBuildLevel.Level;
                return topBarrackLevel;
            }
        }
        public int TopStableLevel
        {
            get
            {
                if (topStableLevel >= 0)
                    return topStableLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Stable
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topStableLevel = this.Village.VillageBuildingData.Stable;
                else
                    this.topStableLevel = maxBuildLevel.Level;
                return topStableLevel;
            }
        }
        public int TopWorkshopLevel
        {
            get
            {
                if (topWorkshopLevel >= 0)
                    return topWorkshopLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Workshop
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topWorkshopLevel = this.Village.VillageBuildingData.Workshop;
                else
                    this.topWorkshopLevel = maxBuildLevel.Level;
                return topWorkshopLevel;
            }
        }
        public int TopAcademyLevel
        {
            get
            {
                if (topAcademyLevel >= 0)
                    return topAcademyLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Academy
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topAcademyLevel = this.Village.VillageBuildingData.Academy;
                else
                    this.topAcademyLevel = maxBuildLevel.Level;
                return topAcademyLevel;
            }
        }
        public int TopSmithyLevel
        {
            get
            {
                if (topSmithyLevel >= 0)
                    return topSmithyLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Smithy
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topSmithyLevel = this.Village.VillageBuildingData.Smithy;
                else
                    this.topSmithyLevel = maxBuildLevel.Level;
                return topSmithyLevel;
            }
        }
        public int TopRallyPointLevel
        {
            get
            {
                if (topRallyPointLevel >= 0)
                    return topRallyPointLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Rally
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topRallyPointLevel = this.Village.VillageBuildingData.Rally;
                else
                    this.topRallyPointLevel = maxBuildLevel.Level;
                return topRallyPointLevel;
            }
        }
        public int TopMarketLevel
        {
            get
            {
                if (topMarketLevel >= 0)
                    return topMarketLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Market
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topMarketLevel = this.Village.VillageBuildingData.Market;
                else
                    this.topMarketLevel = maxBuildLevel.Level;
                return topMarketLevel;
            }
        }
        public int TopTimberCampLevel
        {
            get
            {
                if (topTimberCampLevel >= 0)
                    return topTimberCampLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.TimberCamp
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topTimberCampLevel = this.Village.VillageBuildingData.TimberCamp;
                else
                    this.topTimberCampLevel = maxBuildLevel.Level;
                return topTimberCampLevel;
            }
        }
        public int TopClayPitLevel
        {
            get
            {
                if (topClayPitLevel >= 0)
                    return topClayPitLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.ClayPit
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topClayPitLevel = this.Village.VillageBuildingData.ClayPit;
                else
                    this.topClayPitLevel = maxBuildLevel.Level;
                return topClayPitLevel;
            }
        }
        public int TopIronMineLevel
        {
            get
            {
                if (topIronMineLevel >= 0)
                    return topIronMineLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.IronMine
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topIronMineLevel = this.Village.VillageBuildingData.IronMine;
                else
                    this.topIronMineLevel = maxBuildLevel.Level;
                return topIronMineLevel;
            }
        }
        public int TopFarmLevel
        {
            get
            {
                if (topFarmLevel >= 0)
                    return topFarmLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Farm
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topFarmLevel = this.Village.VillageBuildingData.Farm;
                else
                    this.topFarmLevel = maxBuildLevel.Level;
                return topFarmLevel;
            }
        }
        public int TopWarehouseLevel
        {
            get
            {
                if (topWarehouseLevel >= 0)
                    return topWarehouseLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Warehouse
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topWarehouseLevel = this.Village.VillageBuildingData.Warehouse;
                else
                    this.topWarehouseLevel = maxBuildLevel.Level;
                return topWarehouseLevel;
            }
        }
        public int TopHiddenPlaceLevel
        {
            get
            {
                if (topHiddenPlaceLevel >= 0)
                    return topHiddenPlaceLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.HidingPlace
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topHiddenPlaceLevel = this.Village.VillageBuildingData.HidingPlace;
                else
                    this.topHiddenPlaceLevel = maxBuildLevel.Level;
                return topHiddenPlaceLevel;
            }
        }
        public int TopWallLevel
        {
            get
            {
                if (topWallLevel >= 0)
                    return topWallLevel;

                Build maxBuildLevel = (from b in this.Village.Builds
                                       where b.Building == BuildingType.Wall
                                       orderby b.ID descending
                                       select b).FirstOrDefault<Build>();
                if (maxBuildLevel == null)
                    this.topWallLevel = this.Village.VillageBuildingData.Wall;
                else
                    this.topWallLevel = maxBuildLevel.Level;
                return topWallLevel;
            }
        }

        public Village Village
        {
            get;
            set;
        }
        public virtual BuildableStatus CanBuild(BuildingType type, ISession session)
        {
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

            if (this.Village.Builds.Count >= 5)
                return BuildableStatus.BuildNumberExceed;

            return BuildableStatus.JustDoIt;

        }
        public virtual BuildableStatus PrepareBuild(BuildingType building, ISession session)
        {

            int level = 0;
            switch (building)
            {
                case BuildingType.Headquarter:
                    level = this.TopHeadquarterLevel + 1;
                    this.topHeadquarterLevel++;
                    break;
                case BuildingType.Barracks:
                    level = this.TopBarrackLevel + 1;
                    this.topBarrackLevel++;
                    break;
                case BuildingType.Stable:
                    level = this.TopStableLevel + 1;
                    this.topStableLevel++;
                    break;
                case BuildingType.Workshop:
                    level = this.TopWorkshopLevel + 1;
                    this.topWorkshopLevel++;
                    break;
                case BuildingType.Academy:
                    level = this.TopAcademyLevel + 1;
                    this.topAcademyLevel++;
                    break;
                case BuildingType.Smithy:
                    level = this.TopSmithyLevel + 1;
                    this.topSmithyLevel++;
                    break;
                case BuildingType.Rally:
                    level = this.TopRallyPointLevel + 1;
                    this.topRallyPointLevel++;
                    break;
                case BuildingType.Market:
                    level = this.TopMarketLevel + 1;
                    this.topMarketLevel++;
                    break;
                case BuildingType.TimberCamp:
                    level = this.TopTimberCampLevel + 1;
                    this.topTimberCampLevel++;
                    break;
                case BuildingType.ClayPit:
                    level = this.TopClayPitLevel + 1;
                    this.topClayPitLevel++;
                    break;
                case BuildingType.IronMine:
                    level = this.TopIronMineLevel + 1;
                    this.topIronMineLevel++;
                    break;
                case BuildingType.Farm:
                    level = this.TopFarmLevel + 1;
                    this.topFarmLevel++;
                    break;
                case BuildingType.Warehouse:
                    level = this.TopWarehouseLevel + 1;
                    this.topWorkshopLevel++;
                    break;
                case BuildingType.HidingPlace:
                    level = this.TopHiddenPlaceLevel + 1;
                    this.topHiddenPlaceLevel++;
                    break;
                case BuildingType.Wall:
                    level = this.TopWallLevel + 1;
                    this.topWallLevel++;
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
            build.Level = level;

            var lastBuild = (from b in this.Village.Builds
                             orderby b.ID descending
                             select b).FirstOrDefault<Build>();

            if (lastBuild == null)
                build.Start = DateTime.Now;
            else
                build.Start = lastBuild.End;
            build.End = build.Start.AddMilliseconds(price.BuildTime);

            this.Village.VillageResourceData.Wood -= price.Wood;
            this.Village.VillageResourceData.Clay -= price.Clay;
            this.Village.VillageResourceData.Iron -= price.Iron;
            this.Village.Population += price.Population;
            this.Village.Builds.Add(build);
            session.Save(build);
            session.Update(this.Village);

            return status;
        }

        public virtual void CancelBuild(int id, ISession session)
        {

            Build build = (from b in this.Village.Builds
                           where b.ID == id
                           select b).SingleOrDefault<Build>();

            if (build == null)
                return;

            this.Village.Builds.Remove(build);
            session.Delete(build);

            BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);

            this.Village.VillageResourceData.Wood += (int)(price.Wood * 0.8);
            this.Village.VillageResourceData.Clay += (int)(price.Clay * 0.8);
            this.Village.VillageResourceData.Iron += (int)(price.Iron * 0.8);
            this.Village.Population -= price.Population;

            for (int i = 0; i < this.Village.Builds.Count; i++)
            {
                Build b = this.Village.Builds[i];
                if (i == 0)
                    b.Start = DateTime.Now;
                else
                    b.Start = this.Village.Builds[i - 1].End;

                if (b.Building == build.Building && b.ID > build.ID)
                    b.Level--;

                BuildPrice p = Build.GetPrice(b.Building, b.Level, this.Village[BuildingType.Headquarter]);
                b.End = b.Start.AddMilliseconds(p.BuildTime);
                session.Update(b);
            }

            switch (build.Building)
            {
                case BuildingType.Headquarter:
                    this.topHeadquarterLevel--;
                    break;
                case BuildingType.Barracks:
                    this.topBarrackLevel--;
                    break;
                case BuildingType.Stable:
                    this.topStableLevel--;
                    break;
                case BuildingType.Workshop:
                    this.topWorkshopLevel--;
                    break;
                case BuildingType.Academy:
                    this.topAcademyLevel--;
                    break;
                case BuildingType.Smithy:
                    this.topSmithyLevel--;
                    break;
                case BuildingType.Rally:
                    this.topRallyPointLevel--;
                    break;
                case BuildingType.Market:
                    this.topMarketLevel--;
                    break;
                case BuildingType.TimberCamp:
                    this.topTimberCampLevel--;
                    break;
                case BuildingType.ClayPit:
                    this.topClayPitLevel--;
                    break;
                case BuildingType.IronMine:
                    this.topIronMineLevel--;
                    break;
                case BuildingType.Farm:
                    this.topFarmLevel--;
                    break;
                case BuildingType.Warehouse:
                    this.topWorkshopLevel--;
                    break;
                case BuildingType.HidingPlace:
                    this.topHiddenPlaceLevel--;
                    break;
                case BuildingType.Wall:
                    this.topWallLevel--;
                    break;
                default:
                    break;
            }
            
            session.Update(this.Village);
        }
    }
}
