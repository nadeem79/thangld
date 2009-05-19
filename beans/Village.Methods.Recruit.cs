﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {

        public int MaxRecruit(TroopType troop)
        {
            return Recruit.MaxRecruit(troop, this.Resources.Wood, this.Resources.Clay, this.Resources.Iron);
        }
        public Recruit BeginRecruit(TroopType troop, int quantity, ISession session)
        {
            if (!Recruit.CanRecruit(troop, quantity, this.Resources.Wood, this.Resources.Clay, this.Resources.Iron))
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
            this.Resources.Clay -= p.Clay * quantity;
            this.Resources.Wood -= p.Wood * quantity;
            this.Resources.Iron -= p.Iron * quantity;

            session.Save(recruit);
            session.Update(this);

            return recruit;
        }
        public IList<Recruit> GetRecruit(ISession session, BuildingType building)
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

        public void CancelRecruit(int recruit_id, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("ID", recruit_id));
            criteria.Add(Expression.Eq("InVillage", this));
            Recruit recruit = criteria.UniqueResult<Recruit>();
            if (recruit == null)
                return;

            Price price = Recruit.GetPrice(recruit.Troop);
            this.Resources.Wood += price.Wood * recruit.Quantity;
            this.Resources.Clay += price.Clay * recruit.Quantity;
            this.Resources.Iron += price.Iron * recruit.Quantity;
            this.Population -= (int)(price.Population * recruit.Quantity);
            session.Update(this);
            session.Delete(recruit);
        }

        protected IList<Recruit> GetDependingCarRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Catapult), Expression.Eq("Troop", TroopType.Ram)));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
        protected IList<Recruit> GetDependingNobleRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Eq("Troop", TroopType.Nobleman));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
        protected IList<Recruit> GetDependingInfantryRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Axe), Expression.Or(Expression.Eq("Troop", TroopType.Spear), Expression.Eq("Troop", TroopType.Sword))));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
        protected IList<Recruit> GetDependingCavalryRecruit(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Recruit));
            criteria.Add(Expression.Eq("InVillage", this));
            criteria.Add(Expression.Or(Expression.Eq("Troop", TroopType.Scout), Expression.Or(Expression.Eq("Troop", TroopType.Light), Expression.Eq("Troop", TroopType.Heavy))));
            criteria.AddOrder(new Order("ID", true));
            return criteria.List<Recruit>();
        }
    }
}