﻿using System;
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
            SortedList<DateTime, MovingCommand> commands = new SortedList<DateTime, MovingCommand>();
            foreach (MovingCommand movingCommand in this.Village.MovingCommandsFromMe)
                commands.Add(movingCommand.LandingTime, movingCommand);
            foreach (MovingCommand movingCommand in this.Village.MovingCommandsToMe)
                commands.Add(movingCommand.LandingTime, movingCommand);

            DateTime currentTime = this.Village.LastUpdate;
            bool updateResearchList = false, updateBuildList = false;
            while (commands.Count > 0 && commands.ElementAt(0).Value.LandingTime <= to)
            {
                MovingCommand command = commands.ElementAt(0).Value;
                MovingCommand newCommand = null;
                if (command.ToVillage == this.Village)
                {
                    this.Village.VillageResourceMethods.UpdateResources(currentTime, command.LandingTime);

                    while (this.Village.VillageRecruitMethods.InfantryRecruits.Count > 0 && this.Village.VillageRecruitMethods.InfantryRecruits[0].Expense(command.LandingTime))
                    {
                        this.Village.VillageRecruitMethods.InfantryRecruits.RemoveAt(0);
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.InfantryRecruits[0]);
                        session.Delete(this.Village.VillageRecruitMethods.InfantryRecruits[0]);
                    }
                    while (this.Village.VillageRecruitMethods.CavalryRecruits.Count > 0 && this.Village.VillageRecruitMethods.CavalryRecruits[0].Expense(command.LandingTime))
                    {
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
                        this.Village.VillageRecruitMethods.CavalryRecruits.RemoveAt(0);
                        session.Delete(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
                    }
                    while (this.Village.VillageRecruitMethods.CarRecruits.Count > 0 && this.Village.VillageRecruitMethods.CarRecruits[0].Expense(command.LandingTime))
                    {
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CarRecruits[0]);
                        this.Village.VillageRecruitMethods.CarRecruits.RemoveAt(0);
                        session.Delete(this.Village.VillageRecruitMethods.CarRecruits[0]);
                    }

                    while (this.Village.Researches.Count > 0 && this.Village.Researches[0].Expense(command.LandingTime))
                    {
                        this.Village[this.Village.Researches[0].Type]++;
                        session.Delete(this.Village.Researches[0]);
                        this.Village.Researches.RemoveAt(0);
                    }

                    while (this.Village.Builds.Count > 0 && this.Village.Builds[0].Expense(command.LandingTime))
                    {
                        this.Village[this.Village.Builds[0].Building]++;

                        if (this.Village.Builds[0].Building == BuildingType.Smithy)
                        {
                            for (int i = 1; i < this.Village.Researches.Count; i++)
                            {
                                Research research = this.Village.Researches[i];
                                research.Start = this.Village.Researches[i - 1].End;
                                ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                                research.End = research.Start.AddSeconds(price.Time);
                            }
                            updateResearchList = true;
                        }
                        else if (this.Village.Builds[0].Building == BuildingType.Headquarter)
                        {
                            for (int i = 1; i < this.Village.Builds.Count; i++)
                            {
                                Build build = this.Village.Builds[i];
                                build.Start = this.Village.Builds[i = 1].End;
                                BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);
                                build.End = build.Start.AddSeconds(price.BuildTime);
                            }
                            updateBuildList = true;
                        }

                        session.Delete(this.Village.Builds[0]);
                        this.Village.Builds.RemoveAt(0);
                    }

                    newCommand = command.Effect(session);
                    currentTime = command.LandingTime;
                    commands.RemoveAt(0);
                    this.Village.MovingCommandsToMe.Remove(command);
                    session.Delete(command);
                }
                else
                {
                    command.ToVillage.VillageCommonMethods.UpdateVillage(command.LandingTime, session, false);
                    newCommand = command.Effect(session);
                    commands.RemoveAt(0);
                    this.Village.MovingCommandsFromMe.Remove(command);
                    session.Delete(command);
                }


                if (newCommand != null)
                    if (newCommand.LandingTime < to)
                        commands.Add(newCommand.LandingTime, newCommand);
                    else
                    {
                        if (newCommand.FromVillage == this.Village)
                            this.Village.MovingCommandsFromMe.Add(newCommand);
                        else
                            this.Village.MovingCommandsToMe.Add(newCommand);
                        session.Save(newCommand);
                    }
            }

            this.Village.VillageResourceMethods.UpdateResources(currentTime, to);

            while (this.Village.VillageRecruitMethods.InfantryRecruits.Count > 0 && this.Village.VillageRecruitMethods.InfantryRecruits[0].Expense(to))
            {
                this.Village.VillageRecruitMethods.InfantryRecruits.RemoveAt(0);
                this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.InfantryRecruits[0]);
                session.Delete(this.Village.VillageRecruitMethods.InfantryRecruits[0]);
            }
            while (this.Village.VillageRecruitMethods.CavalryRecruits.Count > 0 && this.Village.VillageRecruitMethods.CavalryRecruits[0].Expense(to))
            {
                this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
                this.Village.VillageRecruitMethods.CavalryRecruits.RemoveAt(0);
                session.Delete(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
            }
            while (this.Village.VillageRecruitMethods.CarRecruits.Count > 0 && this.Village.VillageRecruitMethods.CarRecruits[0].Expense(to))
            {
                this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CarRecruits[0]);
                this.Village.VillageRecruitMethods.CarRecruits.RemoveAt(0);
                session.Delete(this.Village.VillageRecruitMethods.CarRecruits[0]);
            }

            while (this.Village.Researches.Count > 0 && this.Village.Researches[0].Expense(to))
            {
                this.Village[this.Village.Researches[0].Type]++;
                session.Delete(this.Village.Researches[0]);
                this.Village.Researches.RemoveAt(0);
            }

            while (this.Village.Builds.Count > 0 && this.Village.Builds[0].Expense(to))
            {
                this.Village[this.Village.Builds[0].Building]++;

                if (this.Village.Builds[0].Building == BuildingType.Smithy)
                {
                    for (int i = 1; i < this.Village.Researches.Count; i++)
                    {
                        Research research = this.Village.Researches[i];
                        research.Start = this.Village.Researches[i - 1].End;
                        ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                        research.End = research.Start.AddSeconds(price.Time);
                    }
                    updateResearchList = true;
                }
                else if (this.Village.Builds[0].Building == BuildingType.Headquarter)
                {
                    for (int i = 1; i < this.Village.Builds.Count; i++)
                    {
                        Build build = this.Village.Builds[i];
                        build.Start = this.Village.Builds[i = 1].End;
                        BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);
                        build.End = build.Start.AddSeconds(price.BuildTime);
                    }
                    updateBuildList = true;
                }
                this.Village.Builds.RemoveAt(0);
                session.Delete(this.Village.Builds[0]);
                
            }

            this.Village.LastUpdate = to;

            //if (this.Village.VillageRecruitMethods.CarRecruits.Count > 0)
            //    session.Update(this.Village.VillageRecruitMethods.CarRecruits[0]);
            //if (this.Village.VillageRecruitMethods.CavalryRecruits.Count > 0)
            //    session.Update(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
            //if (this.Village.VillageRecruitMethods.InfantryRecruits.Count > 0)
            //    session.Update(this.Village.VillageRecruitMethods.InfantryRecruits[0]);



            //if (updateBuildList)
            //    foreach (Build build in this.Village.Builds)
            //        session.Update(build);
            //if (updateResearchList)
            //    foreach (Research research in this.Village.Researches)
            //        session.Update(research);

            session.Update(this.Village);

        }
       
    }
}