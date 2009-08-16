using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

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
            ICriteria criteria = session.CreateCriteria<MovingCommand>();
            criteria.Add(Expression.Gt("LandingTime", this.LastUpdate));
            criteria.Add(Expression.Or
                        (
                            Expression.And
                            (
                                Expression.Sql("this_.type=1"), // đối tượng SendResource
                                Expression.Or // đến bất kỳ đâu
                                (
                                    Expression.Eq("FromVillage", this),
                                    Expression.Eq("ToVillage", this)
                                 )
                            ),
                            Expression.And
                            (
                                Expression.And
                                (
                                    Expression.Sql("this_.type=4"), // đối tượng return
                                    Expression.Sql("this_.merchant>0") // có merchant >0
                                ),
                                Expression.Eq("ToVillage", this) // đến làng this
                            )
                        ));
            
            criteria.AddOrder(Order.Asc("LandingTime"));

            this.ResourceTransporting = criteria.List<MovingCommand>();

            this.TransportFromMe = (from sendResource in this.ResourceTransporting
                                    where sendResource.FromVillage == this
                                    orderby sendResource.LandingTime ascending
                                    select (SendResource)sendResource).ToList<SendResource>();

            this.TransportToMe = (from movingCommand in this.ResourceTransporting
                                  where movingCommand.ToVillage == this
                                  orderby movingCommand.LandingTime ascending
                                  select movingCommand).ToList<MovingCommand>();

        }

        public virtual int GetMerchantOnTheWay(ISession session)
        {
            return (from sendResource in session.Linq<SendResource>()
                    where sendResource.FromVillage == this
                    select sendResource.Merchant).Sum();
        }
    }
}
