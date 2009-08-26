using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    public class VillageResearchMethods
    {
        public Village Village
        {
            get;
            set;
        }
        private int maxAttackLevel = -1, maxDefenseLevel = -1, maxSpeedLevel = -1;
        public int MaxAttackLevel
        {
            get
            {
                if (this.maxAttackLevel >= 0)
                    return this.maxAttackLevel;
                Research maxAttackResearch = (from r in this.Village.Researches
                                              where r.Type == ResearchType.Attack
                                              orderby r.ID descending
                                              select r).FirstOrDefault<Research>();
                if (maxAttackResearch == null)
                    this.maxAttackLevel = this.Village.VillageResearchData.Attack;
                else
                    this.maxAttackLevel = maxAttackResearch.Level;
                return maxAttackLevel;
            }
        }
        public int MaxDefenseLevel
        {
            get
            {
                if (this.maxDefenseLevel >= 0)
                    return this.maxDefenseLevel;
                Research maxResearch = (from r in this.Village.Researches
                                        where r.Type == ResearchType.Speed
                                        orderby r.ID descending
                                        select r).FirstOrDefault<Research>();
                if (maxResearch == null)
                    this.maxDefenseLevel = this.Village.VillageResearchData.TroopSpeed;
                else
                    this.maxDefenseLevel = maxResearch.Level;
                return maxDefenseLevel;
            }
        }
        public int MaxSpeedLevel
        {
            get
            {
                if (this.maxSpeedLevel >= 0)
                    return this.maxSpeedLevel;
                Research maxResearch = (from r in this.Village.Researches
                                              where r.Type == ResearchType.Speed
                                              orderby r.ID descending
                                              select r).FirstOrDefault<Research>();
                if (maxResearch == null)
                    this.maxSpeedLevel = this.Village.VillageResearchData.TroopSpeed;
                else
                    this.maxSpeedLevel = maxResearch.Level;
                return maxSpeedLevel;
            }
        }

        public Research CreateResearch(ResearchType type, ISession session)
        {

            if (this.Village[BuildingType.Smithy] < 0)
                throw new TribalWarsException("Chưa xây viện nghiên cứu");
            ResearchPrice price = Research.GetPrice(type, this.Village[type] + 1, this.Village[BuildingType.Smithy]);
            if (this.Village[ResourcesType.Wood] < price.Wood || this.Village[ResourcesType.Iron] < price.Iron || this.Village[ResourcesType.Clay] < price.Clay)
                throw new TribalWarsException("Không đủ tài nguyên");

            Research research = new Research();
            research.Village = this.Village;
            research.Type = type;
            switch (type)
            {
                case ResearchType.Speed:
                    research.Level = this.MaxSpeedLevel + 1;
                    break;
                case ResearchType.Attack:
                    research.Level = this.MaxAttackLevel + 1;
                    break;
                case ResearchType.Defense:
                    research.Level = this.MaxDefenseLevel + 1;
                    break;
                default:
                    break;
            }
            Research lastResearch = (from r in this.Village.Researches
                                     orderby r.ID descending
                                     select r).FirstOrDefault<Research>();

            if (lastResearch == null)
                research.Start = DateTime.Now;
            else
                research.Start = lastResearch.End;

            research.End = research.Start.AddMilliseconds(price.Time);

            this.Village[ResourcesType.Wood] -= price.Wood;
            this.Village[ResourcesType.Iron] -= price.Iron;
            this.Village[ResourcesType.Clay] -= price.Clay;

            this.Village.Researches.Add(research);
            session.Save(research);
            session.Update(this.Village);

            return research;
        }

        public void CancelResearch(Research research, ISession session)
        {

            int smithyLevel = this.Village[BuildingType.Smithy];

            Research topResearch = (from r in this.Village.Researches
                                    where r.Type == research.Type
                                    orderby r.ID descending
                                    select r).FirstOrDefault<Research>();

            ResearchPrice price = Research.GetPrice(research.Type, topResearch.Level, smithyLevel);

            for(int i=0; i<this.Village.Researches.Count; i++)
            {
                Research r = this.Village.Researches[i];
                if (r.Type == research.Type && r.ID > research.ID)
                    r.Level -= 1;

                if (i == 0)
                    r.Start = DateTime.Now;
                else
                    r.Start = this.Village.Researches[i - 1].End;

                ResearchPrice nextPrice = Research.GetPrice(r.Type, r.Level, smithyLevel);
                
                r.End = r.Start.AddMilliseconds(nextPrice.Time);
                session.Update(research);
            }

            this.Village[ResourcesType.Wood] += (int)(price.Wood + 0.8);
            this.Village[ResourcesType.Clay] += (int)(price.Clay + 0.8);
            this.Village[ResourcesType.Iron] += (int)(price.Iron + 0.8);

            Village.Researches.Remove(research);
            session.Delete(research);
            session.Update(this.Village);
        }

        public void CancelResearch(int researchId, ISession session)
        {
            Research research = Research.GetResearchById(researchId, session);
            this.CancelResearch(research, session);
        }

        public bool CanResearch(ResearchType type, int level)
        {
            if (this.Village[BuildingType.Smithy] == 0)
                return false;
            ResearchPrice price = Research.GetPrice(type, level, this.Village[BuildingType.Smithy]);

            return (price.Wood < this.Village[ResourcesType.Wood] && price.Clay < this.Village[ResourcesType.Clay] && price.Iron < this.Village[ResourcesType.Iron]);
        }
    }
}
