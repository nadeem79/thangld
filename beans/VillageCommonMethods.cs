using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    public class VillageCommonMethods
    {
        public Village Village
        {
            get;
            set;
        }

        public virtual void UpdateVillage(DateTime to, ISession session)
        {
            this.UpdateVillage(to, session, true);
        }

        public virtual void UpdateVillage(DateTime to, ISession session, bool commit)
        {

            if (to == this.Village.LastUpdate)
                return;

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                IList<MovingCommand> commands = (from movingCommand in session.Linq<MovingCommand>()
                                                 where (movingCommand.FromVillage == this.Village || movingCommand.ToVillage == this.Village)
                                                 && movingCommand.LandingTime < to
                                                 orderby movingCommand.LandingTime ascending
                                                 select movingCommand).ToList<MovingCommand>();

                IList<Build> builds = (from build in session.Linq<Build>()
                                       where build.InVillage == this.Village
                                       orderby build.ID ascending
                                       select build).ToList<Build>();

                IList<Recruit> recruits = (from recruit in session.Linq<Recruit>()
                                           where recruit.InVillage == this.Village
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
                IList<Research> researches = (from research in session.Linq<Research>()
                                              where research.Village == this.Village
                                              orderby research.ID ascending
                                              select research).ToList<Research>();

                DateTime currentTime = this.Village.LastUpdate;

                IList<MovingCommand> toDeleteCommandList = new List<MovingCommand>();
                IList<Research> toDeleteResearchList = new List<Research>();
                IList<Build> toDeleteBuildList = new List<Build>();
                IList<Recruit> toDeleteRecruitList = new List<Recruit>();
                IList<MovingCommand> toInsertCommandList = new List<MovingCommand>();
                bool updateBuildList = false;
                bool updateResearchList = false;


                while (commands.Count > 0)
                {
                    MovingCommand command = commands[0];
                    MovingCommand newCommand = null;
                    if (command.ToVillage == this.Village)
                    {
                        this.Village.UpdateResources(currentTime, command.LandingTime);

                        while (infantryRecruits.Count > 0 && infantryRecruits[0].Expense(command.LandingTime))
                        {
                            toDeleteRecruitList.Add(infantryRecruits[0]);
                            //session.Delete(infantryRecruits[0]);
                            infantryRecruits.RemoveAt(0);
                        }
                        while (cavalryRecruits.Count > 0 && cavalryRecruits[0].Expense(command.LandingTime))
                        {
                            toDeleteRecruitList.Add(cavalryRecruits[0]);
                            //session.Delete(cavalryRecruits[0]);
                            cavalryRecruits.RemoveAt(0);
                        }
                        while (carRecruits.Count > 0 && carRecruits[0].Expense(command.LandingTime))
                        {
                            toDeleteRecruitList.Add(carRecruits[0]);
                            //session.Delete(carRecruits[0]);
                            carRecruits.RemoveAt(0);
                        }

                        while (researches.Count > 0 && researches[0].Expense(command.LandingTime))
                        {
                            this.Village[researches[0].Type]++;
                            toDeleteResearchList.Add(researches[0]);
                            researches.RemoveAt(0);
                        }

                        while (builds.Count > 0 && builds[0].Expense(command.LandingTime))
                        {
                            this.Village[builds[0].Building]++;

                            if (builds[0].Building == BuildingType.Smithy)
                            {
                                for (int i = 1; i < researches.Count; i++)
                                {
                                    Research research = researches[i];
                                    research.Start = researches[i - 1].End;
                                    ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                                    research.End = research.Start.AddSeconds(price.Time);
                                }
                                updateResearchList = true;
                            }
                            else if (builds[0].Building == BuildingType.Headquarter)
                            {
                                for (int i = 1; i < builds.Count; i++)
                                {
                                    Build build = builds[i];
                                    build.Start = builds[i = 1].End;
                                    BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);
                                    build.End = build.Start.AddSeconds(price.BuildTime);
                                }
                                updateBuildList = true;
                            }

                            toDeleteBuildList.Add(builds[0]);
                            builds.RemoveAt(0);
                        }



                        newCommand = command.Effect(session);
                        currentTime = command.LandingTime;
                    }
                    else
                    {
                        command.ToVillage.VillageCommonMethods.UpdateVillage(command.LandingTime, session, false);
                        newCommand = command.Effect(session);
                    }
                    toDeleteCommandList.Add(commands[0]);
                    commands.RemoveAt(0);
                    if (newCommand != null)
                        if (newCommand.LandingTime < to)
                        {
                            for (int i = 1; i < commands.Count; i++)
                                if (commands[i].LandingTime > newCommand.LandingTime)
                                {
                                    commands.Insert(i, newCommand);
                                    break;
                                }
                        }
                        else
                        {
                            toInsertCommandList.Add(newCommand);
                        }
                }

                this.Village.UpdateResources(currentTime, to);

                while (infantryRecruits.Count > 0 && infantryRecruits[0].Expense(to))
                {
                    //session.Delete(infantryRecruits[0]);
                    toDeleteRecruitList.Add(infantryRecruits[0]);
                    infantryRecruits.RemoveAt(0);
                }

                while (cavalryRecruits.Count > 0 && cavalryRecruits[0].Expense(to))
                {
                    //session.Delete(cavalryRecruits[0]);
                    toDeleteRecruitList.Add(cavalryRecruits[0]);
                    cavalryRecruits.RemoveAt(0);
                }

                while (carRecruits.Count > 0 && carRecruits[0].Expense(to))
                {
                    //session.Delete(carRecruits[0]);
                    toDeleteRecruitList.Add(carRecruits[0]);
                    carRecruits.RemoveAt(0);
                }

                while (researches.Count > 0 && researches[0].Expense(to))
                {
                    this.Village[researches[0].Type]++;
                    toDeleteResearchList.Add(researches[0]);
                    researches.RemoveAt(0);
                }

                while (builds.Count > 0 && builds[0].Expense(to))
                {

                    if (builds[0].Building == BuildingType.Smithy)
                    {
                        for (int i = 1; i < researches.Count; i++)
                        {
                            Research research = researches[i];
                            research.Start = researches[i - 1].End;
                            ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                            research.End = research.Start.AddSeconds(price.Time);
                        }
                        updateResearchList = true;
                    }
                    else if (builds[0].Building == BuildingType.Headquarter)
                    {
                        for (int i = 1; i < builds.Count; i++)
                        {
                            Build build = builds[i];
                            build.Start = builds[i = 1].End;
                            BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);
                            build.End = build.Start.AddSeconds(price.BuildTime);
                        }
                        updateBuildList = true;
                    }

                    toDeleteBuildList.Add(builds[0]);
                    builds.RemoveAt(0);
                }

                this.Village.LastUpdate = to;

                    if (carRecruits.Count > 0)
                        session.Update(carRecruits[0]);
                    if (cavalryRecruits.Count > 0)
                        session.Update(cavalryRecruits[0]);
                    if (infantryRecruits.Count > 0)
                        session.Update(infantryRecruits[0]);
                    foreach (Recruit recruit in toDeleteRecruitList)
                        session.Delete(recruit);
                    foreach (Build build in toDeleteBuildList)
                        session.Delete(build);
                    foreach (Research research in toDeleteResearchList)
                        session.Delete(research);
                    foreach (MovingCommand command in toDeleteCommandList)
                        session.Delete(command);
                    foreach (MovingCommand command in toInsertCommandList)
                        session.Save(command);

                    if (toDeleteBuildList.Count > 0)
                        session.Update(this.Village.VillageBuildingData);
                    if (toDeleteResearchList.Count > 0)
                        session.Update(this.Village.VillageResearchData);
                    if (toDeleteRecruitList.Count > 0 || recruits.Count > 0)
                        session.Update(this.Village.VillageTroopData);

                    if (updateBuildList)
                        foreach (Build build in builds)
                            session.Update(build);
                    if (updateResearchList)
                        foreach (Research research in researches)
                            session.Update(research);
                if (commit)
                    trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null && commit)
                    trans.Rollback();
            }
        }
       
    }
}
