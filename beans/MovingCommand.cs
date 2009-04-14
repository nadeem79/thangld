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
        public long StartTimestamp
        {
            get;
            set;
        }
        public long LandingTimestamp
        {
            get;
            set;
        } 
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
        public bool Pending
        {
            get;
            set;
        }
        public DateTime StartTime
        {
            get
            {
                return DatetimeHelper.TimestampToDatetime(StartTimestamp);
                //return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds((double)StartTimestamp);
            }
            set
            {

                this.StartTimestamp = DatetimeHelper.DatetimeToInt64(value);
            }
        }
        public DateTime LandingTime
        {
            get
            {
                return DatetimeHelper.TimestampToDatetime(LandingTimestamp);
            }
            set
            {
                this.LandingTimestamp = DatetimeHelper.DatetimeToInt64(value);
            }
        }
        public abstract MoveType Type
        {
            get;
        }
        #endregion

        public abstract void save(ISession session);
        public abstract void effect(ISession session);
        public abstract void cancel(ISession session);
    }
}
