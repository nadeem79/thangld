using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public abstract class MovingCommand : IdentityObject
    {
        #region Properties
        public virtual Village FromVillage
        {
            get;
            set;
        }
        public virtual Village ToVillage
        {
            get;
            set;
        }

        public virtual DateTime StartingTime
        {
            get;
            set;
        }
        public virtual DateTime LandingTime
        {
            get;
            set;
        }
        public abstract MoveType Type
        {
            get;
        }
        #endregion

        public abstract void Save(ISession session);
        public abstract MovingCommand Effect(ISession session);
        public abstract MovingCommand Cancel(ISession session);
    }
}
