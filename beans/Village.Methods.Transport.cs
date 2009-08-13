using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    partial class Village
    {
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

        public virtual IList<SendResource> TransportFromMe
        {
            get;
            set;
        }

        public virtual void GetTransportData(ISession session)
        {
            var query1 = (from sendResource in session.Linq<SendResource>()
                          where sendResource.FromVillage == this
                          || sendResource.ToVillage == this
                          select sendResource).ToList<SendResource>();

            var query2 = (from r in session.Linq<Return>()
                          where r.ToVillage == this
                          select r).ToList<Return>();

            this.ResourceTransporting = new List<MovingCommand>();
            foreach (MovingCommand command in query1)
                this.ResourceTransporting.Add(command);
            foreach (MovingCommand command in query2)
                this.ResourceTransporting.Add(command);

            this.TransportFromMe = (from sendResource in this.ResourceTransporting
                                    where sendResource.FromVillage == this
                                    orderby sendResource.LandingTime ascending
                                    select (SendResource)sendResource).ToList<SendResource>();

            this.TransportToMe = (from movingCommand in this.ResourceTransporting
                                  where movingCommand.ToVillage == this
                                  orderby movingCommand.LandingTime ascending
                                  select movingCommand).ToList<MovingCommand>();

        }


    }
}
