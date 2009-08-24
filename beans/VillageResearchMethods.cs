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
        public IList<Research> Researches
        {
            get;
            set;
        }
        public int MaxAttackLevel
        {
            get;
            set;
        }
        public int MaxDefenseLevel
        {
            get;
            set;
        }
        public int MaxSpeedLevel
        {
            get;
            set;
        }

        public Research CreateResearch(ResearchType type, ISession session)
        {
            if (this.Researches == null)
                this.GetResearchs(session);

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
            Research lastResearch = (from r in this.Researches
                                     orderby r.ID descending
                                     select r).FirstOrDefault<Research>();

            if (lastResearch == null)
                research.Start = DateTime.Now;
            else
                research.Start = lastResearch.End;

            research.End = research.Start.AddSeconds(price.Time);

            this.Village[ResourcesType.Wood] -= price.Wood;
            this.Village[ResourcesType.Iron] -= price.Iron;
            this.Village[ResourcesType.Clay] -= price.Clay;

                session.Save(research);
                session.Update(this.Village.VillageResourceData);
            
            return research;
        }

        public void CancelResearch(Research research, ISession session)
        {
            if (research.Village != this.Village)
                throw new TribalWarsException("Nâng cấp không tồn tại");

            int smithyLevel = this.Village[BuildingType.Smithy];

            IList<Research> researchs = (from r in session.Linq<Research>()
                                         where r.Village == this.Village
                                         && r.ID >= research.ID
                                         orderby r.ID ascending
                                         select r).ToList<Research>();

            Research topResearch = (from r in researchs
                                    where r.Type == research.Type
                                    orderby r.ID descending
                                    select r).FirstOrDefault<Research>();

            ResearchPrice price = Research.GetPrice(research.Type, topResearch.Level, smithyLevel);

            researchs.Remove(research);

            foreach (Research r in researchs)
            {
                if (r.Type == research.Type)
                    r.Level -= 1;

                ResearchPrice nextPrice = Research.GetPrice(r.Type, r.Level, smithyLevel);
                r.End = r.Start.AddSeconds(nextPrice.Time);
            }

            this.Village[ResourcesType.Wood] += (int)(price.Wood + 0.8);
            this.Village[ResourcesType.Clay] += (int)(price.Clay + 0.8);
            this.Village[ResourcesType.Iron] += (int)(price.Iron + 0.8);

                foreach (Research r in researchs)
                    session.Update(r);
                session.Update(this.Village.VillageResourceData);
                session.Delete(research);
        }

        public void CancelResearch(int researchId, ISession session)
        {
            Research research = Research.GetResearchById(researchId, session);
            this.CancelResearch(research, session);
        }

        public IList<Research> GetResearchs(ISession session)
        {
            IList<Research> researches = (from research in session.Linq<Research>()
                                          where research.Village == this.Village
                                          orderby research.ID ascending
                                          select research).ToList<Research>();
            this.MaxAttackLevel = (from research in researches
                                   where research.Type == ResearchType.Attack
                                   orderby research.ID descending
                                   select research.Level).FirstOrDefault<int>();
            this.MaxDefenseLevel = (from research in researches
                                    where research.Type == ResearchType.Defense
                                    orderby research.ID descending
                                    select research.Level).FirstOrDefault<int>();
            this.MaxSpeedLevel = (from research in researches
                                  where research.Type == ResearchType.Speed
                                  orderby research.ID descending
                                  select research.Level).FirstOrDefault<int>();

            this.Researches = researches;
            return researches;
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
