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
        public Village From
        {
            get;
            set;
        }
        public Village To
        {
            get;
            set;
        }
        public DateTime StartTime
        {
            get;
            set;
        }
        public DateTime LandingTime
        {
            get;
            set;
        }
        public abstract MoveType Type
        {
            get;
        }
        #endregion

        public abstract void save(ISession session);
        public abstract void effect(ISession session);
    }
}
