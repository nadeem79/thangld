using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Type;
using NHibernate.Engine;

    public class NHibernateHelper
    {
        private static Configuration mWConfig = null;
        private static ISessionFactory sessionFactory = null;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (object.Equals(NHibernateHelper.sessionFactory, null))
                    NHibernateHelper.sessionFactory = NHibernateHelper.MWConfig.BuildSessionFactory();
                
                return NHibernateHelper.sessionFactory;
            }
        }

        public static Configuration MWConfig
        {
            get 
            {
                if (object.Equals(NHibernateHelper.mWConfig, null))
                {
                    NHibernateHelper.mWConfig = new Configuration();
                    NHibernateHelper.mWConfig.AddAssembly("beans");
                }
                return NHibernateHelper.mWConfig;
            }
        }

        public static ISession CreateSession
        {
            get
            {
                return SessionFactory.OpenSession();
            }
        }
    }
