using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public class VillageTransportMethods
    {
        public Village Village
        {
            get;
            set;
        }

        public virtual IList<MovingCommand> ResourceTransporting
        {
            get;
            set;
        }

        public virtual IList<MovingCommand> TransportToMe
        {
            get;
            set;
        }

        public virtual IList<MovingCommand> TransportFromMe
        {
            get;
            set;
        }

        public virtual void GetTransportData(ISession session)
        {
            this.TransportToMe = (from movingCommand in this.Village.MovingCommandsToMe
                                  where movingCommand.GetType() == typeof(SendResource) ||
                                  (movingCommand.GetType() == typeof(Return) && ((Return)movingCommand).Merchant > 0)
                                  orderby movingCommand.LandingTime ascending
                                  select movingCommand).ToList<MovingCommand>();

            this.TransportFromMe = (from transport in this.Village.MovingCommandsFromMe
                                    where transport.GetType() == typeof(SendResource)
                                    orderby transport.LandingTime ascending
                                    select transport).ToList<MovingCommand>();
        }

        public virtual int GetMerchantOnTheWay(ISession session)
        {
            return (from transport in this.Village.MovingCommandsFromMe
                    where transport.GetType() == typeof(SendResource)
                    select ((SendResource)transport).Merchant).Sum();
        }
    }
}
