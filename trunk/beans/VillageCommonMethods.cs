using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

using System.Data;

namespace beans
{
    public class VillageCommonMethods
    {

        //public static int Count = 0;
        //public static List<string> UpdatedVillage = new List<string>();

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
            //UpdatedVillage.Add(this.Village.Name);
            if (to == this.Village.LastUpdate)
                return;

            SortedList<DateTime, MovingCommand> commands = new SortedList<DateTime, MovingCommand>();
            foreach (MovingCommand movingCommand in this.Village.MovingCommandsFromMe)
                commands.Add(movingCommand.LandingTime, movingCommand);
            foreach (MovingCommand movingCommand in this.Village.MovingCommandsToMe)
                commands.Add(movingCommand.LandingTime, movingCommand);
            DateTime currentTime = this.Village.LastUpdate;
            while (commands.Count > 0 && commands.ElementAt(0).Value.LandingTime < to)
            {
                
                MovingCommand command = commands.ElementAt(0).Value;
                this.Village.LastUpdate = command.LandingTime;
                MovingCommand newCommand = null;
                if (command.ToVillage == this.Village)
                {
                    this.Village.VillageResourceMethods.UpdateResources(currentTime, command.LandingTime);

                    while (this.Village.VillageRecruitMethods.InfantryRecruits.Count > 0 && this.Village.VillageRecruitMethods.InfantryRecruits[0].Expense(command.LandingTime))
                    {
                        Recruit r = this.Village.VillageRecruitMethods.InfantryRecruits[0];
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.InfantryRecruits[0]);
                        this.Village.VillageRecruitMethods.InfantryRecruits.RemoveAt(0);
                        session.Delete(r);
                    }
                    while (this.Village.VillageRecruitMethods.CavalryRecruits.Count > 0 && this.Village.VillageRecruitMethods.CavalryRecruits[0].Expense(command.LandingTime))
                    {
                        Recruit r = this.Village.VillageRecruitMethods.CavalryRecruits[0];
                        session.Delete(r);
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CavalryRecruits[0]);
                        this.Village.VillageRecruitMethods.CavalryRecruits.RemoveAt(0);
                        
                    }
                    while (this.Village.VillageRecruitMethods.CarRecruits.Count > 0 && this.Village.VillageRecruitMethods.CarRecruits[0].Expense(command.LandingTime))
                    {
                        this.Village.Recruits.Remove(this.Village.VillageRecruitMethods.CarRecruits[0]);
                        session.Delete(this.Village.VillageRecruitMethods.CarRecruits[0]);
                        this.Village.VillageRecruitMethods.CarRecruits.RemoveAt(0);
                        
                    }

                    while (this.Village.Researches.Count > 0 && this.Village.Researches[0].Expense(command.LandingTime))
                    {
                        this.Village[this.Village.Researches[0].Type]++;
                        session.Delete(this.Village.Researches[0]);
                        this.Village.Researches.RemoveAt(0);
                    }

                    while (this.Village.Builds.Count > 0 && this.Village.Builds[0].Expense(command.LandingTime))
                    {

                        if (this.Village.Builds[0].Building == BuildingType.Smithy)
                        {
                            for (int i = 1; i < this.Village.Researches.Count; i++)
                            {
                                Research research = this.Village.Researches[i];
                                research.Start = this.Village.Researches[i - 1].End;
                                ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                                research.End = research.Start.AddSeconds(price.Time);
                            }
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
                        }
                        session.Delete(this.Village.Builds[0]);
                        this.Village.Builds.RemoveAt(0);
                    }
                    newCommand = command.Effect(session);
                    currentTime = command.LandingTime;
                    commands.RemoveAt(0);
                }
                else
                {
                    command.ToVillage.VillageCommonMethods.UpdateVillage(command.LandingTime, session, false);
                    newCommand = command.Effect(session);
                    commands.RemoveAt(0);
                }

                //session.Delete(command);
                if (newCommand != null)
                    if (newCommand.LandingTime < to)
                        commands.Add(newCommand.LandingTime, newCommand);
            }

            this.Village.VillageResourceMethods.UpdateResources(currentTime, to);

            while (this.Village.VillageRecruitMethods.InfantryRecruits.Count > 0 && this.Village.VillageRecruitMethods.InfantryRecruits[0].Expense(to))
            {
                Recruit r = this.Village.VillageRecruitMethods.InfantryRecruits[0];
                session.Delete(r);
                this.Village.VillageRecruitMethods.InfantryRecruits.RemoveAt(0);
                this.Village.Recruits.Remove(r);
                
            }
            while (this.Village.VillageRecruitMethods.CavalryRecruits.Count > 0 && this.Village.VillageRecruitMethods.CavalryRecruits[0].Expense(to))
            {
                Recruit r = this.Village.VillageRecruitMethods.CavalryRecruits[0];
                session.Delete(r);
                this.Village.Recruits.Remove(r);
                
                this.Village.VillageRecruitMethods.CavalryRecruits.RemoveAt(0);
                
            }
            while (this.Village.VillageRecruitMethods.CarRecruits.Count > 0 && this.Village.VillageRecruitMethods.CarRecruits[0].Expense(to))
            {
                Recruit r = this.Village.VillageRecruitMethods.CarRecruits[0];
                session.Delete(r);
                this.Village.Recruits.Remove(r);
                this.Village.VillageRecruitMethods.CarRecruits.RemoveAt(0);
                
            }

            while (this.Village.Researches.Count > 0 && this.Village.Researches[0].Expense(to))
            {
                this.Village[this.Village.Researches[0].Type]++;
                session.Delete(this.Village.Researches[0]);
                this.Village.Researches.RemoveAt(0);
            }

            while (this.Village.Builds.Count > 0 && this.Village.Builds[0].Expense(to))
            {

                if (this.Village.Builds[0].Building == BuildingType.Smithy)
                    for (int i = 1; i < this.Village.Researches.Count; i++)
                    {
                        Research research = this.Village.Researches[i];
                        research.Start = this.Village.Researches[i - 1].End;
                        ResearchPrice price = Research.GetPrice(research.Type, research.Level, this.Village[BuildingType.Smithy]);
                        research.End = research.Start.AddMilliseconds(price.Time);
                    }
                else if (this.Village.Builds[0].Building == BuildingType.Headquarter)
                    for (int i = 1; i < this.Village.Builds.Count; i++)
                    {
                        Build build = this.Village.Builds[i];
                        build.Start = this.Village.Builds[i - 1].End;
                        BuildPrice price = Build.GetPrice(build.Building, build.Level, this.Village[BuildingType.Headquarter]);
                        build.End = build.Start.AddMilliseconds(price.BuildTime);
                    }
                else if (this.Village.Builds[0].Building == BuildingType.Barracks)
                    for (int i = 0; i < this.Village.VillageRecruitMethods.InfantryRecruits.Count; i++)
                    {
                        Recruit r = this.Village.VillageRecruitMethods.InfantryRecruits[i];
                        if (i != 0)
                            r.LastUpdate = this.Village.VillageRecruitMethods.InfantryRecruits[i].FinishTime;
                        Price p = Recruit.GetPrice(r.Troop, this.Village[BuildingType.Barracks]);
                        r.FinishTime = r.LastUpdate.AddMilliseconds(p.BuildTime * r.Quantity);
                    }
                else if (this.Village.Builds[0].Building == BuildingType.Stable)
                    for (int i = 0; i < this.Village.VillageRecruitMethods.CavalryRecruits.Count; i++)
                    {
                        Recruit r = this.Village.VillageRecruitMethods.CavalryRecruits[i];
                        if (i != 0)
                            r.LastUpdate = this.Village.VillageRecruitMethods.CavalryRecruits[i].FinishTime;
                        Price p = Recruit.GetPrice(r.Troop, this.Village[BuildingType.Stable]);
                        r.FinishTime = r.LastUpdate.AddMilliseconds(p.BuildTime * r.Quantity);
                    }
                else if (this.Village.Builds[0].Building == BuildingType.Workshop)
                    for (int i = 0; i < this.Village.VillageRecruitMethods.CarRecruits.Count; i++)
                    {
                        Recruit r = this.Village.VillageRecruitMethods.CarRecruits[i];
                        if (i != 0)
                            r.LastUpdate = this.Village.VillageRecruitMethods.CarRecruits[i].FinishTime;
                        Price p = Recruit.GetPrice(r.Troop, this.Village[BuildingType.Workshop]);
                        r.FinishTime = r.LastUpdate.AddMilliseconds(p.BuildTime * r.Quantity);
                    }
                session.Delete(this.Village.Builds[0]);
                this.Village.Builds.RemoveAt(0);
            }

            this.Village.LastUpdate = to;
            foreach (Build b in this.Village.Builds)
                session.Update(b);
            foreach (Recruit r in this.Village.Recruits)
                session.Update(r);
            foreach (Research r in this.Village.Researches)
                session.Update(r);

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
