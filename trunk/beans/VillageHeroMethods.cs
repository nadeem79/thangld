using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    

    public class VillageHeroMethods
    {
        public Village Village
        {
            get;
            set;
        }

        public Hero CreateHero(string name, HeroType type, ISession session)
        {
            Random r = new Random();
            try
            {

                Price price = Recruit.GetPrice(TroopType.Nobleman, 1);
                int heroCount = this.Village.Player.Heroes.Count + 1;
                

                int clay = price.Clay * heroCount, wood = price.Wood * heroCount, iron = price.Iron * heroCount;
                if (this.Village[ResourcesType.Wood] < wood || this.Village[ResourcesType.Clay] < clay || this.Village[ResourcesType.Iron] < iron)
                    throw new TribalWarsException("Không đủ tài nguyên");

                if ((this.Village.Population + price.Population) > this.Village.MaxPopulation)
                    throw new TribalWarsException("Không đủ farm xây dựng hero");

                if (this.Village[BuildingType.Academy] < heroCount)
                    throw new TribalWarsException("Số hero không được vượt quá công trình academy");

                Hero hero = new Hero();
                hero.Type = type;
                hero.Name = name;
                hero.Biography = "";
                hero.Avatar = false;
                switch (type)
                {
                    case HeroType.Intelligent:
                        hero.Intelligent = 15 + r.Next(10);
                        hero.Attack = 10 + r.Next(10);
                        hero.Defense = 10 + r.Next(10);
                        break;
                    case HeroType.Attack:
                        hero.Attack = 15 + r.Next(10);
                        hero.Intelligent = 10 + r.Next(10);
                        hero.Defense = 10 + r.Next(10);
                        break;
                    case HeroType.Defense:
                        hero.Defense = 15 + r.Next(10);
                        hero.Attack = 10 + r.Next(10);
                        hero.Intelligent = 10 + r.Next(10);
                        break;
                    default:
                        break;
                }

                

                this.Village.Heroes.Add(hero);
                this.Village.Player.Heroes.Add(hero);
                
                hero.InVillage = this.Village;
                hero.Owner = this.Village.Player;
                hero.IsRecruiting = true;
                hero.IsDead = true;

                RecruitHero recruit = new RecruitHero();
                recruit.IsResurrection = false;
                recruit.Hero = hero;
                recruit.Owner = this.Village.Player;
                recruit.StartingTime = DateTime.Now;
                recruit.FinishTime = recruit.StartingTime.AddMilliseconds(Recruit.GetPrice(TroopType.Nobleman, this.Village[BuildingType.Academy]).BuildTime);

                
                session.Save(hero);
                session.Save(recruit);
                session.Update(this.Village);
                session.Update(this.Village.Player);

                return hero;
            }
            catch (TribalWarsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ServicesList.LogService.LogException(ex);
                throw ex;
            }
        }
        public void CancelRecruitHero(int recruit_id, ISession session)
        {

            Price p = Recruit.GetPrice(TroopType.Nobleman);


            RecruitHero recruit = (from r in this.Village.Player.RecruitHeroes
                               where r.ID == recruit_id
                                   select r).SingleOrDefault<RecruitHero>();

            if (recruit == null)
                return;

            Price price = Recruit.GetPrice(TroopType.Nobleman);
            this.Village.VillageResourceData.Wood += price.Wood;
            this.Village.VillageResourceData.Clay += price.Clay;
            this.Village.VillageResourceData.Iron += price.Iron;
            this.Village.Population -= (int)(price.Population);
            this.Village.Player.RecruitHeroes.Remove(recruit);
            
            IList<Recruit> recruits = null;

            for (int i = 0; i < this.Village.Player.RecruitHeroes.Count; i++)
            {
                TimeSpan t = recruits[i].FinishTime - recruits[i].LastUpdate;
                if (i == 0)
                    recruits[i].LastUpdate = DateTime.Now;
                else
                    recruits[i].LastUpdate = recruits[i - 1].FinishTime;

                recruits[i].FinishTime = recruits[i].LastUpdate + t;
                session.Update(recruits[i]);
            }

            session.Delete(recruit.Hero);
            recruit.Hero = null;
            session.Delete(recruit);
            session.Update(this.Village);
            session.Update(this.Village.Player);
        }

        public RecruitHero ResurrectHero(int heroId, ISession session)
        {
            RecruitHero recruit = new RecruitHero();
            recruit.Hero = session.Get<Hero>(heroId);
            if (recruit.Hero == null || recruit.Hero.Owner != this.Village.Player)
                throw new TribalWarsException("Hero không tồn tại");

            recruit.IsResurrection = true;
            recruit.Owner = this.Village.Player;
            recruit.StartingTime = DateTime.Now;
            

            Price p = Recruit.GetPrice(TroopType.Nobleman);
            

            session.Save(recruit);
            return recruit;
        }
    }
}
