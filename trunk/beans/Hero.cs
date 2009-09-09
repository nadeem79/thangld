using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Hero:IdentityObject
    {
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
    }
}
