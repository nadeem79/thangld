using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public partial class Village
    {
        public int MerchantOnTheWay(ISession session)
        {
            IQuery query = session.CreateQuery("select (sr.Clay + sr.Wood + sr.Iron) from SendResource sr where sr.From=:village");
            query.SetEntity("village", this);
            return (int)Math.Round(query.List<decimal>()[0] / 1000);
        }
    }
}
