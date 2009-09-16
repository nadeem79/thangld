using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Type;
using NHibernate.Engine;
namespace TestProject1
{
    public class NHibernateHelper
    {
        private static Configuration mWConfig = null;
        private static ISessionFactory sessionFactory = null;

        public static ISessionFactory CreateSessionFactory()
        {
            if (object.Equals(NHibernateHelper.sessionFactory, null))
                NHibernateHelper.sessionFactory = NHibernateHelper.MWConfig().BuildSessionFactory();

            return NHibernateHelper.sessionFactory;
        }

        public static Configuration MWConfig()
        {
            if (object.Equals(NHibernateHelper.mWConfig, null))
            {
                NHibernateHelper.mWConfig = new Configuration();
                NHibernateHelper.mWConfig.AddAssembly("beans");
            }
            return NHibernateHelper.mWConfig;
        }

        public static ISession CreateSession()
        {
            ISession session = NHibernateHelper.CreateSessionFactory().OpenSession();
            session.EnableFilter("NapFilter");
            session.EnableFilter("EnemyFilter");
            session.EnableFilter("AllyFilter");

            return session;
        }
    }
}
