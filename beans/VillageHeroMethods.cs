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

                session.Save(hero);
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
    }
}
