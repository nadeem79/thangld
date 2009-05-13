using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Diagnostics;

namespace beans
{
    public partial class Village
    {
        public int MerchantOnTheWay(ISession session)
        {

            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("From", this));

            int merchantCount = 0;
            foreach (SendResource sending in criteria.List<SendResource>())
                merchantCount += (int)Math.Round((double)((sending.Wood + sending.Clay + sending.Iron) / 1000), MidpointRounding.AwayFromZero);


            return merchantCount;
        }

        public int MerchantOnTheWayHome(ISession session)
        {
            IQuery query = session.CreateQuery("select sum(r.Merchant) from Return r where r.To=:village");
            query.SetEntity("village", this);
            int i = 0;
            object o = query.List()[0];
            if (o==null)
                return 0;

            return (Int32)o;
        }

        public int MerchantAvailable(ISession session)
        {
            
            ICriteria criteria = session.CreateCriteria(typeof(Offer));
            criteria.Add(Expression.Eq("AtVillage", this));
            criteria.Add(Expression.

            int merchantCount = 0;

            foreach (Offer offer in criteria.List<Offer>())
                if (offer.OfferQuantity < 1000)
                    merchantCount += offer.OfferNumber;
                else
                    merchantCount += (int)Math.Round((double)(offer.OfferQuantity / 1000)) * offer.OfferNumber;

            return this.Buildings.Merchant - merchantCount;
        }

        public int AvailableMerchant(ISession session)
        {
            return this.Buildings.Merchant - this.MerchantOnTheWay(session) - this.MerchantOnTheWayHome(session);
        }

        
    }
}
