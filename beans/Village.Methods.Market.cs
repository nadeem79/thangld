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
                merchantCount += (sending.Wood + sending.Clay + sending.Iron) / 1000 + ((sending.Wood + sending.Clay + sending.Iron) % 1000 > 0 ? 1 : 0);


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

            return Convert.ToInt32(o);
        }

        public int MerchantAvailable(ISession session)
        {
            
            ICriteria criteria = session.CreateCriteria(typeof(Offer));
            criteria.Add(Expression.Eq("AtVillage", this));

            int merchantCount = 0;

            foreach (Offer offer in criteria.List<Offer>())
                if (offer.OfferQuantity < 1000)
                    merchantCount += offer.OfferNumber;
                else
                    merchantCount += (int)Math.Round((double)(offer.OfferQuantity / 1000)) * offer.OfferNumber;

            return this.Buildings.Merchant - merchantCount - this.MerchantOnTheWay(session) - this.MerchantOnTheWayHome(session);
        }

        public int AvailableMerchant(ISession session)
        {
            return this.Buildings.Merchant - this.MerchantOnTheWay(session) - this.MerchantOnTheWayHome(session);
        }

        public IList<SendResource> GetDependingResource(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Ge("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Lt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(to)));
            criteria.AddOrder(new Order("LandingTimestamp", true));

            return criteria.List<SendResource>();
        }

        public IList<SendResource> GetDependingResource(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("To", this));
            criteria.AddOrder(new Order("LandingTimestamp", true));

            return criteria.List<SendResource>();
        }

        public IList<SendResource> GetIncomingMerchants(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("To", this));
            return criteria.List<SendResource>();
        }
        public IList<MovingCommand> GetReturnMerchants(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Return));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Gt("Merchant", 0));
            return criteria.List<MovingCommand>();
        }
        public IList<SendResource> GetOutgoingMerchants(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("From", this));
            criteria.AddOrder(new Order("LandingTimestamp", true));
            return criteria.List<SendResource>();
        }

        public IList<SendResource> GetOutgoingMerchants(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("From", this));
            criteria.Add(Expression.Ge("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Lt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(to)));
            criteria.AddOrder(new Order("LandingTimestamp", true));
            return criteria.List<SendResource>();
        }

        public IList<MovingCommand> IncomingMerchants(ISession session)
        {
            IList<MovingCommand> incomings = new List<MovingCommand>();
            foreach (MovingCommand command in this.GetIncomingMerchants(session))
                incomings.Add(command);
            foreach (MovingCommand command in this.GetReturnMerchants(session))
                incomings.Add(command);
            return incomings;
        }

        public IList<MovingCommand> GetIncomingMerchants(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Return));
            criteria.Add(Expression.Gt("Merchant", 0));

            IList<MovingCommand> lstIncomings = criteria.List<MovingCommand>();


            foreach (MovingCommand incoming in this.GetDependingResource(session))
                if (!lstIncomings.Contains(incoming))
                    lstIncomings.Add(incoming);

            return lstIncomings;
        }
    }
}
