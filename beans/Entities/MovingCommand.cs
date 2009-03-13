using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beans;
using NHibernate;

namespace beans
{
    public abstract class MovingCommand : IdentityObject, IVillageEffector
    {
        Village from, to;
        DateTime startTime, landingTime;

        public virtual Village From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        public virtual Village To
        {
            get { return this.to; }
            set { this.to = value; }
        }

        public virtual DateTime StartTime
        {
            get { return this.startTime; }

            set { this.startTime = value; }
        }

        public virtual DateTime LandingTime
        {
            get { return this.landingTime; }
            set { this.landingTime = value; }
        }

        public abstract MoveType Type
        {
            get;
            set;
        }

        public abstract void effect(ISession session);

    }
}
