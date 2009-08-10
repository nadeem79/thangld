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
        public virtual IList<SendResource> ResourceTransporting
        {
            get;
            set;
        }

        public virtual IList<SendResource> TransportToMe
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
            this.ResourceTransporting = (from sendResource in session.Linq<SendResource>()
                                         where (sendResource.FromVillage == this
                                         || sendResource.ToVillage == this)
                                         && sendResource.LandingTime > DateTime.Now
                                         select sendResource).ToList<SendResource>();

            this.TransportFromMe = (from sendResource in this.ResourceTransporting
                                    where sendResource.FromVillage == this
                                    select sendResource).ToList<SendResource>();
            this.TransportToMe = (from sendResource in this.ResourceTransporting
                                  where sendResource.ToVillage == this
                                  select sendResource).ToList<SendResource>();

        }


    }
}
