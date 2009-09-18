﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Hero:IdentityObject
    {

        protected static Dictionary<int, double> heroLevel = new Dictionary<int, double>();

        internal static Dictionary<int, double> HeroLevel
        {
            get { return heroLevel; }
        }

        
        public virtual HeroType Type
        {
            get;
            set;
        }

        

        public virtual string Name
        {
            get;
            set;
        }
        public virtual string Biography
        {
            get;
            set;
        }
        public virtual bool Avatar
        {
            get;
            set;
        }
        public virtual int Attack
        {
            get;
            set;
        }
        public virtual int Defense
        {
            get;
            set;
        }
        public virtual int Speed
        {
            get;
            set;
        }
        public virtual int Intelligent
        {
            get;
            set;
        }
        public virtual double Experience
        {
            get;
            set;
        }
        public virtual int Level
        {
            get;
            set;
        }
        public virtual int Luck
        {
            get;
            set;
        }

        public virtual Village InVillage
        {
            get;
            set;
        }

        public virtual MovingCommand InMovingCommand
        {
            get;
            set;
        }
        public virtual bool IsDead
        {
            get;
            set;
        }
        public virtual Player Owner
        {
            get;
            set;
        }

        protected void CalculateHeroAtribute()
        {
            Random r = new Random();
            switch (this.Type)
            {
                case HeroType.Intelligent:
                    this.Intelligent += 4 + r.Next(2);
                    this.Attack += 1 + r.Next(2);
                    this.Defense += 1 + r.Next(2);
                    this.Luck += 1 + r.Next(2);
                    this.Speed += 1 + r.Next(2);
                    break;
                case HeroType.Attack:
                    this.Attack += 4 + r.Next(2);
                    this.Intelligent += 1 + r.Next(2);
                    this.Defense += 1 + r.Next(2);
                    this.Luck += 1 + r.Next(2);
                    this.Speed += 1 + r.Next(2);
                    break;
                case HeroType.Defense:
                    this.Defense += 4 + r.Next(2);
                    this.Attack += 1 + r.Next(2);
                    this.Intelligent += 1 + r.Next(2);
                    this.Luck += 1 + r.Next(2);
                    this.Speed += 1 + r.Next(2);
                    break;
                default:
                    break;
            }
        }
        public virtual void LevelUp(double experience)
        {
            double nextExperience = HeroLevel[this.Level + 1];

            if (experience > nextExperience)
            {
                this.Level++;
                this.CalculateHeroAtribute();
                this.LevelUp(experience);
            }

            this.Experience = experience;
        }
    }
}
