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
        #region Methods.Research

        public ResearchableStatus PrepareResearch(TroopType type, ISession session)
        {
            int level = this.GetTotalResearchLevel(type, session) + 1;
            ResearchPrice price = beans.Research.GetPrice(type, level, this.Buildings.Smithy);

            ResearchableStatus status = this.CanResearch(type);

            if (status != ResearchableStatus.JustDoIt)
                return status;

            beans.Research research = new Research();
            research.Type = type;
            research.Village = this;
            research.Start = DateTime.Now;
            research.Level = level;
            this.Resources.Wood -= price.Wood;
            this.Resources.Clay -= price.Clay;
            this.Resources.Iron -= price.Iron;
            session.Save(research);
            session.Update(this);
            return status;
        }
        public int GetTotalResearchLevel(TroopType type, ISession session)
        {
            IQuery query = session.CreateQuery("select count(r.ID) from Research r where r.Village=:village and r.Type=:type");
            query.SetEntity("village", this);
            query.SetEnum("type", type);
            int level = 0;
            switch (type)
            {
                case TroopType.Spear:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchSpear;
                case TroopType.Sword:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchSword;
                case TroopType.Axe:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchAxe;
                case TroopType.Scout:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchScout;
                case TroopType.Light:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchLight;
                case TroopType.Heavy:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchHeavy;
                case TroopType.Ram:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchRam;
                case TroopType.Catapult:
                    return Convert.ToInt32(query.List()[0]) + this.Research.ResearchCatapult;
                default:
                    return 0;
            }
        }
        public ResearchableStatus CanResearch(TroopType type)
        {
            int level = 0;
            switch (type)
            {
                case TroopType.Spear:
                    level = this.Research.ResearchSpear + 1;
                    break;
                case TroopType.Sword:
                    level = this.Research.ResearchSword + 1;
                    break;
                case TroopType.Axe:
                    level = this.Research.ResearchAxe + 1;
                    break;
                case TroopType.Scout:
                    level = this.Research.ResearchScout + 1;
                    break;
                case TroopType.Light:
                    level = this.Research.ResearchLight + 1;
                    break;
                case TroopType.Heavy:
                    level = this.Research.ResearchHeavy + 1;
                    break;
                case TroopType.Ram:
                    level = this.Research.ResearchRam + 1;
                    break;
                case TroopType.Catapult:
                    level = this.Research.ResearchCatapult + 1;
                    break;
                default:
                    break;
            }

            ResearchPrice price = beans.Research.GetPrice(type, level, this[BuildingType.Smithy]);
            if (this.Resources.Wood < price.Wood)
                return ResearchableStatus.NotEnoughWood;
            if (this.Resources.Clay < price.Clay)
                return ResearchableStatus.NotEnoughClay;
            if (this.Resources.Iron < price.Iron)
                return ResearchableStatus.NotEnoughIron;

            switch (type)
            {
                case TroopType.Spear:
                    if (this[BuildingType.Smithy] < 1 && this[BuildingType.Barracks] < 1)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Sword:
                    if (this[BuildingType.Smithy] < 1 && this[BuildingType.Barracks] < 1)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Axe:
                    if (this[BuildingType.Smithy] < 2 && this[BuildingType.Barracks] < 1)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Scout:
                    if (this[BuildingType.Smithy] < 1 && this[BuildingType.Stable] < 1)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Light:
                    if (this[BuildingType.Smithy] < 1 && this[BuildingType.Stable] < 3)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Heavy:
                    if (this[BuildingType.Smithy] < 15 && this[BuildingType.Barracks] < 10)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Ram:
                    if (this[BuildingType.Smithy] < 1 && this[BuildingType.Workshop] < 1)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                case TroopType.Catapult:
                    if (this[BuildingType.Smithy] < 12 && this[BuildingType.Workshop] < 2)
                        return ResearchableStatus.RequirementNotMet;
                    break;
                default:
                    break;
            }

            return ResearchableStatus.JustDoIt;
        }
        public IList<Research> GetPendingResearch(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Research));
            criteria.Add(Expression.Eq("Village", this));
            criteria.AddOrder(Order.Asc("ID"));

            return criteria.List<Research>();
        }
        public void CancelResearch(Research research, ISession session)
        {
            if (research.Village != this)
                return;
            research.Cancel(session);
        }
        #endregion
    }
}
