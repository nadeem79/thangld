using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Data;

namespace beans
{
    public class VillageRecruitMethods
    {
        public Village Village
        {
            get;
            set;
        }

        public virtual int MaxRecruit(TroopType troop)
        {
            return Recruit.MaxRecruit(troop, this.Village.VillageResourceData.Wood, this.Village.VillageResourceData.Clay, this.Village.VillageResourceData.Iron);
        }
        public virtual Recruit BeginRecruit(TroopType troop, int quantity, ISession session)
        {
            if (!Recruit.CanRecruit(troop, quantity, this.Village.VillageResourceData.Wood, this.Village.VillageResourceData.Clay, this.Village.VillageResourceData.Iron))
                return null;

            int level = 0;
            if ((troop == TroopType.Axe) || (troop == TroopType.Spear) || (troop == TroopType.Sword))
                level = this.Village[BuildingType.Barracks];
            if ((troop == TroopType.Light) || (troop == TroopType.Scout) || (troop == TroopType.Heavy))
                level = this.Village[BuildingType.Stable];

            Recruit recruit = new Recruit();
            recruit.InVillage = this.Village;
            recruit.Quantity = quantity;
            recruit.Troop = troop;
            recruit.LastUpdate = DateTime.Now;

            Price p = Recruit.GetPrice(troop);
            this.Village.VillageResourceData.Clay -= p.Clay * quantity;
            this.Village.VillageResourceData.Wood -= p.Wood * quantity;
            this.Village.VillageResourceData.Iron -= p.Iron * quantity;
            this.Village.Population += p.Population * quantity;
            this.Village.Recruits.Add(recruit);
            session.Update(this.Village);
            session.Save(recruit);
            return recruit;

        }
        public virtual IList<Recruit> GetRecruit(ISession session, BuildingType building)
        {

            var query = from r in this.Village.Recruits
                        where r.Quantity > 0
                        orderby r.ID ascending
                        select r;

            switch (building)
            {
                case BuildingType.Barracks:
                    return query.Where<Recruit>(r => r.Troop == TroopType.Spear || r.Troop == TroopType.Sword || r.Troop == TroopType.Axe).ToList<Recruit>();
                case BuildingType.Stable:
                    return query.Where<Recruit>(r => r.Troop == TroopType.Scout || r.Troop == TroopType.Light || r.Troop == TroopType.Heavy).ToList<Recruit>();
                case BuildingType.Workshop:
                    return query.Where<Recruit>(r => r.Troop == TroopType.Ram || r.Troop == TroopType.Catapult).ToList<Recruit>();
                case BuildingType.Academy:
                    return query.Where<Recruit>(r => r.Troop == TroopType.Nobleman).ToList<Recruit>();
                default:
                    throw new Exception("Hack hả ku :))");
            }
        }

        public virtual void CancelRecruit(int recruit_id, ISession session)
        {

            Recruit recruit = (from r in this.Village.Recruits
                               where r.ID == recruit_id
                               select r).SingleOrDefault<Recruit>();

            if (recruit == null)
                return;

            Price price = Recruit.GetPrice(recruit.Troop);
            this.Village.VillageResourceData.Wood += price.Wood * recruit.Quantity;
            this.Village.VillageResourceData.Clay += price.Clay * recruit.Quantity;
            this.Village.VillageResourceData.Iron += price.Iron * recruit.Quantity;
            this.Village.Population -= (int)(price.Population * recruit.Quantity);
            this.Village.Recruits.Remove(recruit);
            session.Update(this.Village);
            this.Village.Recruits.Remove(recruit);

        }
        private IList<Recruit> carRecruits = null, nobleRecruits = null, infantryRecruits = null, cavalryRecruits = null;
        public IList<Recruit> CarRecruits
        {
            get
            {
                if (carRecruits == null)
                {
                    this.carRecruits = (from recruit in this.Village.Recruits
                                        where recruit.Troop == TroopType.Ram || recruit.Troop == TroopType.Catapult
                                        orderby recruit.ID ascending
                                        select recruit).ToList<Recruit>();
                }
                return this.carRecruits;
                
            }
        }
        public IList<Recruit> NobleRecruits
        {
            get
            {
                if (this.nobleRecruits == null)
                    this.nobleRecruits = (from recruit in this.Village.Recruits
                                          where recruit.Troop == TroopType.Nobleman
                                          orderby recruit.ID ascending
                                          select recruit).ToList<Recruit>();
                return this.nobleRecruits;
            }

        }
        public IList<Recruit> InfantryRecruits
        {
            get
            {
                if (this.infantryRecruits == null)
                    this.infantryRecruits = (from recruit in this.Village.Recruits
                                             where recruit.Troop == TroopType.Spear || recruit.Troop == TroopType.Sword || recruit.Troop == TroopType.Axe
                                             orderby recruit.ID ascending
                                             select recruit).ToList<Recruit>();
                return this.infantryRecruits;
            }
        }
        public IList<Recruit> CavalryRecruits
        {
            get
            {
                if (this.infantryRecruits == null)
                    this.infantryRecruits = (from recruit in this.Village.Recruits
                                             where recruit.Troop == TroopType.Scout || recruit.Troop == TroopType.Light || recruit.Troop == TroopType.Heavy
                                             orderby recruit.ID ascending
                                             select recruit).ToList<Recruit>();
                return this.infantryRecruits;
            }
        }
    }
}
