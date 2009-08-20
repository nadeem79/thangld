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
            research.Level = this.Village[type] + 1;
            research.Start = DateTime.Now;
            research.End = research.Start.AddSeconds(price.Time);

            this.Village[ResourcesType.Wood] -= price.Wood;
            this.Village[ResourcesType.Iron] -= price.Iron;
            this.Village[ResourcesType.Clay] -= price.Clay;

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.Save(research);
                session.Update(this.Village.VillageResourceData);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }

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

            IList<Research> nextResearchs = (from r in researchs
                                             where r.Type == research.Type
                                             && r.ID > research.ID
                                             select r).ToList<Research>();

            foreach (Research r in nextResearchs)
            {
                r.Level -= 1;
                ResearchPrice nextPrice = Research.GetPrice(r.Type, r.Level, smithyLevel);
                r.End = r.Start.AddSeconds(nextPrice.Time);
            }

            this.Village[ResourcesType.Wood] += (int)(price.Wood + 0.8);
            this.Village[ResourcesType.Clay] += (int)(price.Clay + 0.8);
            this.Village[ResourcesType.Iron] += (int)(price.Iron + 0.8);

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                foreach (Research r in nextResearchs)
                    session.Update(r);
                session.Update(this.Village.VillageResourceData);
                session.Delete(research);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }
        }

        public void CancelResearch(int researchId, ISession session)
        {
            Research research = Research.GetResearchById(researchId, session);
            this.CancelResearch(research, session);
        }
    }
}
