﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace beans.Services
{
    public class ConfigurationService
    {

        internal ConfigurationService() { }


        #region GetTextSettings
        public IList<StringConfiguration> GetTextSettings(Player staff, int page, int pageSize, string key, bool searchByKey, out int count, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.TextSettings.ToString(), "");

            var query = from stringConfiguration in session.Linq<StringConfiguration>()
                        orderby stringConfiguration.Key descending
                        select stringConfiguration;

            if (key != string.Empty)
            {
                if (searchByKey)
                    query = (IOrderedQueryable<StringConfiguration>)query.Where<StringConfiguration>(stringConfiguration => stringConfiguration.Key.Contains(key));
                else
                    query = (IOrderedQueryable<StringConfiguration>)query.Where<StringConfiguration>(stringConfiguration => stringConfiguration.Value.Contains(key));
            }
            if (pageSize == 0)
                pageSize = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value;
            count = query.Count<StringConfiguration>();

            return query.Skip(page*pageSize).Take(pageSize).ToList<StringConfiguration>();

        }

        public IList<StringConfiguration> GetTextSettings(Player staff, int page, int pageSize, out int count, ISession session)
        {
            return this.GetTextSettings(staff, page, pageSize, "", true, out count, session);
        }
        public IList<StringConfiguration> GetTextSettings(Player staff, int page, out int count, ISession session)
        {
            return this.GetTextSettings(staff, page, (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value, "", true, out count, session);
        }
        public IList<StringConfiguration> GetTextSettings(Player staff, out int count, ISession session)
        {
            return this.GetTextSettings(staff, 0, 0, "", true, out count, session);
        }
        #endregion

        #region GetNumericSettings
        public IList<NumericConfiguration> GetNumericSettings(Player staff, int page, int pageSize, string key, out int count, ISession session)
        {

            ServicesList.SecurityService.CheckPermission(staff, JobEnum.NumericSettings.ToString(), "");

            var query = from numericConfiguration in session.Linq<NumericConfiguration>()
                        orderby numericConfiguration.Key descending
                        select numericConfiguration;

            if (key != string.Empty)
                query = (IOrderedQueryable<NumericConfiguration>)(query.Where<NumericConfiguration>(numericConfiguration => numericConfiguration.Key.Contains(key)));

            if (pageSize == 0)
                pageSize = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value;

            count = query.Count<NumericConfiguration>();
            return query.Skip(page * pageSize).Take(pageSize).ToList<NumericConfiguration>();
        }

        public IList<NumericConfiguration> GetNumericSettings(Player staff, int page, int pageSize, out int count, ISession session)
        {
            return this.GetNumericSettings(staff, page, pageSize, "", out count, session);
        }
        public IList<NumericConfiguration> GetNumericSettings(Player staff, int page, out int count, ISession session)
        {
            return this.GetNumericSettings(staff, page, (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value, "", out count, session);
        }
        public IList<NumericConfiguration> GetNumericSettings(Player staff, out int count, ISession session)
        {
            return this.GetNumericSettings(staff, 0, 0, "", out count, session);
        }
        #endregion

        public void ChangeTextSetting(Player staff, string key, string value, ISession session)
        {

            ServicesList.SecurityService.CheckPermission(staff, JobEnum.TextSettings.ToString(), "");

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

        public void ChangeNumericSetting(Player staff, string key, double value, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.NumericSettings.ToString(), "");

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

        public void DeleteNumericSetting(Player staff, string key, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.NumericSettings.ToString(), "");
            if (!Configuration.TribalWarsConfiguration.NumericConfiguration.ContainsKey(key))
                return;

            NumericConfiguration config = Configuration.TribalWarsConfiguration.NumericConfiguration[key];
            Configuration.TribalWarsConfiguration.NumericConfiguration.Remove(key);
            session.Delete(config);
        }

        public void DeleteTextSetting(Player staff, string key, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.TextSettings.ToString(), "");
            if (!Configuration.TribalWarsConfiguration.StringConfiguration.ContainsKey(key))
                return;

            StringConfiguration config = session.Load<StringConfiguration>(key);
            Configuration.TribalWarsConfiguration.StringConfiguration.Remove(key);
            session.Delete(config);
        }

        public void RestartServer(Player staff, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.RestartServer.ToString(), "");

            TribalWarsEngine.Start(session);
        }
    }
}