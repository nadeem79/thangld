using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {
        #region Methods.Troops

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
        protected IList<Attack> GetDependingAttack(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Attack));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Gt("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Le("LandingTimestamp", DatetimeHelper.DatetimeToInt64(to)));
            criteria.AddOrder(new Order("LandingTimestamp", true));
            return criteria.List<Attack>();
        }

        public IList<MovingCommand> GetTroopMovement(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));

            criteria.Add(
                Expression.Or(
                    Expression.Eq("To", this),
                    Expression.Eq("From", this))
                );
            criteria.Add(Expression.Eq("Pending", false));
            criteria.Add(Expression.Gt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(DateTime.Now)));
            criteria.AddOrder(Order.Asc("LandingTimestamp"));
            IList<MovingCommand> lst = criteria.List<MovingCommand>();
            return lst;
        }
        //public IList<MovingCommand> GetIncomingTroop(ISession session)
        //{
        //    ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
        //    criteria.Add(Expression.Eq("Pending", false));
        //    criteria.Add(Expression.Eq("To", this));
        //    criteria.Add(Expression.Gt("LandingTimestamp", DatetimeHelper.DatetimeToInt64(DateTime.Now)));
        //    criteria.AddOrder(Order.Desc("LandingTimestamp"));

        //    return criteria.List<MovingCommand>();
        //}

        public IList<Attack> getDependingAttacking(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Attack));
            criteria.Add(Expression.Eq("From", this));
            criteria.Add(Expression.Gt("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Le("LandingTimestamp", DatetimeHelper.DatetimeToInt64(to)));
            criteria.AddOrder(new Order("LandingTimestamp", true));

            return criteria.List<Attack>();
        }
        public IList<MovingCommand> getFriendlyIncomings(DateTime to, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Sql(new NHibernate.SqlCommand.SqlString("type != 2")));
            criteria.Add(Expression.Gt("LandingTimestamp", this.LastUpdateTimestamp));
            criteria.Add(Expression.Le("LandingTimestamp", DatetimeHelper.DatetimeToInt64(to)));
            criteria.AddOrder(new Order("LandingTimestamp", true));

            return criteria.List<MovingCommand>();
        }

        #endregion 
    }
}
