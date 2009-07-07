using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Diagnostics;

namespace beans
{
    public partial class Village
    {
        public virtual int MerchantOnTheWay(ISession session)
        {

            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("From", this));

            
            int merchantCount = 0;
            foreach (SendResource sending in criteria.List<SendResource>())
                merchantCount += (sending.Wood + sending.Clay + sending.Iron) / 1000 + ((sending.Wood + sending.Clay + sending.Iron) % 1000 > 0 ? 1 : 0);


            return merchantCount;
        }

        public virtual int MerchantOnTheWayHome(ISession session)
        {

            return (from Return r in session.Linq<Return>()
                    where r.ToVillage == this
                    select r).Sum<Return>(r => r.Merchant);
        }

        public virtual int MerchantAvailable(ISession session)
        {
            
            ICriteria criteria = session.CreateCriteria(typeof(Offer));
            criteria.Add(Expression.Eq("AtVillage", this));

            int merchantCount = 0;

            foreach (Offer offer in criteria.List<Offer>())
                if (offer.OfferQuantity < 1000)
                    merchantCount += offer.OfferNumber;
                else
                    merchantCount += (int)Math.Round((double)(offer.OfferQuantity / 1000)) * offer.OfferNumber;

            return this.VillageBuildingData.Merchant - merchantCount - this.MerchantOnTheWay(session) - this.MerchantOnTheWayHome(session);
        }

        public virtual int AvailableMerchant(ISession session)
        {
            return this.VillageBuildingData.Merchant - this.MerchantOnTheWay(session) - this.MerchantOnTheWayHome(session);
        }

        public virtual IList<SendResource> GetDependingResource(DateTime to, ISession session)
        {

            return (from SendResource sendResource in session.Linq<SendResource>()
                    where sendResource.ToVillage == this &&
                    sendResource.LandingTime > this.LastUpdate &&
                    sendResource.LandingTime < to
                    orderby sendResource.LandingTime ascending
                    select sendResource).ToList<SendResource>();
        }

        public virtual IList<SendResource> GetDependingResource(ISession session)
        {

            return (from SendResource sendResource in session.Linq<SendResource>()
                    where sendResource.ToVillage == this
                    orderby sendResource.LandingTime ascending
                    select sendResource).ToList<SendResource>();
        }

        public virtual IList<SendResource> GetIncomingMerchants(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(SendResource));
            criteria.Add(Expression.Eq("To", this));
            return criteria.List<SendResource>();
        }
        public virtual IList<Return> GetReturnMerchants(ISession session)
        {

            return (from Return r in session.Linq<Return>()
                    where r.ToVillage == this &&
                    r.Merchant > 0
                    select r).ToList<Return>();

        }
        public virtual IList<SendResource> GetOutgoingMerchants(ISession session)
        {

            return (from SendResource sendResource in session.Linq<SendResource>()
                    where sendResource.FromVillage == this
                    orderby sendResource.LandingTime ascending
                    select sendResource).ToList<SendResource>();
        }

        public virtual IList<SendResource> GetOutgoingMerchants(DateTime to, ISession session)
        {

            return (from SendResource sendResource in session.Linq<SendResource>()
                    where sendResource.FromVillage == this &&
                    sendResource.LandingTime > this.LastUpdate &&
                    sendResource.LandingTime < to
                    orderby sendResource.LandingTime ascending
                    select sendResource).ToList<SendResource>();
        }

        public virtual IList<MovingCommand> IncomingMerchants(ISession session)
        {
            IList<MovingCommand> incomings = new List<MovingCommand>();
            foreach (MovingCommand command in this.GetIncomingMerchants(session))
                incomings.Add(command);
            foreach (MovingCommand command in this.GetReturnMerchants(session))
                incomings.Add(command);
            return incomings;
        }

        public virtual IList<MovingCommand> GetIncomingMerchants(DateTime to, ISession session)
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
