using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public class ShoutboxData:IdentityObject
    {
        public Player Player
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public Group Group
        {
            get;
            set;
        }

        public static IList<ShoutboxData> GetShoutbox(Group group, int size, bool ascending, ISession session)
        {
            if (group == null)
            {
                IQuery query = session.CreateQuery("from ShoutboxData sd where sd.Group is null order by ID " + ((ascending) ? "asc" : "desc"));
                query.SetMaxResults(size);
                query.SetFirstResult(0);
                return query.List<ShoutboxData>();
            }
            else
            {
                ICriteria criteria = session.CreateCriteria(typeof(ShoutboxData));
                criteria.Add(Expression.Eq("Group", group));
                criteria.AddOrder(new Order("ID", ascending));
                criteria.SetFirstResult(0);
                criteria.SetMaxResults(size);
                return criteria.List<ShoutboxData>();
            }
        }

    }
}
