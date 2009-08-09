using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {

        public virtual int MaxRecruit(TroopType troop)
        {
            return Recruit.MaxRecruit(troop, this.VillageResourceData.Wood, this.VillageResourceData.Clay, this.VillageResourceData.Iron);
        }
        public virtual Recruit BeginRecruit(TroopType troop, int quantity, ISession session)
        {
            if (!Recruit.CanRecruit(troop, quantity, this.VillageResourceData.Wood, this.VillageResourceData.Clay, this.VillageResourceData.Iron))
                return null;

            int level = 0;
            if ((troop == TroopType.Axe) || (troop == TroopType.Spear) || (troop == TroopType.Sword))
                level = this[BuildingType.Barracks];
            if ((troop == TroopType.Light) || (troop == TroopType.Scout) || (troop == TroopType.Heavy))
                level = this[BuildingType.Stable];

            Recruit recruit = new Recruit();
            recruit.InVillage = this;
            recruit.Quantity = quantity;
            recruit.Troop = troop;
            recruit.LastUpdate = DateTime.Now;

            Price p = Recruit.GetPrice(troop);
            this.VillageResourceData.Clay -= p.Clay * quantity;
            this.VillageResourceData.Wood -= p.Wood * quantity;
            this.VillageResourceData.Iron -= p.Iron * quantity;
            this.Population += p.Population * quantity;

            session.Save(recruit);
            session.Update(this);

            return recruit;
        }
        public virtual IList<Recruit> GetRecruit(ISession session, BuildingType building)
        {

            switch (building)
            {
                case BuildingType.Barracks:
                case BuildingType.Academy:
                case BuildingType.Stable:
                case BuildingType.Workshop:
                    break;
                default:
                    throw new Exception("Hack hả ku :))");
            }

            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Gt("Quantity", 0));
            criteria.AddOrder(new Order("ID", true));

            switch (building)
            {
                case BuildingType.Barracks:
                    criteria.Add(Expression.Or(
                        Expression.Or(
                            Expression.Eq("Troop", TroopType.Axe),
                            Expression.Eq("Troop", TroopType.Spear)),
                        Expression.Eq("Troop", TroopType.Sword)));
                    break;
                case BuildingType.Stable:
                    criteria.Add(Expression.Or(
                        Expression.Or(
                            Expression.Eq("Troop", TroopType.Scout),
                            Expression.Eq("Troop", TroopType.Light)),
                        Expression.Eq("Troop", TroopType.Heavy)));
                    break;
                case BuildingType.Workshop:
                    criteria.Add(Expression.Or(
                        Expression.Eq("Troop", TroopType.Ram),
                        Expression.Eq("Troop", TroopType.Catapult)));
                    break;
                case BuildingType.Academy:
                    criteria.Add(Expression.Eq("Troop", TroopType.Nobleman));
                    break;
                default:
                    throw new Exception("Hack hả ku :))");
            }
            return criteria.List<Recruit>();
        }

        public virtual void CancelRecruit(int recruit_id, ISession session)
        {

            Recruit recruit = (from r in session.Linq<Recruit>()
                               where r.ID == recruit_id &&
                               r.InVillage == this
                               select r).SingleOrDefault<Recruit>();
            if (recruit == null)
                return;

            Price price = Recruit.GetPrice(recruit.Troop);
            this.VillageResourceData.Wood += price.Wood * recruit.Quantity;
            this.VillageResourceData.Clay += price.Clay * recruit.Quantity;
            this.VillageResourceData.Iron += price.Iron * recruit.Quantity;
            this.Population -= (int)(price.Population * recruit.Quantity);
            session.Update(this);
            session.Delete(recruit);
        }

        protected virtual IList<Recruit> GetDependingCarRecruit(ISession session)
        {
            return (from recruit in session.Linq<Recruit>()
                    where recruit.InVillage == this &&
                    (recruit.Troop == TroopType.Ram || recruit.Troop == TroopType.Catapult)
                    orderby recruit.ID ascending
                    select recruit).ToList<Recruit>();
        }
        protected virtual IList<Recruit> GetDependingNobleRecruit(ISession session)
        {
            return (from recruit in session.Linq<Recruit>()
                    where recruit.InVillage == this &&
                    recruit.Troop == TroopType.Nobleman
                    orderby recruit.ID ascending
                    select recruit).ToList<Recruit>();

        }
        protected virtual IList<Recruit> GetDependingInfantryRecruit(ISession session)
        {
            return (from recruit in session.Linq<Recruit>()
                    where recruit.InVillage == this &&
                    (recruit.Troop == TroopType.Spear || recruit.Troop == TroopType.Sword || recruit.Troop == TroopType.Axe)
                    orderby recruit.ID ascending
                    select recruit).ToList<Recruit>();
        }
        protected virtual IList<Recruit> GetDependingCavalryRecruit(ISession session)
        {
            return (from recruit in session.Linq<Recruit>()
                    where recruit.InVillage == this &&
                    (recruit.Troop == TroopType.Scout || recruit.Troop == TroopType.Light || recruit.Troop == TroopType.Heavy)
                    orderby recruit.ID ascending
                    select recruit).ToList<Recruit>();
        }
    }
}
