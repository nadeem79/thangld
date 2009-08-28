using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public class AdminConfigurationMethods
    {

        public Player Player
        {
            get;
            set;
        }

        #region GetTextSettings
        public IList<StringConfiguration> GetTextSettings(int page, int pageSize, string key, ISession session)
        {

            ICriteria criteria = session.CreateCriteria(typeof(StringConfiguration));
            if (key != string.Empty)
                criteria.Add(Expression.Like("Key", key, MatchMode.Anywhere));

            criteria.AddOrder(Order.Desc("Key"));
            return criteria.List<StringConfiguration>();
        }
        public IList<StringConfiguration> GetTextSettings(int page, int pageSize, ISession session)
        {
            return this.GetTextSettings(page, pageSize, "", session);
        }
        public IList<StringConfiguration> GetTextSettings(ISession session)
        {
            return this.GetTextSettings(0, 0, "", session);
        }
        #endregion

        #region GetNumericSettings
        public IList<NumericConfiguration> GetNumericSettings(int page, int pageSize, string key, ISession session)
        {

            var query = from numericConfiguration in session.Linq<NumericConfiguration>()
                        orderby numericConfiguration.Key descending
                        select numericConfiguration;

            if (key != string.Empty)
                query = (IOrderedQueryable<NumericConfiguration>)(query.Where<NumericConfiguration>(numericConfiguration => numericConfiguration.Key.Contains(key)));

            if (pageSize != 0)
                query = (IOrderedQueryable<NumericConfiguration>)(query.Skip((page - 1) * pageSize).Take(pageSize));

            return query.ToList<NumericConfiguration>();
        }
        public IList<NumericConfiguration> GetNumericSettings(int page, int pageSize, ISession session)
        {
            return this.GetNumericSettings(page, pageSize, "", session);
        }
        public IList<NumericConfiguration> GetNumericSettings(ISession session)
        {
            return this.GetNumericSettings(0, 0, "", session);
        }
        #endregion

        public void ChangeTextSetting(string key, string value, ISession session)
        {
            if (Configuration.TribalWarsConfiguration.StringConfiguration.ContainsKey(key))
            {
                StringConfiguration config = Configuration.TribalWarsConfiguration.StringConfiguration[key];

                StringConfiguration config1 = session.Get<StringConfiguration>(key);
                config1.Value = value;
                config.Value = value;
                session.Update(config1);
            }
            else
            {
                StringConfiguration config = new StringConfiguration();
                config.Key = key;
                config.Value = value;
                Configuration.TribalWarsConfiguration.StringConfiguration.Add(key, config);
                session.Save(config);
            }
        }

        public void ChangeNumericSetting(string key, double value, ISession session)
        {
            if (Configuration.TribalWarsConfiguration.NumericConfiguration.ContainsKey(key))
            {
                NumericConfiguration config = Configuration.TribalWarsConfiguration.NumericConfiguration[key];
                config.Value = value;

                NumericConfiguration config1 = session.Get<NumericConfiguration>(key);
                config1.Value = value;
                session.Update(config1);
                session.Flush();
            }
            else
            {
                NumericConfiguration config = new NumericConfiguration();
                config.Key = key;
                config.Value = value;
                Configuration.TribalWarsConfiguration.NumericConfiguration.Add(key, config);
                session.Save(config);
                session.Flush();
            }
        }

        public void DeleteNumericSetting(string key, ISession session)
        {
            if (!Configuration.TribalWarsConfiguration.NumericConfiguration.ContainsKey(key))
                return;

            NumericConfiguration config = Configuration.TribalWarsConfiguration.NumericConfiguration[key];
            Configuration.TribalWarsConfiguration.NumericConfiguration.Remove(key);
            session.Delete(config);
        }

        public void DeleteTextSetting(string key, ISession session)
        {
            if (!Configuration.TribalWarsConfiguration.StringConfiguration.ContainsKey(key))
                return;

            StringConfiguration config = session.Load<StringConfiguration>(key);
            Configuration.TribalWarsConfiguration.StringConfiguration.Remove(key);
            session.Delete(config);
        }
    }
}
