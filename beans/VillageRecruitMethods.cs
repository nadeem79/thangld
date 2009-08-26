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
            Recruit lastRecruit = null;
            BuildingType building = BuildingType.Barracks;
            int level = 0;
            if ((troop == TroopType.Axe) || (troop == TroopType.Spear) || (troop == TroopType.Sword))
            {
                level = this.Village[BuildingType.Barracks];
                lastRecruit = (from r in this.InfantryRecruits
                               orderby r.ID descending
                               select r).FirstOrDefault<Recruit>();
            }
            else if ((troop == TroopType.Light) || (troop == TroopType.Scout) || (troop == TroopType.Heavy))
            {
                level = this.Village[BuildingType.Stable];
                building = BuildingType.Stable;
                lastRecruit = (from r in this.CavalryRecruits
                               orderby r.ID descending
                               select r).FirstOrDefault<Recruit>();
            }
            else if (troop == TroopType.Ram || troop == TroopType.Catapult)
            {
                building = BuildingType.Workshop;
                level = this.Village[BuildingType.Workshop];
                lastRecruit = (from r in this.CarRecruits
                               orderby r.ID descending
                               select r).FirstOrDefault<Recruit>();
            }

            Recruit recruit = new Recruit();
            recruit.InVillage = this.Village;
            recruit.Quantity = quantity;
            recruit.Troop = troop;
            if (lastRecruit == null)
                recruit.LastUpdate = DateTime.Now;
            else
                recruit.LastUpdate = lastRecruit.FinishTime;

            Price p = Recruit.GetPrice(troop, this.Village[building]);
            this.Village.VillageResourceData.Clay -= p.Clay * quantity;
            this.Village.VillageResourceData.Wood -= p.Wood * quantity;
            this.Village.VillageResourceData.Iron -= p.Iron * quantity;
            this.Village.Population += p.Population * quantity;
            recruit.FinishTime = recruit.LastUpdate.AddMilliseconds(p.BuildTime * quantity);
            this.Village.Recruits.Add(recruit);
            session.Save(recruit);
            session.Update(this.Village);

            if ((troop == TroopType.Axe) || (troop == TroopType.Spear) || (troop == TroopType.Sword))
            {
                this.InfantryRecruits.Add(recruit);
            }
            else if ((troop == TroopType.Light) || (troop == TroopType.Scout) || (troop == TroopType.Heavy))
            {
                this.CavalryRecruits.Add(recruit);
            }
            else if (troop == TroopType.Ram || troop == TroopType.Catapult)
            {
                this.CarRecruits.Add(recruit);
            }

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
            
            IList<Recruit> recruits = null;

            if ((recruit.Troop == TroopType.Axe) || (recruit.Troop == TroopType.Spear) || (recruit.Troop == TroopType.Sword))
            {
                recruits = this.InfantryRecruits;
            }
            else if ((recruit.Troop == TroopType.Light) || (recruit.Troop == TroopType.Scout) || (recruit.Troop == TroopType.Heavy))
            {
                recruits = this.CavalryRecruits;
            }
            else if (recruit.Troop == TroopType.Ram || recruit.Troop == TroopType.Catapult)
            {
                recruits = this.CarRecruits;
            }

            recruits.Remove(recruit);

            for (int i = 0; i < recruits.Count; i++)
            {
                TimeSpan t = recruits[i].FinishTime - recruits[i].LastUpdate;
                if (i == 0)
                    recruits[i].LastUpdate = DateTime.Now;
                else
                    recruits[i].LastUpdate = recruits[i - 1].FinishTime;

                recruits[i].FinishTime = recruits[i].LastUpdate + t;
                session.Update(recruits[i]);
            }

            
            session.Delete(recruit);
            session.Update(this.Village);
            

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
                if (this.cavalryRecruits == null)
                    this.cavalryRecruits = (from recruit in this.Village.Recruits
                                             where recruit.Troop == TroopType.Scout || recruit.Troop == TroopType.Light || recruit.Troop == TroopType.Heavy
                                             orderby recruit.ID ascending
                                             select recruit).ToList<Recruit>();
                return this.cavalryRecruits;
            }
        }
    }
}
