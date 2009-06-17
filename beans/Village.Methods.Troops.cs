using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {

        public int GetIncomingAttackCount(ISession session)
        {
            IQuery query = session.CreateQuery("select count(a.ID) from Attack a where a.To=:village");
            query.SetEntity("village", this);
            return Convert.ToInt32(query.List()[0]);
        }
        public int GetIncomingSupportCount(ISession session)
        {
            IQuery query = session.CreateQuery("select count(s.ID) from Support s where s.To=:village");
            query.SetEntity("village", this);
            return Convert.ToInt32(query.List()[0]);
        }
        


    }
}
